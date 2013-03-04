using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace DAQ32_PC_Interface
{
    public class DAQ32data
    {
        public string CSVline;
        public ushort[] chan;
        public int numChan;
        public double sampleRate;
        public int packetCnt;
        public int errorCnt;

        public DAQ32data()
        {
            CSVline = "";
            chan = new ushort[32] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            numChan = 0;
            sampleRate = 0.0;
            packetCnt = 0;
            errorCnt = 0;
        }
    }

    public class DAQ32serial
    {
        private SerialPort com;
        private DAQ32data data;
        private byte[] RXbuf = new byte[256];
        private byte RXbufIndex = 0;

        public DAQ32serial(string COMport)
        {
            com = new SerialPort(COMport, 921600, Parity.None, 8, StopBits.One);
            com.Handshake = Handshake.RequestToSend;
            com.ReceivedBytesThreshold = 1;
            com.DataReceived += new SerialDataReceivedEventHandler(com_DataReceived);
            data = new DAQ32data();
            com.Open();
        }

        public void Close()
        {
            try { com.Close(); }
            catch { } 
        }

        void com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numToRead = com.BytesToRead;                                        // get the number of bytes in the serial buffer
            byte[] serialBuf = new byte[numToRead];                                 // local array to hold bytes in the serial buffer
            com.Read(serialBuf, 0, numToRead);                                      // transfer bytes

            for (int i = 0; i < numToRead; i++)
            {
                if ((serialBuf[i] & (byte)128) == 128)                              // if byte represents start of packet
                {
                    try
                    {
                        if ((RXbufIndex % 2) != 0) throw new Exception();           // if odd number of bytes in packet, do not proceed
                        if ((RXbufIndex / 2) != data.numChan)                       // if numChan changed since last frame
                        {
                            data.numChan = RXbufIndex / 2;                          // store nummber of channels
                            if (data.numChan != 0) throw new Exception();           // do not proceed (special case: first ever packet
                        }
                        RXbuf[0] = (byte)(RXbuf[0] & (byte)127);                    // clear framing bit of first byte
                        data.CSVline = "";
                        for (int j = 0; j < data.numChan; j++)
                        {
                            ushort temp = 0;
                            temp = (ushort)(RXbuf[2 * j] & (byte)127); ;            // temp lower byte = RXbuf with MSB cleared
                            temp <<= 7;                                             // shift to bits 7-11
                            temp |= (ushort)(RXbuf[(2 * j) + 1] & (byte)127);       // temp lower byte = RXbuf not inc. MSB
                            data.chan[j] = temp;
                            if (j != 0) data.CSVline += ",";
                            data.CSVline += Convert.ToString(temp);
                        }
                        data.CSVline += "\r";
                        data.sampleRate = 32768.0 / (double)data.numChan;           // calculate sample rate
                        data.packetCnt++;
                        OnPacketReceived(data);                                     // trigger event
                    }
                    catch                                                           // packet error
                    {
                        data.errorCnt++;                                            // increment error counter
                        OnPacketError(new EventArgs());                             // trigger event
                    }
                    RXbufIndex = 0;                                                 // reset RX buffer index
                }
                RXbuf[RXbufIndex++] = serialBuf[i];                                 // add new byte to RX buffer
            }
        }

        public delegate void onDataPacketReceived(object sender, DAQ32data e);
        public event onDataPacketReceived packetReceived;
        protected virtual void OnPacketReceived(DAQ32data e) { if (packetReceived != null) packetReceived(this, e); }

        public delegate void onDataPacketError(object sender, EventArgs e);
        public event onDataPacketError packetError;
        protected virtual void OnPacketError(EventArgs e) { if (packetError != null) packetError(this, e); }
    }
}
