namespace Sensor_Server
{
    partial class FormRHDataPlot
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
            formsPlotRH = new ScottPlot.FormsPlot();
            SuspendLayout();
            // 
            // formsPlotRH
            // 
            formsPlotRH.AccessibleRole = AccessibleRole.None;
            formsPlotRH.Location = new Point(13, 12);
            formsPlotRH.Margin = new Padding(4, 3, 4, 3);
            formsPlotRH.Name = "formsPlotRH";
            formsPlotRH.Size = new Size(774, 426);
            formsPlotRH.TabIndex = 0;
            // 
            // FormRHDataPlot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(formsPlotRH);
            Name = "FormRHDataPlot";
            Text = "Relative Humidity Plot";
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlotRH;
    }
}