namespace Sensor_Server
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Get_COM_Ports = new Button();
            listBox_COM_Ports = new ListBox();
            textBox_Console = new TextBox();
            button_Open_COM_Port = new Button();
            comboBox_Baud_Rate = new ComboBox();
            comboBox_Parity = new ComboBox();
            comboBox_Data_Bits = new ComboBox();
            comboBox_Stop_Bits = new ComboBox();
            textBox_Server_Messages = new TextBox();
            button_Send_to_Device = new Button();
            textBox_Send_to_Device = new TextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            quitToolStripMenuItem = new ToolStripMenuItem();
            sensorCommandToolStripMenuItem = new ToolStripMenuItem();
            setRTCClockToolStripMenuItem = new ToolStripMenuItem();
            getRTCClockToolStripMenuItem = new ToolStripMenuItem();
            pingDeviceToolStripMenuItem = new ToolStripMenuItem();
            getBlockFromChip1ToolStripMenuItem = new ToolStripMenuItem();
            getBlockFromChip2ToolStripMenuItem = new ToolStripMenuItem();
            getCompoToolStripMenuItem = new ToolStripMenuItem();
            getSamplingPeriodToolStripMenuItem = new ToolStripMenuItem();
            getCurrentAlarmToolStripMenuItem = new ToolStripMenuItem();
            getPointersFromChip1ToolStripMenuItem = new ToolStripMenuItem();
            getPointersFromChip2ToolStripMenuItem = new ToolStripMenuItem();
            storeOnEEPROMToolStripMenuItem = new ToolStripMenuItem();
            plotToolStripMenuItem = new ToolStripMenuItem();
            resetPlotDataToolStripMenuItem = new ToolStripMenuItem();
            databaseToolStripMenuItem = new ToolStripMenuItem();
            setUpConnectionToolStripMenuItem = new ToolStripMenuItem();
            btnSetSamplingPeriod = new Button();
            textBoxSamplingPeriod = new TextBox();
            textBoxSamplingMultiple = new TextBox();
            textBoxSamplingUnit = new TextBox();
            btnSetSamplingStart = new Button();
            btnShowTemperaturePlot = new Button();
            buttonShowRHPlot = new Button();
            btnStopSampling = new Button();
            checkBox_DatabaseLogging = new CheckBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button_Get_COM_Ports
            // 
            button_Get_COM_Ports.Location = new Point(11, 27);
            button_Get_COM_Ports.Margin = new Padding(4, 3, 4, 3);
            button_Get_COM_Ports.Name = "button_Get_COM_Ports";
            button_Get_COM_Ports.Size = new Size(180, 31);
            button_Get_COM_Ports.TabIndex = 0;
            button_Get_COM_Ports.Text = "Get COM Ports";
            button_Get_COM_Ports.UseVisualStyleBackColor = true;
            // 
            // listBox_COM_Ports
            // 
            listBox_COM_Ports.FormattingEnabled = true;
            listBox_COM_Ports.ItemHeight = 15;
            listBox_COM_Ports.Location = new Point(12, 64);
            listBox_COM_Ports.Margin = new Padding(4, 3, 4, 3);
            listBox_COM_Ports.Name = "listBox_COM_Ports";
            listBox_COM_Ports.Size = new Size(179, 94);
            listBox_COM_Ports.TabIndex = 1;
            // 
            // textBox_Console
            // 
            textBox_Console.Location = new Point(-1, 522);
            textBox_Console.Margin = new Padding(4, 3, 4, 3);
            textBox_Console.Multiline = true;
            textBox_Console.Name = "textBox_Console";
            textBox_Console.Size = new Size(1143, 131);
            textBox_Console.TabIndex = 2;
            // 
            // button_Open_COM_Port
            // 
            button_Open_COM_Port.Location = new Point(11, 177);
            button_Open_COM_Port.Margin = new Padding(4, 3, 4, 3);
            button_Open_COM_Port.Name = "button_Open_COM_Port";
            button_Open_COM_Port.Size = new Size(180, 31);
            button_Open_COM_Port.TabIndex = 3;
            button_Open_COM_Port.Text = "Open COM Port";
            button_Open_COM_Port.UseVisualStyleBackColor = true;
            // 
            // comboBox_Baud_Rate
            // 
            comboBox_Baud_Rate.FormattingEnabled = true;
            comboBox_Baud_Rate.Location = new Point(11, 215);
            comboBox_Baud_Rate.Margin = new Padding(4, 3, 4, 3);
            comboBox_Baud_Rate.Name = "comboBox_Baud_Rate";
            comboBox_Baud_Rate.Size = new Size(179, 23);
            comboBox_Baud_Rate.TabIndex = 4;
            // 
            // comboBox_Parity
            // 
            comboBox_Parity.FormattingEnabled = true;
            comboBox_Parity.Location = new Point(11, 246);
            comboBox_Parity.Margin = new Padding(4, 3, 4, 3);
            comboBox_Parity.Name = "comboBox_Parity";
            comboBox_Parity.Size = new Size(179, 23);
            comboBox_Parity.TabIndex = 5;
            // 
            // comboBox_Data_Bits
            // 
            comboBox_Data_Bits.FormattingEnabled = true;
            comboBox_Data_Bits.Location = new Point(11, 277);
            comboBox_Data_Bits.Margin = new Padding(4, 3, 4, 3);
            comboBox_Data_Bits.Name = "comboBox_Data_Bits";
            comboBox_Data_Bits.Size = new Size(179, 23);
            comboBox_Data_Bits.TabIndex = 6;
            // 
            // comboBox_Stop_Bits
            // 
            comboBox_Stop_Bits.FormattingEnabled = true;
            comboBox_Stop_Bits.Location = new Point(11, 308);
            comboBox_Stop_Bits.Margin = new Padding(4, 3, 4, 3);
            comboBox_Stop_Bits.Name = "comboBox_Stop_Bits";
            comboBox_Stop_Bits.Size = new Size(179, 23);
            comboBox_Stop_Bits.TabIndex = 7;
            // 
            // textBox_Server_Messages
            // 
            textBox_Server_Messages.Location = new Point(199, 27);
            textBox_Server_Messages.Margin = new Padding(4, 3, 4, 3);
            textBox_Server_Messages.Multiline = true;
            textBox_Server_Messages.Name = "textBox_Server_Messages";
            textBox_Server_Messages.Size = new Size(648, 489);
            textBox_Server_Messages.TabIndex = 8;
            // 
            // button_Send_to_Device
            // 
            button_Send_to_Device.Location = new Point(855, 57);
            button_Send_to_Device.Margin = new Padding(4, 3, 4, 3);
            button_Send_to_Device.Name = "button_Send_to_Device";
            button_Send_to_Device.Size = new Size(180, 31);
            button_Send_to_Device.TabIndex = 9;
            button_Send_to_Device.Text = "Send to Device";
            button_Send_to_Device.UseVisualStyleBackColor = true;
            // 
            // textBox_Send_to_Device
            // 
            textBox_Send_to_Device.Location = new Point(855, 27);
            textBox_Send_to_Device.Margin = new Padding(4, 3, 4, 3);
            textBox_Send_to_Device.Name = "textBox_Send_to_Device";
            textBox_Send_to_Device.Size = new Size(179, 23);
            textBox_Send_to_Device.TabIndex = 10;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, sensorCommandToolStripMenuItem, plotToolStripMenuItem, databaseToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1050, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(97, 22);
            quitToolStripMenuItem.Text = "Quit";
            // 
            // sensorCommandToolStripMenuItem
            // 
            sensorCommandToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setRTCClockToolStripMenuItem, getRTCClockToolStripMenuItem, pingDeviceToolStripMenuItem, getBlockFromChip1ToolStripMenuItem, getBlockFromChip2ToolStripMenuItem, getCompoToolStripMenuItem, getSamplingPeriodToolStripMenuItem, getCurrentAlarmToolStripMenuItem, getPointersFromChip1ToolStripMenuItem, getPointersFromChip2ToolStripMenuItem, storeOnEEPROMToolStripMenuItem });
            sensorCommandToolStripMenuItem.Name = "sensorCommandToolStripMenuItem";
            sensorCommandToolStripMenuItem.Size = new Size(114, 20);
            sensorCommandToolStripMenuItem.Text = "Sensor Command";
            // 
            // setRTCClockToolStripMenuItem
            // 
            setRTCClockToolStripMenuItem.Name = "setRTCClockToolStripMenuItem";
            setRTCClockToolStripMenuItem.Size = new Size(201, 22);
            setRTCClockToolStripMenuItem.Text = "Set RTC Clock";
            // 
            // getRTCClockToolStripMenuItem
            // 
            getRTCClockToolStripMenuItem.Name = "getRTCClockToolStripMenuItem";
            getRTCClockToolStripMenuItem.Size = new Size(201, 22);
            getRTCClockToolStripMenuItem.Text = "Get RTC Clock";
            // 
            // pingDeviceToolStripMenuItem
            // 
            pingDeviceToolStripMenuItem.Name = "pingDeviceToolStripMenuItem";
            pingDeviceToolStripMenuItem.Size = new Size(201, 22);
            pingDeviceToolStripMenuItem.Text = "Ping Device";
            // 
            // getBlockFromChip1ToolStripMenuItem
            // 
            getBlockFromChip1ToolStripMenuItem.Name = "getBlockFromChip1ToolStripMenuItem";
            getBlockFromChip1ToolStripMenuItem.Size = new Size(201, 22);
            getBlockFromChip1ToolStripMenuItem.Text = "Get Block from Chip1";
            // 
            // getBlockFromChip2ToolStripMenuItem
            // 
            getBlockFromChip2ToolStripMenuItem.Name = "getBlockFromChip2ToolStripMenuItem";
            getBlockFromChip2ToolStripMenuItem.Size = new Size(201, 22);
            getBlockFromChip2ToolStripMenuItem.Text = "Get Block from Chip2";
            // 
            // getCompoToolStripMenuItem
            // 
            getCompoToolStripMenuItem.Name = "getCompoToolStripMenuItem";
            getCompoToolStripMenuItem.Size = new Size(201, 22);
            getCompoToolStripMenuItem.Text = "Get Component Info";
            // 
            // getSamplingPeriodToolStripMenuItem
            // 
            getSamplingPeriodToolStripMenuItem.Name = "getSamplingPeriodToolStripMenuItem";
            getSamplingPeriodToolStripMenuItem.Size = new Size(201, 22);
            getSamplingPeriodToolStripMenuItem.Text = "Get Sampling Period";
            // 
            // getCurrentAlarmToolStripMenuItem
            // 
            getCurrentAlarmToolStripMenuItem.Name = "getCurrentAlarmToolStripMenuItem";
            getCurrentAlarmToolStripMenuItem.Size = new Size(201, 22);
            getCurrentAlarmToolStripMenuItem.Text = "Get Current Alarm";
            // 
            // getPointersFromChip1ToolStripMenuItem
            // 
            getPointersFromChip1ToolStripMenuItem.Name = "getPointersFromChip1ToolStripMenuItem";
            getPointersFromChip1ToolStripMenuItem.Size = new Size(201, 22);
            getPointersFromChip1ToolStripMenuItem.Text = "Get Pointers from Chip1";
            // 
            // getPointersFromChip2ToolStripMenuItem
            // 
            getPointersFromChip2ToolStripMenuItem.Name = "getPointersFromChip2ToolStripMenuItem";
            getPointersFromChip2ToolStripMenuItem.Size = new Size(201, 22);
            getPointersFromChip2ToolStripMenuItem.Text = "Get Pointers from Chip2";
            // 
            // storeOnEEPROMToolStripMenuItem
            // 
            storeOnEEPROMToolStripMenuItem.Name = "storeOnEEPROMToolStripMenuItem";
            storeOnEEPROMToolStripMenuItem.Size = new Size(201, 22);
            storeOnEEPROMToolStripMenuItem.Text = "Store on EEPROM";
            // 
            // plotToolStripMenuItem
            // 
            plotToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetPlotDataToolStripMenuItem });
            plotToolStripMenuItem.Name = "plotToolStripMenuItem";
            plotToolStripMenuItem.Size = new Size(40, 20);
            plotToolStripMenuItem.Text = "Plot";
            // 
            // resetPlotDataToolStripMenuItem
            // 
            resetPlotDataToolStripMenuItem.Name = "resetPlotDataToolStripMenuItem";
            resetPlotDataToolStripMenuItem.Size = new Size(153, 22);
            resetPlotDataToolStripMenuItem.Text = "Reset Plot Data";
            // 
            // databaseToolStripMenuItem
            // 
            databaseToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setUpConnectionToolStripMenuItem });
            databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            databaseToolStripMenuItem.Size = new Size(67, 20);
            databaseToolStripMenuItem.Text = "Database";
            // 
            // setUpConnectionToolStripMenuItem
            // 
            setUpConnectionToolStripMenuItem.Name = "setUpConnectionToolStripMenuItem";
            setUpConnectionToolStripMenuItem.Size = new Size(180, 22);
            setUpConnectionToolStripMenuItem.Text = "Set Up Connection";
            // 
            // btnSetSamplingPeriod
            // 
            btnSetSamplingPeriod.Location = new Point(855, 123);
            btnSetSamplingPeriod.Margin = new Padding(4, 3, 4, 3);
            btnSetSamplingPeriod.Name = "btnSetSamplingPeriod";
            btnSetSamplingPeriod.Size = new Size(180, 31);
            btnSetSamplingPeriod.TabIndex = 14;
            btnSetSamplingPeriod.Text = "Set Sampling Period";
            btnSetSamplingPeriod.UseVisualStyleBackColor = true;
            // 
            // textBoxSamplingPeriod
            // 
            textBoxSamplingPeriod.Location = new Point(855, 94);
            textBoxSamplingPeriod.Margin = new Padding(4, 3, 4, 3);
            textBoxSamplingPeriod.Name = "textBoxSamplingPeriod";
            textBoxSamplingPeriod.Size = new Size(179, 23);
            textBoxSamplingPeriod.TabIndex = 15;
            // 
            // textBoxSamplingMultiple
            // 
            textBoxSamplingMultiple.Location = new Point(855, 160);
            textBoxSamplingMultiple.Margin = new Padding(4, 3, 4, 3);
            textBoxSamplingMultiple.Name = "textBoxSamplingMultiple";
            textBoxSamplingMultiple.Size = new Size(77, 23);
            textBoxSamplingMultiple.TabIndex = 16;
            // 
            // textBoxSamplingUnit
            // 
            textBoxSamplingUnit.Location = new Point(957, 160);
            textBoxSamplingUnit.Margin = new Padding(4, 3, 4, 3);
            textBoxSamplingUnit.Name = "textBoxSamplingUnit";
            textBoxSamplingUnit.Size = new Size(77, 23);
            textBoxSamplingUnit.TabIndex = 17;
            // 
            // btnSetSamplingStart
            // 
            btnSetSamplingStart.Location = new Point(855, 189);
            btnSetSamplingStart.Margin = new Padding(4, 3, 4, 3);
            btnSetSamplingStart.Name = "btnSetSamplingStart";
            btnSetSamplingStart.Size = new Size(180, 31);
            btnSetSamplingStart.TabIndex = 18;
            btnSetSamplingStart.Text = "Set Sampling Start";
            btnSetSamplingStart.UseVisualStyleBackColor = true;
            // 
            // btnShowTemperaturePlot
            // 
            btnShowTemperaturePlot.Location = new Point(855, 485);
            btnShowTemperaturePlot.Margin = new Padding(4, 3, 4, 3);
            btnShowTemperaturePlot.Name = "btnShowTemperaturePlot";
            btnShowTemperaturePlot.Size = new Size(180, 31);
            btnShowTemperaturePlot.TabIndex = 19;
            btnShowTemperaturePlot.Text = "Show Temperature Plot";
            btnShowTemperaturePlot.UseVisualStyleBackColor = true;
            // 
            // buttonShowRHPlot
            // 
            buttonShowRHPlot.Location = new Point(855, 448);
            buttonShowRHPlot.Margin = new Padding(4, 3, 4, 3);
            buttonShowRHPlot.Name = "buttonShowRHPlot";
            buttonShowRHPlot.Size = new Size(180, 31);
            buttonShowRHPlot.TabIndex = 20;
            buttonShowRHPlot.Text = "Show RH Plot";
            buttonShowRHPlot.UseVisualStyleBackColor = true;
            // 
            // btnStopSampling
            // 
            btnStopSampling.BackColor = SystemColors.ControlDark;
            btnStopSampling.Location = new Point(855, 226);
            btnStopSampling.Margin = new Padding(4, 3, 4, 3);
            btnStopSampling.Name = "btnStopSampling";
            btnStopSampling.Size = new Size(180, 31);
            btnStopSampling.TabIndex = 21;
            btnStopSampling.Text = "Stop Sampling";
            btnStopSampling.UseVisualStyleBackColor = false;
            // 
            // checkBox_DatabaseLogging
            // 
            checkBox_DatabaseLogging.AutoSize = true;
            checkBox_DatabaseLogging.Location = new Point(865, 263);
            checkBox_DatabaseLogging.Name = "checkBox_DatabaseLogging";
            checkBox_DatabaseLogging.Size = new Size(163, 19);
            checkBox_DatabaseLogging.TabIndex = 22;
            checkBox_DatabaseLogging.Text = "Transmit Data to Database";
            checkBox_DatabaseLogging.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 652);
            Controls.Add(checkBox_DatabaseLogging);
            Controls.Add(btnStopSampling);
            Controls.Add(buttonShowRHPlot);
            Controls.Add(btnShowTemperaturePlot);
            Controls.Add(btnSetSamplingStart);
            Controls.Add(textBoxSamplingUnit);
            Controls.Add(textBoxSamplingMultiple);
            Controls.Add(textBoxSamplingPeriod);
            Controls.Add(btnSetSamplingPeriod);
            Controls.Add(textBox_Send_to_Device);
            Controls.Add(button_Send_to_Device);
            Controls.Add(textBox_Server_Messages);
            Controls.Add(comboBox_Stop_Bits);
            Controls.Add(comboBox_Data_Bits);
            Controls.Add(comboBox_Parity);
            Controls.Add(comboBox_Baud_Rate);
            Controls.Add(button_Open_COM_Port);
            Controls.Add(textBox_Console);
            Controls.Add(listBox_COM_Ports);
            Controls.Add(button_Get_COM_Ports);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Data_Server";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_Get_COM_Ports;
        private System.Windows.Forms.ListBox listBox_COM_Ports;
        private System.Windows.Forms.TextBox textBox_Console;
        private System.Windows.Forms.Button button_Open_COM_Port;
        private System.Windows.Forms.ComboBox comboBox_Baud_Rate;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.ComboBox comboBox_Data_Bits;
        private System.Windows.Forms.ComboBox comboBox_Stop_Bits;
        private System.Windows.Forms.TextBox textBox_Server_Messages;
        private System.Windows.Forms.Button button_Send_to_Device;
        private System.Windows.Forms.TextBox textBox_Send_to_Device;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem sensorCommandToolStripMenuItem;
        private ToolStripMenuItem setRTCClockToolStripMenuItem;
        private ToolStripMenuItem getRTCClockToolStripMenuItem;
        private ToolStripMenuItem pingDeviceToolStripMenuItem;
        private ToolStripMenuItem getBlockFromChip1ToolStripMenuItem;
        private ToolStripMenuItem getBlockFromChip2ToolStripMenuItem;
        private ToolStripMenuItem getCompoToolStripMenuItem;
        private ToolStripMenuItem getSamplingPeriodToolStripMenuItem;
        private Button btnSetSamplingPeriod;
        private TextBox textBoxSamplingPeriod;
        private TextBox textBoxSamplingMultiple;
        private TextBox textBoxSamplingUnit;
        private Button btnSetSamplingStart;
        private ToolStripMenuItem getCurrentAlarmToolStripMenuItem;
        private Button btnShowTemperaturePlot;
        private Button buttonShowRHPlot;
        private Button btnStopSampling;
        private ToolStripMenuItem plotToolStripMenuItem;
        private ToolStripMenuItem resetPlotDataToolStripMenuItem;
        private ToolStripMenuItem getPointersFromChip1ToolStripMenuItem;
        private ToolStripMenuItem getPointersFromChip2ToolStripMenuItem;
        private ToolStripMenuItem storeOnEEPROMToolStripMenuItem;
        private ToolStripMenuItem databaseToolStripMenuItem;
        private ToolStripMenuItem setUpConnectionToolStripMenuItem;
        private CheckBox checkBox_DatabaseLogging;
    }
}
