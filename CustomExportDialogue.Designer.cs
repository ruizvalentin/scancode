namespace ScanCode
{
    partial class CustomExportDialogue
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
            lblMessage = new Label();
            btnExportToPdf = new Button();
            btnExportToExcel = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMessage.Location = new Point(76, 26);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(240, 16);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Choisissez le format d'exportation :";
            // 
            // btnExportToPdf
            // 
            btnExportToPdf.BackColor = Color.Firebrick;
            btnExportToPdf.ForeColor = SystemColors.ButtonHighlight;
            btnExportToPdf.Location = new Point(26, 95);
            btnExportToPdf.Name = "btnExportToPdf";
            btnExportToPdf.Size = new Size(151, 35);
            btnExportToPdf.TabIndex = 1;
            btnExportToPdf.Text = "button1";
            btnExportToPdf.UseVisualStyleBackColor = false;
            btnExportToPdf.Click += btnExportToPdf_Click;
            // 
            // btnExportToExcel
            // 
            btnExportToExcel.BackColor = Color.SeaGreen;
            btnExportToExcel.ForeColor = SystemColors.ButtonHighlight;
            btnExportToExcel.Location = new Point(196, 95);
            btnExportToExcel.Name = "btnExportToExcel";
            btnExportToExcel.Size = new Size(151, 35);
            btnExportToExcel.TabIndex = 2;
            btnExportToExcel.Text = "button2";
            btnExportToExcel.UseVisualStyleBackColor = false;
            btnExportToExcel.Click += btnExportToExcel_Click;
            // 
            // CustomExportDialogue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 149);
            Controls.Add(btnExportToExcel);
            Controls.Add(btnExportToPdf);
            Controls.Add(lblMessage);
            MaximumSize = new Size(396, 188);
            MinimumSize = new Size(396, 188);
            Name = "CustomExportDialogue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Exportation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label lblMessage;
        public Button btnExportToPdf;
        public Button btnExportToExcel;
    }
}