using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

// Osc_DLL.dll library from: http://www.oscilloscope-lib.com/
// Oscilloscope.cs C# wrapper from: Frank Greenlee

namespace DAQ32_PC_Interface
{
    public partial class Form1 : Form
    {
        private static Timer formUpdateTimer;
        private static DAQ32serial daq32;
        private static DAQ32data data;
        private static StreamWriter file;
        private static Oscilloscope scopeA, scopeB, scopeC, scopeD;
        private static int scopeA0, scopeA1, scopeA2, scopeAtrig,
                           scopeB0, scopeB1, scopeB2, scopeBtrig,
                           scopeC0, scopeC1, scopeC2, scopeCtrig,
                           scopeD0, scopeD1, scopeD2, scopeDtrig;
        private static double time = 0;
        private const string iniFileName = "scope_settings.ini";

        public Form1()
        {
            InitializeComponent();
        }

        #region Form load and close

        private void Form1_Load(object sender, EventArgs e)
        {
            // List aviable COM ports and select last in list
            string[] aviablePorts = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < aviablePorts.Length; i++) comboBox_COM.Items.Add(aviablePorts[i]);
            comboBox_COM.SelectedIndex = comboBox_COM.Items.Count - 1;

            // Create scope objects
            scopeA = Oscilloscope.CreateScope(iniFileName, "");
            if (scopeA != null)
            {
                scopeB = Oscilloscope.CreateScope(iniFileName, "");
                scopeC = Oscilloscope.CreateScope(iniFileName, "");
                scopeD = Oscilloscope.CreateScope(iniFileName, "");
            }

            // Set default scope channels
            comboBox_scopeA0.SelectedIndex = 0;
            comboBox_scopeA1.SelectedIndex = 1;
            comboBox_scopeA2.SelectedIndex = 2;
            comboBox_scopeAtrig.SelectedIndex = 12;
            comboBox_scopeB0.SelectedIndex = 3;
            comboBox_scopeB1.SelectedIndex = 4;
            comboBox_scopeB2.SelectedIndex = 5;
            comboBox_scopeBtrig.SelectedIndex = 13;
            comboBox_scopeC0.SelectedIndex = 6;
            comboBox_scopeC1.SelectedIndex = 7;
            comboBox_scopeC2.SelectedIndex = 8;
            comboBox_scopeCtrig.SelectedIndex = 14;
            comboBox_scopeD0.SelectedIndex = 9;
            comboBox_scopeD1.SelectedIndex = 10;
            comboBox_scopeD2.SelectedIndex = 11;
            comboBox_scopeDtrig.SelectedIndex = 15;

            // Show scopes and use default settings if .ini file file not present
            if (scopeA != null)
            {
                scopeA.ShowScope();
                scopeB.ShowScope();
                scopeC.ShowScope();
                scopeD.ShowScope();
                if (!File.Exists(iniFileName))
                {
                    #region default scope settings
                    scopeA.TriggerLevel1 = 2048;
                    scopeA.TriggerLevel2 = 2048;
                    scopeA.TriggerLevel3 = 2048;
                    scopeA.AmplitudeScale1 = 300;
                    scopeA.AmplitudeScale2 = 300;
                    scopeA.AmplitudeScale3 = 300;
                    scopeA.VerticalOffset1 = -2000;
                    scopeA.VerticalOffset2 = -2000;
                    scopeA.VerticalOffset3 = -2000;
                    scopeA.SamplesPerGridCell = 100;
                    scopeA.CellSize = 35;
                    scopeA.Width = 630;
                    scopeA.Height = 470;
                    scopeB.TriggerLevel1 = 2048;
                    scopeB.TriggerLevel2 = 2048;
                    scopeB.TriggerLevel3 = 2048;
                    scopeB.AmplitudeScale1 = 300;
                    scopeB.AmplitudeScale2 = 300;
                    scopeB.AmplitudeScale3 = 300;
                    scopeB.VerticalOffset1 = -2000;
                    scopeB.VerticalOffset2 = -2000;
                    scopeB.VerticalOffset3 = -2000;
                    scopeB.SamplesPerGridCell = 100;
                    scopeB.CellSize = 35;
                    scopeB.Width = 630;
                    scopeB.Height = 470;
                    scopeC.TriggerLevel1 = 2048;
                    scopeC.TriggerLevel2 = 2048;
                    scopeC.TriggerLevel3 = 2048;
                    scopeC.AmplitudeScale1 = 300;
                    scopeC.AmplitudeScale2 = 300;
                    scopeC.AmplitudeScale3 = 300;
                    scopeC.VerticalOffset1 = -2000;
                    scopeC.VerticalOffset2 = -2000;
                    scopeC.VerticalOffset3 = -2000;
                    scopeC.SamplesPerGridCell = 100;
                    scopeC.CellSize = 35;
                    scopeC.Width = 630;
                    scopeC.Height = 470;
                    scopeD.TriggerLevel1 = 2048;
                    scopeD.TriggerLevel2 = 2048;
                    scopeD.TriggerLevel3 = 2048;
                    scopeD.AmplitudeScale1 = 300;
                    scopeD.AmplitudeScale2 = 300;
                    scopeD.AmplitudeScale3 = 300;
                    scopeD.VerticalOffset1 = -2000;
                    scopeD.VerticalOffset2 = -2000;
                    scopeD.VerticalOffset3 = -2000;
                    scopeD.SamplesPerGridCell = 100;
                    scopeD.CellSize = 35;
                    scopeD.Width = 630;
                    scopeD.Height = 470;
                    #endregion
                }
            }

