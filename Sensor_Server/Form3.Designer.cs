namespace Sensor_Server
{
    partial class FormTemperaturePlot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            _btnShowTemperaturePlot.Enabled = true;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            formsPlotTemperature = new ScottPlot.FormsPlot();
            SuspendLayout();
            // 
            // formsPlotTemperature
            // 
            formsPlotTemperature.Location = new Point(13, 12);
            formsPlotTemperature.Margin = new Padding(4, 3, 4, 3);
            formsPlotTemperature.Name = "formsPlotTemperature";
            formsPlotTemperature.Size = new Size(774, 426);
            formsPlotTemperature.TabIndex = 0;
            // 
            // FormTemperaturePlot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(formsPlotTemperature);
            Name = "FormTemperaturePlot";
            Text = "Temperature Data Plot";
            Load += FormTemperaturePlot_Load;
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlotTemperature;
    }
}