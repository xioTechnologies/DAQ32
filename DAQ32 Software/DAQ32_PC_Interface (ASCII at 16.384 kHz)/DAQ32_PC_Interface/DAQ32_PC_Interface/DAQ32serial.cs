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
            int numToRead = com.BytesToRead;                                    // get the number of bytes in the serial buffer
            byte[] serialBuf = new byte[numToRead];                             // local array to hold bytes in the serial buffer
            com.Read(serialBuf, 0, numToRead);                                  // transfer bytes
            for (int i = 0; i < numToRead; i++)
            {
                data.CSVline += (char)serialBuf[i];                             // add received byte to string
                if (serialBuf[i] == '\r')                                       // if termination char 
                {
                    string[] vars = data.CSVline.Split(',');                    // seporate CSVs
                    try                                                         // attemped packet decoding...
                    {
                        if (vars.Length != data.numChan)                        // if numChan changed since last frame
                        {
                            data.numChan = vars.Length;                         // store nummber of channels
                            throw new Exception();                              // do not proceed, this is an error
                        }
                        for (int j = 0; j < vars.Length; j++)
                        {
                            uint tempInt = Convert.ToUInt32(vars[j]);           // convert ASCII to uint32
                            if (tempInt < 4096) data.chan[j] = (ushort)tempInt; // store if converted value is uint12
                            else throw new Exception();                         // else do not proceed, this is an error
                        }
                        data.sampleRate = 16384.0 / (double)data.numChan;       // calculate sample rate
                        data.packetCnt++;                                       // increment packet counter
                        OnPacketReceived(data);                                 // trigger event
                    }
                    catch                                                       // packet decoding error
                    {
                        data.errorCnt++;                                        // increment error counter
                        OnPacketError(new EventArgs());                         // trigger event
                    }
                    data.CSVline = "";                                          // reset buffer
                }
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