            // disable scope form controls if scope .dll error
            else
            {
                label_scopeA.Enabled = false;
                comboBox_scopeA0.Enabled = false;
                comboBox_scopeA1.Enabled = false;
                comboBox_scopeA2.Enabled = false;
                comboBox_scopeAtrig.Enabled = false;
                label_scopeB.Enabled = false;
                comboBox_scopeB0.Enabled = false;
                comboBox_scopeB1.Enabled = false;
                comboBox_scopeB2.Enabled = false;
                comboBox_scopeBtrig.Enabled = false;
                label_scopeC.Enabled = false;
                comboBox_scopeC0.Enabled = false;
                comboBox_scopeC1.Enabled = false;
                comboBox_scopeC2.Enabled = false;
                comboBox_scopeCtrig.Enabled = false;
                label_scopeD.Enabled = false;
                comboBox_scopeD0.Enabled = false;
                comboBox_scopeD1.Enabled = false;
                comboBox_scopeD2.Enabled = false;
                comboBox_scopeDtrig.Enabled = false;
            }

            // Create new DAQ32 data object
            data = new DAQ32data();

            // Start for update timer
            formUpdateTimer = new Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            scopeA.Dispose();
            scopeB.Dispose();
            scopeC.Dispose();
            scopeD.Dispose();
            daq32.Close();
            try { file.Close(); }
            catch { }
        }

        #endregion

        #region Open/Close port, form update timer event and data received event

