using ScottPlot;
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
    public partial class FormTemperaturePlot : Form
    {
        public FormTemperaturePlot(double[] xValDateTime, double[] yValTemperature)
        {
            InitializeComponent();

            formsPlotTemperature.Plot.XAxis.DateTimeFormat(true);
            formsPlotTemperature.Plot.AddScatter(xValDateTime, yValTemperature);
        }

        public void RefreshTemperaturePlot()
        {
            // reset limits to fit the data
            formsPlotTemperature.Plot.AxisAuto();

            formsPlotTemperature.Refresh();
        }
    }
}
