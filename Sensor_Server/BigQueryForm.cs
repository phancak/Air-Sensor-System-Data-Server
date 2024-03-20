using Mysqlx.Crud;
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
    public partial class BigQueryForm : Form
    {
        public delegate void CallBackMethodDelegate(string jsonKeyPath, string projectId, string datasetId,
            string temperatureTableId, string relativeHumidityTableId);

        public BigQueryForm()
        {
            InitializeComponent();

            //Initialize text box data
            textBoxKeyPath.Text = "C:/Users/pehan/OneDrive/Documents/Programming/GitHub/project-keys/polished-signer-412800-ec9db9dbce32.json";
            textBoxProjectId.Text = "polished-signer-412800";
            textBoxDataSetId.Text = "Sensor_Data";
            textBoxTemperatureTableLabel.Text = "Temperature";
            textBoxRHTableLabel.Text = "Relative_Humidity";
        }

        public void CreateConnection(CallBackMethodDelegate callBackMethod)
        {
            callBackMethod?.Invoke(textBoxKeyPath.Text, textBoxProjectId.Text, textBoxDataSetId.Text,
                textBoxTemperatureTableLabel.Text, textBoxRHTableLabel.Text);
        }
    }
}