        private void button_openPort_Click(object sender, EventArgs e)
        {
            if (button_open.Text == "Open port")
            {
                try
                {
                    daq32 = new DAQ32serial(comboBox_COM.Text);
                    daq32.packetReceived += new DAQ32serial.onDataPacketReceived(daq32_packetReceived);
                    daq32.packetError += new DAQ32serial.onDataPacketError(daq32_packetError);
                    comboBox_COM.Enabled = false;
                    button_open.Text = "Close port";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else // if(button_connect.Text == "Disconnect")
            {
                daq32.Close();
                daq32 = null;
                comboBox_COM.Enabled = true;
                button_open.Text = "Open port";
            }
        }

        void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (daq32 != null)
            {
                textBox_channels.Text = Convert.ToString(data.numChan);
                textBox_samplerate.Text = String.Format("{0:0.000}", data.sampleRate / 1000);
                textBox_samplePeriod.Text = String.Format("{0:0.000}", 1000000.0 / data.sampleRate);
                textBox_packets.Text = Convert.ToString(data.packetCnt);
                textBox_errors.Text = Convert.ToString(data.errorCnt);
            }
            else
            {
                textBox_channels.Text = "";
                textBox_samplerate.Text = "";
                textBox_samplePeriod.Text = "";
                textBox_packets.Text = "";
                textBox_errors.Text = "";
            }
        }

        void daq32_packetReceived(object sender, DAQ32data e)
        {
            data = e;
            if (scopeA != null)
            {
                scopeA.AddScopeData(e.chan[scopeA0], e.chan[scopeA1], e.chan[scopeA2]);
                scopeA.AddExternalScopeData(e.chan[scopeAtrig]);
                scopeB.AddScopeData(e.chan[scopeB0], e.chan[scopeB1], e.chan[scopeB2]);
                scopeB.AddExternalScopeData(e.chan[scopeBtrig]);
                scopeC.AddScopeData(e.chan[scopeC0], e.chan[scopeC1], e.chan[scopeC2]);
                scopeC.AddExternalScopeData(e.chan[scopeCtrig]);
                scopeD.AddScopeData(e.chan[scopeD0], e.chan[scopeD1], e.chan[scopeD2]);
                scopeD.AddExternalScopeData(e.chan[scopeDtrig]);
            }
            if (file != null)
            {
                time += 1.0 / e.sampleRate;
                file.WriteLine(Convert.ToString(time) + "," + e.CSVline);
            }
        }

        #endregion

        #region Scope channel select

        private void comboBox_scopeA012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeA != null)
            {
                scopeA0 = comboBox_scopeA0.SelectedIndex;
                scopeA1 = comboBox_scopeA1.SelectedIndex;
                scopeA2 = comboBox_scopeA2.SelectedIndex;
                scopeAtrig = comboBox_scopeAtrig.SelectedIndex;
                scopeA.Caption = "Scope A - Channels: " + Convert.ToString(scopeA0) + ", " + Convert.ToString(scopeA1) + ", " + Convert.ToString(scopeA2) + ", Ext.Trig: " + Convert.ToString(scopeAtrig);
            }
        }

        private void comboBox_scopeB012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeB != null)
            {
                scopeB0 = comboBox_scopeB0.SelectedIndex;
                scopeB1 = comboBox_scopeB1.SelectedIndex;
                scopeB2 = comboBox_scopeB2.SelectedIndex;
                scopeBtrig = comboBox_scopeBtrig.SelectedIndex;
                scopeB.Caption = "Scope B - Channels: " + Convert.ToString(scopeB0) + ", " + Convert.ToString(scopeB1) + ", " + Convert.ToString(scopeB2) + ", Ext.Trig: " + Convert.ToString(scopeBtrig);
            }
        }

        private void comboBox_scopeC012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeC != null)
            {
                scopeC0 = comboBox_scopeC0.SelectedIndex;
                scopeC1 = comboBox_scopeC1.SelectedIndex;
                scopeC2 = comboBox_scopeC2.SelectedIndex;
                scopeCtrig = comboBox_scopeCtrig.SelectedIndex;
                scopeC.Caption = "Scope C - Channels: " + Convert.ToString(scopeC0) + ", " + Convert.ToString(scopeC1) + ", " + Convert.ToString(scopeC2) + ", Ext.Trig: " + Convert.ToString(scopeCtrig);
            }
        }

        private void comboBox_scopeD012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeD != null)
            {
                scopeD0 = comboBox_scopeD0.SelectedIndex;
                scopeD1 = comboBox_scopeD1.SelectedIndex;
                scopeD2 = comboBox_scopeD2.SelectedIndex;
                scopeDtrig = comboBox_scopeDtrig.SelectedIndex;
                scopeD.Caption = "Scope D - Channels: " + Convert.ToString(scopeD0) + ", " + Convert.ToString(scopeD1) + ", " + Convert.ToString(scopeD2) + ", Ext.Trig: " + Convert.ToString(scopeDtrig);
            }
        }

        #endregion

        #region Start/Stop log and packet error event

        private void button_startLog_Click(object sender, EventArgs e)
        {
            if (button_startLog.Text == "Start Log")
            {
                try
                {
                    time = 0;
                    file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\" + textBox_filename.Text + ".csv", false);
                    textBox_filename.Enabled = false;
                    button_startLog.Text = "Stop Log";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else // if(button_startLog.Text == "Stop Log")
            {
                closeFile();
            }
        }

        void daq32_packetError(object sender, EventArgs e)
        {
            if (file != null)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { closeFile(); })));
                MessageBox.Show("Log stopped due to packet framing error");
            }
        }

        private void closeFile()
        {
            if (file != null) file.Close();
            file = null;
            textBox_filename.Enabled = true;
            button_startLog.Text = "Start Log";
        }

        #endregion

    }
}