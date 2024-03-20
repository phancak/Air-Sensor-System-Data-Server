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
        private static FormTemperaturePlot _formTemperaturePlot;
        Button _btnShowTemperaturePlot;

        private static readonly object LockObject = new object(); //Only one thread can acquire the lock at a time

        public FormTemperaturePlot(double[] xValDateTime, double[] yValTemperature, Button btnShowTemperaturePlot)
        {
            _btnShowTemperaturePlot = btnShowTemperaturePlot;
            _btnShowTemperaturePlot.Enabled = false;
            InitializeComponent();

            formsPlotTemperature.Plot.XAxis.DateTimeFormat(true);
            formsPlotTemperature.Plot.AddScatter(xValDateTime, yValTemperature);
        }

        public static FormTemperaturePlot Instance(double[] xValDateTime, double[] yValTemperature, Button btnShowTemperaturePlot)
        {
            //Check is perfomed before entering the lock. To avoid locking if an instance has already been created.
            if (_formTemperaturePlot == null)
            {
                //Locks statement takes care of acquiring and releasing the lock so only one thread can execute at a time
                lock (LockObject)
                {
                    //Ensures that only one thread with the lock creates the instance
                    if (_formTemperaturePlot == null)
                    {
                        _formTemperaturePlot = new FormTemperaturePlot(xValDateTime, yValTemperature, btnShowTemperaturePlot);
                    }
                }
            }


            return _formTemperaturePlot;
        }

        public void RefreshTemperaturePlot()
        {
            //Gets a value indicating whether the caller must call an invoke method when making method calls to the control because the caller is on a different thread than the one the control was created on.
            if (this.InvokeRequired)
            {
                //Invoke - Executes a delegate on the thread that owns the control's underlying window handle.
                this.Invoke((Action)(() =>
                {
                    // reset limits to fit the data
                    formsPlotTemperature.Plot.AxisAuto();
                    formsPlotTemperature.Refresh();
                }));
            }
            else
            {
                // reset limits to fit the data
                formsPlotTemperature.Plot.AxisAuto();
                formsPlotTemperature.Refresh();
            }
        }

        private void FormTemperaturePlot_Load(object sender, EventArgs e)
        {

        }
    }
}
