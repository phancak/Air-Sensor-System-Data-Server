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
        private Button _buttonShowRHPlot;

        public FormRHDataPlot(double[] xValDateTime, double[] yValRH, Button buttonShowRHPlot)
        {
            _buttonShowRHPlot = buttonShowRHPlot;
            _buttonShowRHPlot.Enabled = false; //Disable the show relative humidity plot button
            InitializeComponent();

            formsPlotRH.Plot.XAxis.DateTimeFormat(true);
            formsPlotRH.Plot.AddScatter(xValDateTime, yValRH);
        }

        public void RefreshRHPlot()
        {
            //Gets a value indicating whether the caller must call an invoke method when making method calls to the control because the caller is on a different thread than the one the control was created on.
            if (this.InvokeRequired)
            {
                //Invoke - Executes a delegate on the thread that owns the control's underlying window handle.
                this.Invoke((Action)(() =>
                {
                    // reset limits to fit the data
                    this.formsPlotRH.Plot.AxisAuto();
                    this.formsPlotRH.Refresh();
                }));
            }
            else
            {
                // reset limits to fit the data
                formsPlotRH.Plot.AxisAuto();
                formsPlotRH.Refresh();
            }
        }
    }
}
