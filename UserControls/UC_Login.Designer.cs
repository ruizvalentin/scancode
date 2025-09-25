namespace ScanCode.UserControls
{
    partial class UC_Login
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            tb_username = new TextBox();
            tb_mdp = new TextBox();
            button1 = new Button();
            pb_logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pb_logo).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 144);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "Nom d'utilisateur";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 236);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 1;
            label2.Text = "Mot de passe";
            // 
            // tb_username
            // 
            tb_username.Location = new Point(236, 162);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(202, 23);
            tb_username.TabIndex = 2;
            // 
            // tb_mdp
            // 
            tb_mdp.Location = new Point(236, 254);
            tb_mdp.Name = "tb_mdp";
            tb_mdp.PasswordChar = '*';
            tb_mdp.Size = new Size(202, 23);
            tb_mdp.TabIndex = 3;
            tb_mdp.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.BackColor = Color.Firebrick;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(294, 300);
            button1.Name = "button1";
            button1.Size = new Size(80, 28);
            button1.TabIndex = 4;
            button1.Text = "Connexion";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pb_logo
            // 
            pb_logo.Location = new Point(8, 10);
            pb_logo.Margin = new Padding(2);
            pb_logo.Name = "pb_logo";
            pb_logo.Size = new Size(50, 50);
            pb_logo.TabIndex = 14;
            pb_logo.TabStop = false;
            // 
            // UC_Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pb_logo);
            Controls.Add(button1);
            Controls.Add(tb_mdp);
            Controls.Add(tb_username);
            Controls.Add(label2);
            Controls.Add(label1);
            MinimumSize = new Size(668, 485);
            Name = "UC_Login";
            Size = new Size(668, 485);
            Load += UC_Login_Load;
            Resize += UC_Login_Resize;
            ((System.ComponentModel.ISupportInitialize)pb_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_username;
        private TextBox tb_mdp;
        private Button button1;
        private PictureBox pb_logo;
    }
}
