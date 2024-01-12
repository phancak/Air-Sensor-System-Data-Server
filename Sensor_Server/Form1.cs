using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading.Channels;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

//System.IO.Ports - Sorced from Project/Manage NuGet Packages/Browser/Search for System.IO.Ports

namespace Sensor_Server
{
    public partial class Form1 : Form
    {
        //Searil Port parameters
        public string[] COM_Port_Array = null; //Array that holds the available COM ports
        public string[] COM_Baude_Rate_List = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200", "128000", "256000" };
        public string[] COM_Parity_List = { "None", "Even", "Mark", "Space", "Odd" };
        public string[] COM_Data_Bit_List = { "7", "8", "9" };
        public string[] COM_Stop_Bit_List = { "1", "1.5", "2" };

        //Communication variables
        private SerialPort serialPort;
        private Stream baseStream; //Need using System.IO for Stream
        private const int msg_size = 14; //Constant message size from device in bytes
        private int[] buffer = new int[msg_size];

        //Message task queues
        private Channel<MessageStruct> receiveSensorMessageChannel = Channel.CreateUnbounded<MessageStruct>();
        private Channel<MessageStruct> databaseChannel = Channel.CreateUnbounded<MessageStruct>();
        private Channel<MessageStruct> sensorTransmitChannel = Channel.CreateUnbounded<MessageStruct>();

        //Device component constants
        private int EEPROMChip1Address = 0x01; //Device uses this address for EEPROM chip 1
        private int EEPROMChip2Address = 0x02; //Device uses this address for EEPROM chip 2

        //Semaphore directing the use of serial port
        SemaphoreSlim semaphore = new SemaphoreSlim(1);

        //Plot Data
        public const int dataPlotPoints = 200; //Plot will show this number of data points
        public double[] xValDateTime = new double[dataPlotPoints];
        public double[] yValRH = new double[dataPlotPoints];
        public double[] yValTemperature = new double[dataPlotPoints];
        public int collectedFirstDataPointFlag = 1; //Remains one only for the first data point

        //Plot forms
        FormTemperaturePlot formTemperaturePlot;
        FormRHDataPlot formRHDataPlot;

        public Form1()
        {
            //intialize form
            InitializeComponent();
            InitializeUserInterface();

            //Program start notification
            SendToConsoleTextBox("Program Start");

            //Start message consumers
            StartSensorRXMessageConsumer(); //Starts processing of messages received from the device
            StartSensorTXMessageConsumer(); //Starts processing of messages to be transmitted to the device

            //Initlialize data plot forms
            formTemperaturePlot = new FormTemperaturePlot(xValDateTime, yValTemperature);
            formRHDataPlot = new FormRHDataPlot(xValDateTime, yValRH);
        }

        //Initialize User Interface
        private void InitializeUserInterface()
        {
            comboBox_Baud_Rate.Items.AddRange(COM_Baude_Rate_List);
            comboBox_Baud_Rate.SelectedIndex = 6; //Default Baude rate selection
            comboBox_Parity.Items.AddRange(COM_Parity_List);
            comboBox_Parity.SelectedIndex = 0; //Default parity selection (None)
            comboBox_Data_Bits.Items.AddRange(COM_Data_Bit_List);
            comboBox_Data_Bits.SelectedIndex = 1;
            comboBox_Stop_Bits.Items.AddRange(COM_Stop_Bit_List);
            comboBox_Stop_Bits.SelectedIndex = 0;

            //Disable buttons and combo boxes
            button_Open_COM_Port.Enabled = false; //Disable the button until COM port is selcted from the list
            comboBox_Baud_Rate.Enabled = false;
            comboBox_Parity.Enabled = false;
            comboBox_Data_Bits.Enabled = false;
            comboBox_Stop_Bits.Enabled = false;
            button_Send_to_Device.Enabled = false;

            button_Get_COM_Ports.Click += new EventHandler(BtnGetCOMPortsClick);
            button_Open_COM_Port.Click += new EventHandler(BtnOpenCOMPortClick);
            button_Send_to_Device.Click += new EventHandler(BtnSendToDeviceClick);
            listBox_COM_Ports.SelectedValueChanged += new EventHandler(ListBoxCOMPortsSelection);
            setRTCClockToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            getRTCClockToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            pingDeviceToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            getBlockFromChip1ToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            getBlockFromChip2ToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            getCompoToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            btnSetSamplingPeriod.Click += new EventHandler(ButtonHandler);
            getSamplingPeriodToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            btnSetSamplingStart.Click += new EventHandler(ButtonHandler);
            getCurrentAlarmToolStripMenuItem.Click += new EventHandler(CommandMenuHandler);
            btnShowTemperaturePlot.Click += new EventHandler(ButtonHandler);
            buttonShowRHPlot.Click += new EventHandler(ButtonHandler);
            btnStopSampling.Click += new EventHandler(ButtonHandler);
        }

