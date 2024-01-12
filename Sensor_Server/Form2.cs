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
    public partial class FormRHDataPlot : Form
    {
        public FormRHDataPlot(double[] xValDateTime, double[] yValRH)
        {
            InitializeComponent();

            formsPlotRH.Plot.XAxis.DateTimeFormat(true);
            formsPlotRH.Plot.AddScatter(xValDateTime, yValRH);
        }

        public void RefreshRHPlot()
        {
            // reset limits to fit the data
            formsPlotRH.Plot.AxisAuto();

            formsPlotRH.Refresh();
        }
    }
}
