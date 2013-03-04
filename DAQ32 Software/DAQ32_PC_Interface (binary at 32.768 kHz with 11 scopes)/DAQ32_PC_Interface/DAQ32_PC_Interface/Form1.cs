using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DAQ32_PC_Interface
{
    public partial class Form1 : Form
    {
        private static Timer formUpdateTimer;
        private static DAQ32serial daq32;
        private static DAQ32data data;
        private static StreamWriter file;
        private static Oscilloscope scopeA, scopeB, scopeC, scopeD, scopeE, scopeF, scopeG, scopeH, scopeI, scopeJ, scopeK;
        private static int scopeA0, scopeA1, scopeA2, scopeAtrig, scopeB0, scopeB1, scopeB2, scopeBtrig,
                           scopeC0, scopeC1, scopeC2, scopeCtrig, scopeD0, scopeD1, scopeD2, scopeDtrig,
                           scopeE0, scopeE1, scopeE2, scopeEtrig, scopeF0, scopeF1, scopeF2, scopeFtrig,
                           scopeG0, scopeG1, scopeG2, scopeGtrig, scopeH0, scopeH1, scopeH2, scopeHtrig,
                           scopeI0, scopeI1, scopeI2, scopeItrig, scopeJ0, scopeJ1, scopeJ2, scopeJtrig,
                           scopeK0, scopeK1, scopeK2, scopeKtrig;
        private static double time = 0;

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
            scopeA = Oscilloscope.CreateScope("scope_settings.ini", "");
            if (scopeA != null)
            {
                scopeB = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeC = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeD = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeE = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeF = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeG = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeH = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeI = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeJ = Oscilloscope.CreateScope("scope_settings.ini", "");
                scopeK = Oscilloscope.CreateScope("scope_settings.ini", "");
            }

            // Set default scope channels
            comboBox_scopeA0.SelectedIndex = 0;
            comboBox_scopeA1.SelectedIndex = 1;
            comboBox_scopeA2.SelectedIndex = 2;
            comboBox_scopeAtrig.SelectedIndex = 0;
            comboBox_scopeB0.SelectedIndex = 3;
            comboBox_scopeB1.SelectedIndex = 4;
            comboBox_scopeB2.SelectedIndex = 5;
            comboBox_scopeBtrig.SelectedIndex = 3;
            comboBox_scopeC0.SelectedIndex = 6;
            comboBox_scopeC1.SelectedIndex = 7;
            comboBox_scopeC2.SelectedIndex = 8;
            comboBox_scopeCtrig.SelectedIndex = 6;
            comboBox_scopeD0.SelectedIndex = 9;
            comboBox_scopeD1.SelectedIndex = 10;
            comboBox_scopeD2.SelectedIndex = 11;
            comboBox_scopeDtrig.SelectedIndex = 9;
            comboBox_scopeE0.SelectedIndex = 12;
            comboBox_scopeE1.SelectedIndex = 13;
            comboBox_scopeE2.SelectedIndex = 14;
            comboBox_scopeEtrig.SelectedIndex = 12;
            comboBox_scopeF0.SelectedIndex = 15;
            comboBox_scopeF1.SelectedIndex = 16;
            comboBox_scopeF2.SelectedIndex = 17;
            comboBox_scopeFtrig.SelectedIndex = 15;
            comboBox_scopeG0.SelectedIndex = 18;
            comboBox_scopeG1.SelectedIndex = 19;
            comboBox_scopeG2.SelectedIndex = 20;
            comboBox_scopeGtrig.SelectedIndex = 18;
            comboBox_scopeH0.SelectedIndex = 21;
            comboBox_scopeH1.SelectedIndex = 22;
            comboBox_scopeH2.SelectedIndex = 23;
            comboBox_scopeHtrig.SelectedIndex = 21;
            comboBox_scopeI0.SelectedIndex = 24;
            comboBox_scopeI1.SelectedIndex = 25;
            comboBox_scopeI2.SelectedIndex = 26;
            comboBox_scopeItrig.SelectedIndex = 24;
            comboBox_scopeJ0.SelectedIndex = 27;
            comboBox_scopeJ1.SelectedIndex = 28;
            comboBox_scopeJ2.SelectedIndex = 29;
            comboBox_scopeJtrig.SelectedIndex = 28;
            comboBox_scopeK0.SelectedIndex = 30;
            comboBox_scopeK1.SelectedIndex = 31;
            comboBox_scopeK2.SelectedIndex = 0;
            comboBox_scopeKtrig.SelectedIndex = 30;

            // Show scopes else disable controls if .ini file file not present
            if (scopeA != null)
            {
                //button_scopeAshow.PerformClick();
                //button_scopeBshow.PerformClick();
                //button_scopeCshow.PerformClick();
                //button_scopeDshow.PerformClick();
                //button_scopeEshow.PerformClick();
                //button_scopeFshow.PerformClick();
                //button_scopeGshow.PerformClick();
                //button_scopeHshow.PerformClick();
                //button_scopeIshow.PerformClick();
                //button_scopeJshow.PerformClick();
                //button_scopeKshow.PerformClick();
            }
            else
            {
                button_scopeAshow.Enabled = false;
                button_scopeBshow.Enabled = false;
                button_scopeCshow.Enabled = false;
                button_scopeDshow.Enabled = false;
                button_scopeEshow.Enabled = false;
                button_scopeFshow.Enabled = false;
                button_scopeGshow.Enabled = false;
                button_scopeHshow.Enabled = false;
                button_scopeIshow.Enabled = false;
                button_scopeJshow.Enabled = false;
                button_scopeKshow.Enabled = false;
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
            daq32.Close();
            if (file != null) file.Close();
            scopeA.Dispose();
            scopeB.Dispose();
            scopeC.Dispose();
            scopeD.Dispose();
            scopeE.Dispose();
            scopeF.Dispose();
            scopeG.Dispose();
            scopeH.Dispose();
            scopeI.Dispose();
            scopeJ.Dispose();
            scopeK.Dispose();
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
            else
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
            }
            else
            {
                textBox_channels.Text = "";
                textBox_samplerate.Text = "";
                textBox_samplePeriod.Text = "";
                textBox_packets.Text = "";
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
                scopeE.AddScopeData(e.chan[scopeE0], e.chan[scopeE1], e.chan[scopeE2]);
                scopeE.AddExternalScopeData(e.chan[scopeEtrig]);
                scopeF.AddScopeData(e.chan[scopeF0], e.chan[scopeF1], e.chan[scopeF2]);
                scopeF.AddExternalScopeData(e.chan[scopeFtrig]);
                scopeG.AddScopeData(e.chan[scopeG0], e.chan[scopeG1], e.chan[scopeG2]);
                scopeG.AddExternalScopeData(e.chan[scopeGtrig]);
                scopeH.AddScopeData(e.chan[scopeH0], e.chan[scopeH1], e.chan[scopeH2]);
                scopeH.AddExternalScopeData(e.chan[scopeHtrig]);
                scopeI.AddScopeData(e.chan[scopeI0], e.chan[scopeI1], e.chan[scopeI2]);
                scopeI.AddExternalScopeData(e.chan[scopeItrig]);
                scopeJ.AddScopeData(e.chan[scopeJ0], e.chan[scopeJ1], e.chan[scopeJ2]);
                scopeJ.AddExternalScopeData(e.chan[scopeJtrig]);
                scopeK.AddScopeData(e.chan[scopeK0], e.chan[scopeK1], e.chan[scopeK2]);
                scopeK.AddExternalScopeData(e.chan[scopeKtrig]);
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

        private void comboBox_scopeE012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeE != null)
            {
                scopeE0 = comboBox_scopeE0.SelectedIndex;
                scopeE1 = comboBox_scopeE1.SelectedIndex;
                scopeE2 = comboBox_scopeE2.SelectedIndex;
                scopeEtrig = comboBox_scopeEtrig.SelectedIndex;
                scopeE.Caption = "Scope E - Channels: " + Convert.ToString(scopeE0) + ", " + Convert.ToString(scopeE1) + ", " + Convert.ToString(scopeE2) + ", Ext.Trig: " + Convert.ToString(scopeEtrig);
            }
        }

        private void comboBox_scopeF012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeF != null)
            {
                scopeF0 = comboBox_scopeF0.SelectedIndex;
                scopeF1 = comboBox_scopeF1.SelectedIndex;
                scopeF2 = comboBox_scopeF2.SelectedIndex;
                scopeFtrig = comboBox_scopeFtrig.SelectedIndex;
                scopeF.Caption = "Scope F - Channels: " + Convert.ToString(scopeF0) + ", " + Convert.ToString(scopeF1) + ", " + Convert.ToString(scopeF2) + ", Ext.Trig: " + Convert.ToString(scopeFtrig);
            }
        }

        private void comboBox_scopeG012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeG != null)
            {
                scopeG0 = comboBox_scopeG0.SelectedIndex;
                scopeG1 = comboBox_scopeG1.SelectedIndex;
                scopeG2 = comboBox_scopeG2.SelectedIndex;
                scopeGtrig = comboBox_scopeGtrig.SelectedIndex;
                scopeG.Caption = "Scope G - Channels: " + Convert.ToString(scopeG0) + ", " + Convert.ToString(scopeG1) + ", " + Convert.ToString(scopeG2) + ", Ext.Trig: " + Convert.ToString(scopeGtrig);
            }
        }

        private void comboBox_scopeH012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeH != null)
            {
                scopeH0 = comboBox_scopeH0.SelectedIndex;
                scopeH1 = comboBox_scopeH1.SelectedIndex;
                scopeH2 = comboBox_scopeH2.SelectedIndex;
                scopeHtrig = comboBox_scopeHtrig.SelectedIndex;
                scopeH.Caption = "Scope H - Channels: " + Convert.ToString(scopeH0) + ", " + Convert.ToString(scopeH1) + ", " + Convert.ToString(scopeH2) + ", Ext.Trig: " + Convert.ToString(scopeHtrig);
            }
        }

        private void comboBox_scopeI012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeI != null)
            {
                scopeI0 = comboBox_scopeI0.SelectedIndex;
                scopeI1 = comboBox_scopeI1.SelectedIndex;
                scopeI2 = comboBox_scopeI2.SelectedIndex;
                scopeItrig = comboBox_scopeItrig.SelectedIndex;
                scopeI.Caption = "Scope I - Channels: " + Convert.ToString(scopeI0) + ", " + Convert.ToString(scopeI1) + ", " + Convert.ToString(scopeI2) + ", Ext.Trig: " + Convert.ToString(scopeItrig);
            }
        }

        private void comboBox_scopeJ012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeJ != null)
            {
                scopeJ0 = comboBox_scopeJ0.SelectedIndex;
                scopeJ1 = comboBox_scopeJ1.SelectedIndex;
                scopeJ2 = comboBox_scopeJ2.SelectedIndex;
                scopeJtrig = comboBox_scopeJtrig.SelectedIndex;
                scopeJ.Caption = "Scope J - Channels: " + Convert.ToString(scopeJ0) + ", " + Convert.ToString(scopeJ1) + ", " + Convert.ToString(scopeJ2) + ", Ext.Trig: " + Convert.ToString(scopeJtrig);
            }
        }

        private void comboBox_scopeK012trig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scopeK != null)
            {
                scopeK0 = comboBox_scopeK0.SelectedIndex;
                scopeK1 = comboBox_scopeK1.SelectedIndex;
                scopeK2 = comboBox_scopeK2.SelectedIndex;
                scopeKtrig = comboBox_scopeKtrig.SelectedIndex;
                scopeK.Caption = "Scope K - Channels: " + Convert.ToString(scopeK0) + ", " + Convert.ToString(scopeK1) + ", " + Convert.ToString(scopeK2) + ", Ext.Trig: " + Convert.ToString(scopeKtrig);
            }
        }

        #endregion

        #region Scope Show/Hide

        private void button_scopeAshow_Click(object sender, EventArgs e)
        {
            if (button_scopeAshow.Text == "Show")
            {
                scopeA.ShowScope();
                button_scopeAshow.Text = "Hide";
                label_scopeA.Enabled = true;
                comboBox_scopeA0.Enabled = true;
                comboBox_scopeA1.Enabled = true;
                comboBox_scopeA2.Enabled = true;
                comboBox_scopeAtrig.Enabled = true;
            }
            else
            {
                scopeA.HideScope();
                button_scopeAshow.Text = "Show";
                label_scopeA.Enabled = false;
                comboBox_scopeA0.Enabled = false;
                comboBox_scopeA1.Enabled = false;
                comboBox_scopeA2.Enabled = false;
                comboBox_scopeAtrig.Enabled = false;
            }
        }

        private void button_scopeBshow_Click(object sender, EventArgs e)
        {
            if (button_scopeBshow.Text == "Show")
            {
                scopeB.ShowScope();
                button_scopeBshow.Text = "Hide";
                label_scopeB.Enabled = true;
                comboBox_scopeB0.Enabled = true;
                comboBox_scopeB1.Enabled = true;
                comboBox_scopeB2.Enabled = true;
                comboBox_scopeBtrig.Enabled = true;
            }
            else
            {
                scopeB.HideScope();
                button_scopeBshow.Text = "Show";
                label_scopeB.Enabled = false;
                comboBox_scopeB0.Enabled = false;
                comboBox_scopeB1.Enabled = false;
                comboBox_scopeB2.Enabled = false;
                comboBox_scopeBtrig.Enabled = false;
            }
        }

        private void button_scopeCshow_Click(object sender, EventArgs e)
        {
            if (button_scopeCshow.Text == "Show")
            {
                scopeC.ShowScope();
                button_scopeCshow.Text = "Hide";
                label_scopeC.Enabled = true;
                comboBox_scopeC0.Enabled = true;
                comboBox_scopeC1.Enabled = true;
                comboBox_scopeC2.Enabled = true;
                comboBox_scopeCtrig.Enabled = true;
            }
            else
            {
                scopeC.HideScope();
                button_scopeCshow.Text = "Show";
                label_scopeC.Enabled = false;
                comboBox_scopeC0.Enabled = false;
                comboBox_scopeC1.Enabled = false;
                comboBox_scopeC2.Enabled = false;
                comboBox_scopeCtrig.Enabled = false;
            }
        }

        private void button_scopeDshow_Click(object sender, EventArgs e)
        {
            if (button_scopeDshow.Text == "Show")
            {
                scopeD.ShowScope();
                button_scopeDshow.Text = "Hide";
                label_scopeD.Enabled = true;
                comboBox_scopeD0.Enabled = true;
                comboBox_scopeD1.Enabled = true;
                comboBox_scopeD2.Enabled = true;
                comboBox_scopeDtrig.Enabled = true;
            }
            else
            {
                scopeD.HideScope();
                button_scopeDshow.Text = "Show";
                label_scopeD.Enabled = false;
                comboBox_scopeD0.Enabled = false;
                comboBox_scopeD1.Enabled = false;
                comboBox_scopeD2.Enabled = false;
                comboBox_scopeDtrig.Enabled = false;
            }
        }

        private void button_scopeEshow_Click(object sender, EventArgs e)
        {
            if (button_scopeEshow.Text == "Show")
            {
                scopeE.ShowScope();
                button_scopeEshow.Text = "Hide";
                label_scopeE.Enabled = true;
                comboBox_scopeE0.Enabled = true;
                comboBox_scopeE1.Enabled = true;
                comboBox_scopeE2.Enabled = true;
                comboBox_scopeEtrig.Enabled = true;
            }
            else
            {
                scopeE.HideScope();
                button_scopeEshow.Text = "Show";
                label_scopeE.Enabled = false;
                comboBox_scopeE0.Enabled = false;
                comboBox_scopeE1.Enabled = false;
                comboBox_scopeE2.Enabled = false;
                comboBox_scopeEtrig.Enabled = false;
            }
        }

        private void button_scopeFshow_Click(object sender, EventArgs e)
        {
            if (button_scopeFshow.Text == "Show")
            {
                scopeF.ShowScope();
                button_scopeFshow.Text = "Hide";
                label_scopeF.Enabled = true;
                comboBox_scopeF0.Enabled = true;
                comboBox_scopeF1.Enabled = true;
                comboBox_scopeF2.Enabled = true;
                comboBox_scopeFtrig.Enabled = true;
            }
            else
            {
                scopeF.HideScope();
                button_scopeFshow.Text = "Show";
                label_scopeF.Enabled = false;
                comboBox_scopeF0.Enabled = false;
                comboBox_scopeF1.Enabled = false;
                comboBox_scopeF2.Enabled = false;
                comboBox_scopeFtrig.Enabled = false;
            }
        }

        private void button_scopeGshow_Click(object sender, EventArgs e)
        {
            if (button_scopeGshow.Text == "Show")
            {
                scopeG.ShowScope();
                button_scopeGshow.Text = "Hide";
                label_scopeG.Enabled = true;
                comboBox_scopeG0.Enabled = true;
                comboBox_scopeG1.Enabled = true;
                comboBox_scopeG2.Enabled = true;
                comboBox_scopeGtrig.Enabled = true;
            }
            else
            {
                scopeG.HideScope();
                button_scopeGshow.Text = "Show";
                label_scopeG.Enabled = false;
                comboBox_scopeG0.Enabled = false;
                comboBox_scopeG1.Enabled = false;
                comboBox_scopeG2.Enabled = false;
                comboBox_scopeGtrig.Enabled = false;
            }
        }

        private void button_scopeHshow_Click(object sender, EventArgs e)
        {
            if (button_scopeHshow.Text == "Show")
            {
                scopeH.ShowScope();
                button_scopeHshow.Text = "Hide";
                label_scopeH.Enabled = true;
                comboBox_scopeH0.Enabled = true;
                comboBox_scopeH1.Enabled = true;
                comboBox_scopeH2.Enabled = true;
                comboBox_scopeHtrig.Enabled = true;
            }
            else
            {
                scopeH.HideScope();
                button_scopeHshow.Text = "Show";
                label_scopeH.Enabled = false;
                comboBox_scopeH0.Enabled = false;
                comboBox_scopeH1.Enabled = false;
                comboBox_scopeH2.Enabled = false;
                comboBox_scopeHtrig.Enabled = false;
            }
        }

        private void button_scopeIshow_Click(object sender, EventArgs e)
        {
            if (button_scopeIshow.Text == "Show")
            {
                scopeI.ShowScope();
                button_scopeIshow.Text = "Hide";
                label_scopeI.Enabled = true;
                comboBox_scopeI0.Enabled = true;
                comboBox_scopeI1.Enabled = true;
                comboBox_scopeI2.Enabled = true;
                comboBox_scopeItrig.Enabled = true;
            }
            else
            {
                scopeI.HideScope();
                button_scopeIshow.Text = "Show";
                label_scopeI.Enabled = false;
                comboBox_scopeI0.Enabled = false;
                comboBox_scopeI1.Enabled = false;
                comboBox_scopeI2.Enabled = false;
                comboBox_scopeItrig.Enabled = false;
            }
        }

        private void button_scopeJshow_Click(object sender, EventArgs e)
        {
            if (button_scopeJshow.Text == "Show")
            {
                scopeJ.ShowScope();
                button_scopeJshow.Text = "Hide";
                label_scopeJ.Enabled = true;
                comboBox_scopeJ0.Enabled = true;
                comboBox_scopeJ1.Enabled = true;
                comboBox_scopeJ2.Enabled = true;
                comboBox_scopeJtrig.Enabled = true;
            }
            else
            {
                scopeJ.HideScope();
                button_scopeJshow.Text = "Show";
                label_scopeJ.Enabled = false;
                comboBox_scopeJ0.Enabled = false;
                comboBox_scopeJ1.Enabled = false;
                comboBox_scopeJ2.Enabled = false;
                comboBox_scopeJtrig.Enabled = false;
            }
        }

        private void button_scopeKshow_Click(object sender, EventArgs e)
        {
            if (button_scopeKshow.Text == "Show")
            {
                scopeK.ShowScope();
                button_scopeKshow.Text = "Hide";
                label_scopeK.Enabled = true;
                comboBox_scopeK0.Enabled = true;
                comboBox_scopeK1.Enabled = true;
                comboBox_scopeK2.Enabled = true;
                comboBox_scopeKtrig.Enabled = true;
            }
            else
            {
                scopeK.HideScope();
                button_scopeKshow.Text = "Show";
                label_scopeK.Enabled = false;
                comboBox_scopeK0.Enabled = false;
                comboBox_scopeK1.Enabled = false;
                comboBox_scopeK2.Enabled = false;
                comboBox_scopeKtrig.Enabled = false;
            }
        }

        #endregion

        #region Start/Stop log and packet error event

        private void button_startLog_Click(object sender, EventArgs e)
        {
            if (button_startLog.Text == "Start log")
            {
                try
                {
                    time = 0;
                    file = new System.IO.StreamWriter(Directory.GetCurrentDirectory() + "\\" + textBox_filename.Text + ".csv", false);
                    textBox_filename.Enabled = false;
                    button_startLog.Text = "Stop log";
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                closeFile();
            }
        }

        void daq32_packetError(object sender, EventArgs e)
        {
            if (file != null)
            {
                this.EndInvoke(this.BeginInvoke(new MethodInvoker(delegate { closeFile(); })));
                MessageBox.Show("Log stopped due to packet error");
            }
        }

        private void closeFile()
        {
            if (file != null) file.Close();
            file = null;
            textBox_filename.Enabled = true;
            button_startLog.Text = "Start log";
        }

        #endregion

    }
}