        /// <summary>
        /// Writes the label value into the provided message struct object at the specified term number
        /// </summary>
        /// <param name="messageStruct">Message container</param>
        /// <param name="label">Inserted value</param>
        /// <param name="termNumber">Term number where the value is inserted</param>
        /// <returns></returns>
        private MessageStruct LabelMessage(MessageStruct messageStruct, int label, int termNumber)
        {
            //Label message type (message label recognized by device)
            messageStruct.message[termNumber] = label;

            return messageStruct;
        }

        //Handler for server menu sensor commands
        private void CommandMenuHandler(object sender, EventArgs e)
        {
            SendToConsoleTextBox("Command selected, sender: " + ((ToolStripMenuItem)sender).Name + " EventArgs: " + e.ToString());

            MessageStruct messageStruct = new MessageStruct(msg_size); //Message prototype

            switch (((ToolStripMenuItem)sender).Name)
            {
                case "setRTCClockToolStripMenuItem":
                    SendToConsoleTextBox("setRTCClockToolStripMenuItem selected");
                    SensorTXMessageProducer(LabelMessage(AddCurrentDateTime(messageStruct), 'b', 0));
                    break;
                case "getRTCClockToolStripMenuItem":
                    SendToConsoleTextBox("getRTCClockToolStripMenuItem selected");
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'c', 0));
                    break;
                case "pingDeviceToolStripMenuItem":
                    SendToConsoleTextBox("pingDeviceToolStripMenuItem selected");
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'o', 0));
                    break;
                case "getBlockFromChip1ToolStripMenuItem":
                    SendToConsoleTextBox("getBlockFromChip1ToolStripMenuItem selected");
                    LabelMessage(messageStruct, EEPROMChip1Address, 1);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 0x01, 0));
                    break;
                case "getBlockFromChip2ToolStripMenuItem":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    LabelMessage(messageStruct, EEPROMChip2Address, 1);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 0x02, 0));
                    break;
                case "getCompoToolStripMenuItem":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'e', 0));
                    break;
                case "getSamplingPeriodToolStripMenuItem":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'h', 0));
                    break;
                case "getCurrentAlarmToolStripMenuItem":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'l', 0));
                    break;
            }
        }

        //Handler for buttons
        private void ButtonHandler(object sender, EventArgs e)
        {
            SendToConsoleTextBox("Button selected, sender: " + ((Button)sender).Name + " EventArgs: " + e.ToString());

            MessageStruct messageStruct = new MessageStruct(msg_size); //Message prototype

            switch (((Button)sender).Name)
            {
                case "btnSetSamplingPeriod":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    AddMessagePeriod(messageStruct, textBoxSamplingPeriod); //--------exceptions
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'g', 0));
                    break;
                case "btnSetSamplingStart":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    AddSamplingMultipleToMessage(messageStruct, textBoxSamplingMultiple, textBoxSamplingUnit);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'j', 0));
                    break;
                case "btnShowTemperaturePlot":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    //FormRHDataPlot formRHDataPlot = new FormRHDataPlot(xValDateTime, yValRH);
                    formRHDataPlot.Show();
                    break;
                case "buttonShowRHPlot":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    //FormTemperaturePlot formTemperaturePlot = new FormTemperaturePlot(xValDateTime, yValTemperature);
                    formTemperaturePlot.Show();
                    break;
                case "btnStopSampling":
                    SendToConsoleTextBox(sender.ToString + " selected " + e.ToString);
                    SensorTXMessageProducer(LabelMessage(messageStruct, 'n', 0));
                    break;
            }
        }

        /// <summary>
        /// FIFO adds a new data point to plot arrays
        /// </summary>
        /// <param name="xValue">X value array</param>
        /// <param name="RHArray">Realtive humidity data array</param>
        /// <param name="temperatureArray">Temperature data array</param>
        /// <param name="dateTime">New date time value</param>
        /// <param name="RHPoint">New relative humidity value</param>
        /// <param name="temperaturePoint">New temperature value</param>
        private void InsertDataPoint(double[] xValue, double[] RHArray, double[] temperatureArray, double dateTime, double RHPoint, double temperaturePoint)
        {
            for (int i= xValue.Length-1; i > 0; i--)
            {
                //Move array by one data point
                xValue[i] = xValue[i-1];
                RHArray[i] = RHArray[i-1];
                temperatureArray[i] = temperatureArray[i - 1];
            }

            //Add new data point
            xValue[0] = dateTime;
            RHArray[0] = RHPoint;
            temperatureArray[0] = temperaturePoint;

            //Checks if this is the first data point
            if (collectedFirstDataPointFlag == 1)
            {
                //Fixes the data arrays so they look correct on the plot (all intial data equal the first data point)
                for (int i = 1; i < xValue.Length; i++)
                {
                    xValue[i] = xValue[0];
                    RHArray[i] = RHArray[0];
                    temperatureArray[i] = temperatureArray[0];
                }

                collectedFirstDataPointFlag = 0;
            }
        }

        /// <summary>
        /// Adds sampling multiple (Time multiple at which sampling will start) and tiem unit (sec, min, hr).
        /// </summary>
        /// <param name="messageStruct">Target message</param>
        /// <param name="textBox1">Sampling multiple source textBox</param>
        /// <param name="textBox2">Time unit source textBox</param>
        /// <returns></returns>
        private int AddSamplingMultipleToMessage(MessageStruct messageStruct, TextBox textBox1, TextBox textBox2)
        {
            int samplingMultiple = 0;
            int unit = 0; //0:seconds, 1:minutes, 2:hours

            //Convert supplied sampling period to int
            try
            {
                samplingMultiple = int.Parse(textBox1.Text);
                unit = int.Parse(textBox2.Text);
            }
            catch (FormatException e)
            {
                SendToConsoleTextBox("Invalid sampling period format.");
                return 0;
            }
            catch (OverflowException e)
            {
                SendToConsoleTextBox("Overflow occured during sampling period conversion.");
                return 0;
            }

            messageStruct.message[1] = (samplingMultiple);
            messageStruct.message[2] = (unit);

            return 1;
        }

        /// <summary>
        /// Adds sampling period to a specified message from a specified textBox. The sampling period should be in seconds.
        /// </summary>
        /// <param name="messageStruct">Target message</param>
        /// <param name="textBox">Source of sampling period</param>
        private int AddMessagePeriod(MessageStruct messageStruct, TextBox textBox)
        {
            int samplingPeriod = 0; 

            //Convert supplied sampling period to int
            try
            {
                samplingPeriod = int.Parse(textBox.Text);
            } catch (FormatException e)
            {
                SendToConsoleTextBox("Invalid sampling period format.");
                return 0;
            } catch (OverflowException e)
            {
                SendToConsoleTextBox("Overflow occured during sampling period conversion.");
                return 0;
            }

            for (int i = 0; i < 4; i++)
            {
                messageStruct.message[i + 1] = ((samplingPeriod) >> (i*8)) & 0x000000FF;
            }

            return 1;

        }

        //Coverts message struct into string
        private string GetMessageString(MessageStruct messageStruct, int msg_size)
        {
            string msgStrg = string.Empty;

            //Message number components
            for(int i=0; i < msg_size;i++)
            {
                msgStrg += ($"{messageStruct.message[i]:X2}-");
            }

            return msgStrg;
        }

        //Producer for meesages to be transmitted to the sensor device
        private async void SensorTXMessageProducer(MessageStruct messageStruct)
        {
            await sensorTransmitChannel.Writer.WriteAsync(messageStruct);

            SendToTextBoxServerMessages("Added message to sensor transmit channel: " + GetMessageString(messageStruct, msg_size)); //Displays the received message
        }

        //Processes messages to be tranmitted to the sensor device (from sensorTransmitChannel)
        private async void StartSensorTXMessageConsumer()
        {
            //Task runs asynchronously
            await Task.Run(async () =>
            {
                try
                {
                    await foreach (var item in sensorTransmitChannel.Reader.ReadAllAsync())
                    {
                        SendToTextBoxServerMessages("Consumed device TX message: " + GetMessageString(item, msg_size)); //Displays the received message
                        BaseStreamController(0, item, msg_size); //Transmist message through serial port to the devic
                    }
                }
                catch (ChannelClosedException ex)
                {
                    SendToConsoleTextBox("ChannelClosedException: " + ex.Message);
                    SendToConsoleTextBox("Consumer Complete.");
                }
            });
        }

        //Processes received messages from sensor device (receiveSensorMessageChannel consumer)
        private async void StartSensorRXMessageConsumer()
        {
            //Task runs asynchronously
            await Task.Run(async () =>
            {
                try
                {
                    await foreach (var item in receiveSensorMessageChannel.Reader.ReadAllAsync())
                    {
                        SendToTextBoxServerMessages("Consumed sensor RX message: " + GetMessageString(item, msg_size)); //Displays the received message
                        ProcessMessage(item);
                    }
                }
                catch (ChannelClosedException ex)
                {
                    SendToConsoleTextBox("ChannelClosedException: " + ex.Message);
                    SendToConsoleTextBox("Consumer Complete.");
                }
            });
        }

        private void BtnSendToDeviceClick(object sender, EventArgs e)
        {
            //Wait for receive buffer to be empty before sending data

            string commmand = textBox_Send_to_Device.Text;

            SendToConsoleTextBox("button_Send_to_Device: " + sender.ToString());
            SendToConsoleTextBox("Serail Port Write: " + commmand);
            //serialPort.WriteLine(textBox2.Text);
            serialPort.Write(commmand);
        }

        //When a COM port is selected in the COM port list
        private void ListBoxCOMPortsSelection(object sender, EventArgs e)
        {
            SendToConsoleTextBox(sender.ToString() + ", " + e.ToString());

            //Enable buttons and combo boxes
            button_Open_COM_Port.Enabled = true; //Disable the button until COM port is selcted from the list
            comboBox_Baud_Rate.Enabled = true;
            comboBox_Parity.Enabled = true;
            comboBox_Data_Bits.Enabled = true;
            comboBox_Stop_Bits.Enabled = true;
            button_Send_to_Device.Enabled = true;
        }

        private void BtnOpenCOMPortClick(object sender, EventArgs e)
        {
            SendToConsoleTextBox(sender.ToString() + ", " + e.ToString());

            //COM Port Parameters
            string COM_name = (string)listBox_COM_Ports.SelectedItem;
            int COM_Baud_Rate = int.Parse((string)comboBox_Baud_Rate.SelectedItem);
            int COM_Data_Bits = int.Parse((string)comboBox_Data_Bits.SelectedItem);

            Parity parity = Parity.None;
            switch (comboBox_Parity.SelectedIndex)
            {
                case 0:
                    parity = Parity.None;
                    break;
                case 1:
                    parity = Parity.Even;
                    break;
                case 2:
                    parity = Parity.Mark;
                    break;
                case 3:
                    parity = Parity.Space;
                    break;
                case 4:
                    parity = Parity.Odd;
                    break;
            }

            StopBits stopBits = StopBits.One;
            switch (comboBox_Parity.SelectedIndex)
            {
                case 0:
                    stopBits = StopBits.One;
                    break;
                case 1:
                    stopBits = StopBits.OnePointFive;
                    break;
                case 2:
                    stopBits = StopBits.Two;
                    break;
            }

            //Create serial port
            try
            {
                serialPort = new SerialPort(COM_name, COM_Baud_Rate, parity, COM_Data_Bits, stopBits);

                // Set the read/write timeouts
                serialPort.ReadTimeout = 500;
                serialPort.WriteTimeout = 500;
            }
            catch (System.IO.IOException ex)
            {
                SendToConsoleTextBox("COM Port failed to open: " + ex.Message);
            }

            //Open Serial Port
            try
            {
                serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error openning COM port: (ex.Message)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //Add receive event listener
            if (serialPort.IsOpen)
            {
                serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
                baseStream = serialPort.BaseStream;
                baseStream.ReadTimeout = (2000); //Throws Timeout exception if no more bytes to read are received
                SendToConsoleTextBox(COM_name + " Port is open");
            }
        }

        private MessageStruct AddCurrentDateTime(MessageStruct messageStruct)
        {
            DateTime dateTime = DateTime.Now; //Gets current date and time
            uint bsdDate = ConvertDateToBCD(dateTime); //Converts to BCD format for RTC_DR register
            uint bcdTime = ConvertTimeToBCD(dateTime); //Converts to BCD format for RTC_TR register

            //Populate the message
            messageStruct.message[1] = (int)((bcdTime) & ~0xFFFFFF00);
            messageStruct.message[2] = (int)((bcdTime >> 8) & ~0xFFFFFF00);
            messageStruct.message[3] = (int)((bcdTime >> 16) & ~0xFFFFFF00);
            messageStruct.message[4] = (int)((bcdTime >> 24) & ~0xFFFFFF00);
            messageStruct.message[5] = (int)(bsdDate & ~0xFFFFFF00);
            messageStruct.message[6] = (int)((bsdDate >> 8) & ~0xFFFFFF00);
            messageStruct.message[7] = (int)((bsdDate >> 16) & ~0xFFFFFF00);
            messageStruct.message[8] = (int)((bsdDate >> 24) & ~0xFFFFFF00);

            return messageStruct;
        }

        /// <summary>
        /// Controls the usage of base stream for transmission and reception using semaphores
        /// </summary>
        /// <param name="direction">Intended usage. 0: Transmission, 1: Reception</param>
        /// <param name="messageStruct">Message to be transmitted</param>
        /// <param name="messageLength">Message length in bytes</param>
        private async void BaseStreamController(int direction, MessageStruct messageStruct, int messageLength)
        {
            //Serial port bese stream can only be used by one thread at a time
            await semaphore.WaitAsync();

            //Transmission direction
            if (direction == 0)
            {
                int byteCount = 0;

                //Transmits bytes through serial port
                while (byteCount < messageLength)
                {
                    try
                    {
                        baseStream.WriteByte((byte)messageStruct.message[byteCount]);
                    }
                    catch (TimeoutException ex)
                    {
                        SendToConsoleTextBox("TimeoutException: " + ex.ToString());
                    }

                    byteCount++;
                }
            } else if(direction == 1)
            {
                //MessageStruct messegaStructReceived = new MessageStruct(msg_size); //Message prototype to be transmitted to device
                int byteCount = 0;

                while (byteCount < msg_size)
                {
                    try
                    {
                        messageStruct.message[byteCount] = baseStream.ReadByte();
                    }
                    catch (TimeoutException ex)
                    {
                        SendToConsoleTextBox("TimeoutException: " + ex.ToString());
                    }

                    byteCount++;
                }

                await receiveSensorMessageChannel.Writer.WriteAsync(messageStruct); //Writes the message to the receive sensor message channel
            }

            semaphore.Release();

            SendToTextBoxServerMessages(((direction == 0) ? "Transmitted message" : "Received message") + GetMessageString(messageStruct, msg_size)); //Displays the received message


        }

        //Handler for when new data omn serial port are detected
        private async void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            MessageStruct messageStruct = new MessageStruct(msg_size); //Container for message

            BaseStreamController(1, messageStruct, msg_size); //Receives message
        }

        private void ProcessMessage(MessageStruct messageStruct)
        {
            if (messageStruct.message[13] == 0)
            {
                switch (messageStruct.message[0])
                {
                    case 'a':
                        //Device sent sensor data message
                        process_sensor_message(messageStruct);
                        break;
                    case 'd':
                        //Device sent current RTC clock data
                        SendToTextBoxServerMessages("Device sent RCT clock: " + ConvertBCDToDateTime(messageStruct).ToString()); //Displays the received message
                        break;
                    case 'p':
                        //Device sent ping response
                        SendToTextBoxServerMessages("Device responded to Ping: " + GetMessageString(messageStruct, msg_size)); //Displays the received message
                        break;
                    case 0x02:
                        //Device notification that there is no unprocessed message in the EEPROM specified chip
                        SendToTextBoxServerMessages("Device notification that there is no unprocessed message in the EEPROM chip, address: " + messageStruct.message[1]); //Displays the received message
                        break;
                    case 0x03:
                        //Device sent unprocessed message from EEPROM chip
                        SendToTextBoxServerMessages("Received FIFO message from chip address: " + messageStruct.message[2] + " ,Message: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 0x05:
                        //Device sent confirmation of RTC clock set request 
                        SendToTextBoxServerMessages("Device sent confirmation of RTC clock set request: " + messageStruct.message[2] + " ,Message: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 0x06:
                        //Device sent EEPROM chip serial number
                        SendToTextBoxServerMessages("Device sent EEPROM chip serial number ,Message: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 0x07:
                        //Device notified that sampling period message has been received
                        SendToTextBoxServerMessages("Device notified that sampling period message has been received ,Message: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 0x08:
                        //Device notified that set first alarm message has been received
                        SendToTextBoxServerMessages("Device notified that set first alarm message has been received.");
                        break;
                    case 0x09:
                        //Device notified that sampling has stopped
                        SendToTextBoxServerMessages("Device notified that sampling has stopped.");
                        break;
                    case 'f':
                        //Device sent MCU serail number
                        SendToTextBoxServerMessages("Device sent MCU serail number: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 'i':
                        //Device sent the current sampling period (seconds)
                        int samplingPeriod = (messageStruct.message[1] << 0) | (messageStruct.message[2] << 8) | (messageStruct.message[3] << 16) | (messageStruct.message[4] << 24);
                        SendToTextBoxServerMessages("Device sent the current sampling period (seconds): " + samplingPeriod);
                        break;
                    case 'k':
                        //Device notified that sampling period has not been set
                        SendToTextBoxServerMessages("Device notified that sampling period has not been set ,Message: " + GetMessageString(messageStruct, msg_size));
                        break;
                    case 'm':
                        //Device notified of the current alarm
                        SendToTextBoxServerMessages("Device notified of the current alarm: " + GetAlarmTimeString(messageStruct));
                        SendToTextBoxServerMessages("The alarm mask: " + GetAlarmMaskString(messageStruct));
                        break;
                    default:
                        //Received unknown message type
                        SendToTextBoxServerMessages("Received unknown message type.");
                        break;
                }
            }
            else if (messageStruct.message[13] == 0) //Message came from EEPROM chip
            {
            }
        }

        private void process_sensor_message(MessageStruct messageStruct)
        {
            //Generate DateTime variable
            DateTime dateTime = ConvertBCDToDateTime(messageStruct);
            double dateTimeOADate;

            //Extract sensor data
            uint RH_data = (uint)messageStruct.message[9] | (uint)(messageStruct.message[10] << 8); //16 bit number
            uint temperature_data = (uint)messageStruct.message[11] | (uint)(messageStruct.message[12] << 8); //16 bit number

            //Relative humidity data
            double RH_value = RH_data / 10.0;

            //Temperature Data
            double temperature_value = 0;
            if ((temperature_data >> 15) == 1) //Bit 15 being one indicates negative
            {
                temperature_value = (temperature_data & (~(1 << 15))) / 10.0 * (-1);
            }
            else
            {
                temperature_value = (temperature_data) / 10.0;
            }

            //Convert DateTime
            try
            {
                dateTimeOADate = dateTime.ToOADate();

                //Adds new data point to the plot data arrays
                InsertDataPoint(xValDateTime, yValRH, yValTemperature, dateTimeOADate, RH_value, temperature_value);

                //Refresh plot forms after new data collected
                formRHDataPlot.RefreshRHPlot();
                formTemperaturePlot.RefreshTemperaturePlot();
            } catch (OverflowException e)
            {
                SendToConsoleTextBox("Date time failed, " + e.Message);
            }

            //Display data
            SendToTextBoxServerMessages("Received data at: " + dateTime.ToLongDateString() + "' " + dateTime.ToLongTimeString() +
                ", humidity: " + RH_value + ", temperature: " + temperature_value);
        }

        private void BtnGetCOMPortsClick(object sender, EventArgs e)
        {
            SendToConsoleTextBox(sender.ToString() + ", " + e.ToString());

            //Get list of available COM ports
            try
            {
                COM_Port_Array = SerialPort.GetPortNames();
            }
            catch (Win32Exception ex)
            {
                SendToConsoleTextBox(ex.Message);
            }

            //Display the COM ports in listBox_COM_Ports
            listBox_COM_Ports.Items.AddRange(COM_Port_Array);
        }

        private void SendToTextBoxServerMessages(string s)
        {
            //Gets a value indicating whether the caller must call an invoke method when making method calls to the control because the caller is on a different thread than the one the control was created on.
            if (this.InvokeRequired)
            {
                //Invoke - Executes a delegate on the thread that owns the control's underlying window handle.
                this.Invoke((Action)(() =>
                {
                    textBox_Server_Messages.AppendText("> " + s + Environment.NewLine);
                }));
            }
            else
            {
                textBox_Server_Messages.AppendText("> " + s + Environment.NewLine);
            }
        }

        private void SendToConsoleTextBox(string s)
        {
            //Gets a value indicating whether the caller must call an invoke method when making method calls to the control because the caller is on a different thread than the one the control was created on.
            if (this.InvokeRequired)
            {
                //Invoke - Executes a delegate on the thread that owns the control's underlying window handle.
                this.Invoke((Action)(() =>
                {
                    textBox_Console.AppendText("> " + s + Environment.NewLine);
                }));
            }
            else
            {
                textBox_Console.AppendText("> " + s + Environment.NewLine);
            }
        }

        uint ConvertDateToBCD(DateTime dateTime)
        {
            uint bcdDate = 0; //System.UInt32

            int year = dateTime.Year % 100; //Uses only tens and units
            int month = dateTime.Month;
            DayOfWeek dayOfWeek = dateTime.DayOfWeek;
            int day = dateTime.Day;

            uint yearTens = (uint)(year / 10);
            uint yearUnits = (uint)(year % 10);
            uint weekDay = (uint)(((int)dayOfWeek == 0) ? 7 : (int)dayOfWeek); //Monday 1, Sunday 111
            uint mothTens = (uint)(month / 10);
            uint mothUnits = (uint)(month % 10);
            uint dateTens = (uint)(day / 10);
            uint dateUnits = (uint)(day % 10);

            //Format for RTC date register (RTC_DR)
            bcdDate = (yearTens << 20) | (yearUnits << 16) | (weekDay << 13) | (mothTens << 12) | (mothUnits << 8) | (dateTens << 4) | (dateUnits);

            return bcdDate;
        }

        uint ConvertTimeToBCD(DateTime dateTime)
        {
            uint bcdTime = 0;

            int hour = dateTime.Hour; //The value of the Hour property is always expressed using a 24-hour clock.
            int minute = dateTime.Minute;
            int second = dateTime.Second;

            uint hourTens = (uint)(hour / 10);
            uint hourUnits = (uint)(hour % 10);
            uint minuteTens = (uint)(minute / 10);
            uint minuteUnits = (uint)(minute % 10);
            uint secondTens = (uint)(second / 10);
            uint secondUnits = (uint)(second % 10);

            //Format for RTC time register (RTC_TR)
            bcdTime = (hourTens << 20) | (hourUnits << 16) | (minuteTens << 12) | (minuteUnits << 8) | (secondTens << 4) | (secondUnits << 0);

            return bcdTime;
        }

        /// <summary>
        /// Returns the current alarm mask (The time units that are don't care)
        /// </summary>
        /// <param name="messageStruct">Traget message container</param>
        /// <returns>Mask string (hour:minute:second)</returns>
        private string GetAlarmMaskString(MessageStruct messageStruct)
        {
            //Processes device message container
            uint bcdTime = (uint)messageStruct.message[1] | (uint)(messageStruct.message[2] << 8) | (uint)(messageStruct.message[3] << 16) | (uint)(messageStruct.message[4] << 24);

            //Alarm mask parameters
            int maskDate = (int)((bcdTime >> 30) & 0x01);
            int maskWeekDay = (int)((bcdTime >> 31) & 0x01);
            int maskSeconds = (int)((bcdTime >> 7) & 0x01);
            int maskMinutes = (int)((bcdTime >> 15) & 0x01);
            int maskHours = (int)((bcdTime >> 23) & 0x01);

            //Generates time string
            string alarmMaskString = "Date mask: " + maskDate + "week day mask: " + maskWeekDay + "hour mask: " + maskHours + " minutes mask: " + maskMinutes + " seconds mask: " + maskSeconds;

            return alarmMaskString;
        }

        /// <summary>
        /// Returns the current alarm hour:minute:second in string format
        /// </summary>
        /// <param name="messageStruct">Traget message container</param>
        /// <returns>Time string (hour:minute:second)</returns>
        private string GetAlarmTimeString(MessageStruct messageStruct)
        {
            //Processes device message container
            uint bcdTime = (uint)messageStruct.message[1] | (uint)(messageStruct.message[2] << 8) | (uint)(messageStruct.message[3] << 16) | (uint)(messageStruct.message[4] << 24);

            //Parses alarm data into hours, minutes,and seconds
            int hour = (int)((bcdTime >> 20) & 0x03) * 10 + (int)((bcdTime >> 16) & 0x0F);
            int minute = (int)((bcdTime >> 12) & 0x07) * 10 + (int)((bcdTime >> 8) & 0x0F);
            int second = (int)((bcdTime >> 4) & 0x07) * 10 + (int)((bcdTime >> 0) & 0x0F);

            //Alarm mask parameters
            int maskSeconds = (int)((bcdTime >> 7) & 0x01);
            int maskMinutes = (int)((bcdTime >> 15) & 0x01);
            int maskHours = (int)((bcdTime >> 23) & 0x01);

            //Generates time string
            string alarmTimeString = hour + ":" + minute + ":" + second;

            return alarmTimeString;
        }

        DateTime ConvertBCDToDateTime(MessageStruct messageStruct)
        {
            DateTime dateTime;

            //Extract date and time from the message
            uint bcdTime = (uint)messageStruct.message[1] | (uint)(messageStruct.message[2] << 8) | (uint)(messageStruct.message[3] << 16) | (uint)(messageStruct.message[4] << 24);
            uint bcdDate = (uint)messageStruct.message[5] | (uint)(messageStruct.message[6] << 8) | (uint)(messageStruct.message[7] << 16) | (uint)(messageStruct.message[8] << 24);

            int year = (int)(bcdDate >> 20) * 10 + (int)((bcdDate >> 16) & 0x0F) + 2000;
            int month = (int)((bcdDate >> 12) & 0x01) * 10 + (int)((bcdDate >> 8) & 0x0F);
            int day = (int)((bcdDate >> 4) & 0x03) * 10 + (int)((bcdDate >> 0) & 0x0F);
            int hour = (int)((bcdTime >> 20) & 0x03) * 10 + (int)((bcdTime >> 16) & 0x0F);
            int minute = (int)((bcdTime >> 12) & 0x07) * 10 + (int)((bcdTime >> 8) & 0x0F);
            int second = (int)((bcdTime >> 4) & 0x07) * 10 + (int)((bcdTime >> 0) & 0x0F);

            dateTime = new DateTime(year, month, day, hour, minute, second);

            return dateTime;
        }

        private void button_Get_Device_Clock_Click(object sender, EventArgs e)
        {
            //RequestRTCClock(); //Requests current RCT clock from the device (real time clock)
        }
    }
}
