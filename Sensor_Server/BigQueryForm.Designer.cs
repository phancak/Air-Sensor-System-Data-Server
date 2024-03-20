namespace Sensor_Server
{
    partial class BigQueryForm
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
            label1 = new Label();
            textBoxKeyPath = new TextBox();
            label2 = new Label();
            textBoxProjectId = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBoxDataSetId = new TextBox();
            textBoxTemperatureTableLabel = new TextBox();
            textBoxRHTableLabel = new TextBox();
            label5 = new Label();
            label6 = new Label();
            btnBQCancel = new Button();
            btnBQConnect = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(326, 37);
            label1.TabIndex = 0;
            label1.Text = "Big Query Database Setup";
            // 
            // textBoxKeyPath
            // 
            textBoxKeyPath.Location = new Point(258, 74);
            textBoxKeyPath.Name = "textBoxKeyPath";
            textBoxKeyPath.Size = new Size(386, 23);
            textBoxKeyPath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(141, 77);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 2;
            label2.Text = "Big Query Key Path:";
            // 
            // textBoxProjectId
            // 
            textBoxProjectId.Location = new Point(258, 103);
            textBoxProjectId.Name = "textBoxProjectId";
            textBoxProjectId.Size = new Size(386, 23);
            textBoxProjectId.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(192, 106);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 4;
            label3.Text = "Project Id:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(190, 134);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 5;
            label4.Text = "Dataset Id:";
            // 
            // textBoxDataSetId
            // 
            textBoxDataSetId.Location = new Point(258, 131);
            textBoxDataSetId.Name = "textBoxDataSetId";
            textBoxDataSetId.Size = new Size(386, 23);
            textBoxDataSetId.TabIndex = 6;
            // 
            // textBoxTemperatureTableLabel
            // 
            textBoxTemperatureTableLabel.Location = new Point(258, 160);
            textBoxTemperatureTableLabel.Name = "textBoxTemperatureTableLabel";
            textBoxTemperatureTableLabel.Size = new Size(386, 23);
            textBoxTemperatureTableLabel.TabIndex = 7;
            // 
            // textBoxRHTableLabel
            // 
            textBoxRHTableLabel.Location = new Point(258, 189);
            textBoxRHTableLabel.Name = "textBoxRHTableLabel";
            textBoxRHTableLabel.Size = new Size(386, 23);
            textBoxRHTableLabel.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(115, 163);
            label5.Name = "label5";
            label5.Size = new Size(137, 15);
            label5.TabIndex = 9;
            label5.Text = "Temperature Table Label:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(117, 192);
            label6.Name = "label6";
            label6.Size = new Size(135, 15);
            label6.TabIndex = 10;
            label6.Text = "Relative Humidity Label:";
            // 
            // btnBQCancel
            // 
            btnBQCancel.Location = new Point(72, 238);
            btnBQCancel.Margin = new Padding(4, 3, 4, 3);
            btnBQCancel.Name = "btnBQCancel";
            btnBQCancel.Size = new Size(180, 31);
            btnBQCancel.TabIndex = 11;
            btnBQCancel.Text = "Cancel";
            btnBQCancel.UseVisualStyleBackColor = true;
            // 
            // btnBQConnect
            // 
            btnBQConnect.Location = new Point(258, 238);
            btnBQConnect.Margin = new Padding(4, 3, 4, 3);
            btnBQConnect.Name = "btnBQConnect";
            btnBQConnect.Size = new Size(180, 31);
            btnBQConnect.TabIndex = 12;
            btnBQConnect.Text = "Connect";
            btnBQConnect.UseVisualStyleBackColor = true;
            // 
            // BigQueryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 308);
            Controls.Add(btnBQConnect);
            Controls.Add(btnBQCancel);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(textBoxRHTableLabel);
            Controls.Add(textBoxTemperatureTableLabel);
            Controls.Add(textBoxDataSetId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBoxProjectId);
            Controls.Add(label2);
            Controls.Add(textBoxKeyPath);
            Controls.Add(label1);
            Name = "BigQueryForm";
            Text = "BigQueryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxKeyPath;
        private Label label2;
        private TextBox textBoxProjectId;
        private Label label3;
        private Label label4;
        private TextBox textBoxDataSetId;
        private TextBox textBoxTemperatureTableLabel;
        private TextBox textBoxRHTableLabel;
        private Label label5;
        private Label label6;
        private Button btnBQCancel;
        private Button btnBQConnect;
    }
}