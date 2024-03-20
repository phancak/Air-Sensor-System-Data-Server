using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensor_Server
{
    public partial class EEPROMStoreMessageForm : Form
    {
        private const int msg_size = 14; //Constant message size from device in bytes
        MessageStruct messageStruct;
        ToolStripMenuItem storeOnEEPROMToolStripMenuItem;
        Form1 form1; //Calling object

        public EEPROMStoreMessageForm(MessageStruct messageStruct, ToolStripMenuItem storeOnEEPROMToolStripMenuItem, Form1 form1)
        {
            this.messageStruct = messageStruct;
            this.storeOnEEPROMToolStripMenuItem = storeOnEEPROMToolStripMenuItem;
            this.form1 = form1;

            InitializeComponent();
            IntializeMessageByteTextBoxes(); //Intializes the message byte text boxes to zero

            //Intialize buttons
            btnCancelMessage.Click += new EventHandler(ButtonHandler);
            btnSendEEPROMMessage.Click += new EventHandler(ButtonHandler);

            //Initialize chip selector
            chipSelectComboBox.Items.Add("Chip 1");
            chipSelectComboBox.Items.Add("Chip 2");

            //Initialize feedback message
            dataMessageLabel.Text = "";

            storeOnEEPROMToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Sets initial values of zero for each of the message byte text boxes
        /// </summary>
        private void IntializeMessageByteTextBoxes()
        {
            messageByteTextBox1.Text = "0";
            messageByteTextBox2.Text = "0";
            messageByteTextBox3.Text = "0";
            messageByteTextBox4.Text = "0";
            messageByteTextBox5.Text = "0";
            messageByteTextBox6.Text = "0";
            messageByteTextBox7.Text = "0";
            messageByteTextBox8.Text = "0";
            messageByteTextBox9.Text = "0";
            messageByteTextBox10.Text = "0";
            messageByteTextBox11.Text = "0";
            messageByteTextBox12.Text = "0";
            messageByteTextBox13.Text = "0";
        }

        private void ButtonHandler(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnCancelMessage":
                    storeOnEEPROMToolStripMenuItem.Enabled = true; //Reenable menu item
                    this.Dispose(true);
                    break;
                case "btnSendEEPROMMessage":
                    if (MessageFieldsValid()) {
                        storeOnEEPROMToolStripMenuItem.Enabled = true; //Reenable menu item

                        //Determines the target EERPOM chip
                        if (this.chipSelectComboBox.SelectedIndex == 0)
                            this.messageStruct.message[0] = 0x0F; //Message label (to be stored on chip 1)
                        else
                            this.messageStruct.message[0] = 0x10; //Message label (to be stored on chip 2)

                        //Collects the message bytes
                        this.messageStruct.message[1] = Int32.Parse(messageByteTextBox1.Text);
                        this.messageStruct.message[2] = Int32.Parse(messageByteTextBox2.Text);
                        this.messageStruct.message[3] = Int32.Parse(messageByteTextBox3.Text);
                        this.messageStruct.message[4] = Int32.Parse(messageByteTextBox4.Text);
                        this.messageStruct.message[5] = Int32.Parse(messageByteTextBox5.Text);
                        this.messageStruct.message[6] = Int32.Parse(messageByteTextBox6.Text);
                        this.messageStruct.message[7] = Int32.Parse(messageByteTextBox7.Text);
                        this.messageStruct.message[8] = Int32.Parse(messageByteTextBox8.Text);
                        this.messageStruct.message[9] = Int32.Parse(messageByteTextBox9.Text);
                        this.messageStruct.message[10] = Int32.Parse(messageByteTextBox10.Text);
                        this.messageStruct.message[11] = Int32.Parse(messageByteTextBox11.Text);
                        this.messageStruct.message[12] = Int32.Parse(messageByteTextBox12.Text);
                        this.messageStruct.message[13] = Int32.Parse(messageByteTextBox13.Text);

                        //Enable menu item
                        storeOnEEPROMToolStripMenuItem.Enabled = true;

                        //Add the message to transmission queue
                        form1.SensorTXMessageProducer(this.messageStruct);
                    } else
                    {
                        //Display message feedback
                        dataMessageLabel.Text = "Invalid data. Values must be below 256.";
                    }
                    break;
            }
        }

        /// <summary>
        /// Determines validity of message fields based on maximum size of uint8_t and combo box selection
        /// </summary>
        /// <returns>true if all fields are valid</returns>
        private Boolean MessageFieldsValid()
        {
            try
            {
                if (chipSelectComboBox.SelectedIndex == -1)
                {
                    //No items selected
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox1.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox2.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox3.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox4.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox5.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox6.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox7.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox8.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox9.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox10.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox11.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox12.Text) > 255)
                {
                    return false;
                }

                //Checks for text in text box
                if (Int32.Parse(messageByteTextBox13.Text) > 255)
                {
                    return false;
                }
            } catch (FormatException e)
            {
                return false; //Invalid format
            }

            return true;
        }
    }
}
