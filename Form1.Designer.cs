namespace ScanCode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            acceuilToolStripMenuItem = new ToolStripMenuItem();
            historiqueToolStripMenuItem = new ToolStripMenuItem();
            connexionToolStripMenuItem = new ToolStripMenuItem();
            panel = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Firebrick;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { acceuilToolStripMenuItem, historiqueToolStripMenuItem, connexionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(672, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // acceuilToolStripMenuItem
            // 
            acceuilToolStripMenuItem.BackColor = Color.Gold;
            acceuilToolStripMenuItem.Name = "acceuilToolStripMenuItem";
            acceuilToolStripMenuItem.Size = new Size(58, 20);
            acceuilToolStripMenuItem.Text = "Acceuil";
            acceuilToolStripMenuItem.Click += acceuilToolStripMenuItem_Click;
            // 
            // historiqueToolStripMenuItem
            // 
            historiqueToolStripMenuItem.BackColor = Color.Gold;
            historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            historiqueToolStripMenuItem.Size = new Size(74, 20);
            historiqueToolStripMenuItem.Text = "Historique";
            historiqueToolStripMenuItem.Click += historiqueToolStripMenuItem_Click;
            // 
            // connexionToolStripMenuItem
            // 
            connexionToolStripMenuItem.BackColor = Color.Gold;
            connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            connexionToolStripMenuItem.Size = new Size(77, 20);
            connexionToolStripMenuItem.Text = "Connexion";
            connexionToolStripMenuItem.Click += connexionToolStripMenuItem_Click;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel.BackColor = SystemColors.ButtonHighlight;
            panel.Location = new Point(0, 23);
            panel.MinimumSize = new Size(668, 485);
            panel.Name = "panel";
            panel.Size = new Size(672, 499);
            panel.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(672, 522);
            Controls.Add(panel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(684, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ScanCode";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem acceuilToolStripMenuItem;
        private ToolStripMenuItem historiqueToolStripMenuItem;
        private ToolStripMenuItem connexionToolStripMenuItem;
        private Panel panel;
    }
}