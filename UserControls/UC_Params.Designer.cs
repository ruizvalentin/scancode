namespace ScanCode.UserControls
{
    partial class UC_Params
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
            tabControl1 = new TabControl();
            UserAdmin = new TabPage();
            label1 = new Label();
            button5 = new Button();
            label15 = new Label();
            button2 = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            Supprimer = new Button();
            comboBox1 = new ComboBox();
            btn_add_admin = new Button();
            tb_password = new TextBox();
            tb_username = new TextBox();
            UserScan = new TabPage();
            comboBox2 = new ComboBox();
            label16 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            button3 = new Button();
            rb_non = new RadioButton();
            rb_oui = new RadioButton();
            dtp_DateScan = new DateTimePicker();
            n_identificationNumber = new NumericUpDown();
            tb_LastName = new TextBox();
            tb_FirstName = new TextBox();
            ParamsPage = new TabPage();
            btn_save_backup = new Button();
            btn_save_dailybackup = new Button();
            tb_backup = new TextBox();
            label14 = new Label();
            tb_dailybackup = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            button4 = new Button();
            tb_oldBackup = new TextBox();
            tb_nextBackup = new TextBox();
            n_backupDayBefore = new NumericUpDown();
            tabControl1.SuspendLayout();
            UserAdmin.SuspendLayout();
            UserScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)n_identificationNumber).BeginInit();
            ParamsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)n_backupDayBefore).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(UserAdmin);
            tabControl1.Controls.Add(UserScan);
            tabControl1.Controls.Add(ParamsPage);
            tabControl1.Location = new Point(21, 15);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(622, 454);
            tabControl1.TabIndex = 0;
            // 
            // UserAdmin
            // 
            UserAdmin.Controls.Add(label1);
            UserAdmin.Controls.Add(button5);
            UserAdmin.Controls.Add(label15);
            UserAdmin.Controls.Add(button2);
            UserAdmin.Controls.Add(label4);
            UserAdmin.Controls.Add(label3);
            UserAdmin.Controls.Add(label2);
            UserAdmin.Controls.Add(Supprimer);
            UserAdmin.Controls.Add(comboBox1);
            UserAdmin.Controls.Add(btn_add_admin);
            UserAdmin.Controls.Add(tb_password);
            UserAdmin.Controls.Add(tb_username);
            UserAdmin.Location = new Point(4, 24);
            UserAdmin.Name = "UserAdmin";
            UserAdmin.Padding = new Padding(3);
            UserAdmin.Size = new Size(614, 426);
            UserAdmin.TabIndex = 0;
            UserAdmin.Text = "Compte Admin";
            UserAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(72, 25);
            label1.Name = "label1";
            label1.Size = new Size(476, 18);
            label1.TabIndex = 5;
            label1.Text = "Cette page permet la création de nouveau profil administrateur";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.ButtonHighlight;
            button5.Location = new Point(405, 347);
            button5.Name = "button5";
            button5.Size = new Size(86, 29);
            button5.TabIndex = 11;
            button5.Text = "Télécharger";
            button5.UseVisualStyleBackColor = false;
            button5.Click += btn_dwn_audit_Click;
            // 
            // label15
            // 
            label15.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(27, 350);
            label15.Name = "label15";
            label15.Size = new Size(352, 18);
            label15.TabIndex = 10;
            label15.Text = "Télécharger l'audit trail des scans de barcode :";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.Location = new Point(115, 231);
            button2.Name = "button2";
            button2.Size = new Size(86, 29);
            button2.TabIndex = 9;
            button2.Text = "Rafraichir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btn_refresh_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Verdana", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(129, 184);
            label4.Name = "label4";
            label4.Size = new Size(362, 18);
            label4.TabIndex = 8;
            label4.Text = "Selectionner le profil administrateur à supprimer";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Sitka Subheading", 11.249999F, FontStyle.Italic, GraphicsUnit.Point);
            label3.Location = new Point(285, 68);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 7;
            label3.Text = "mot de passe";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Sitka Subheading", 11.249999F, FontStyle.Italic, GraphicsUnit.Point);
            label2.Location = new Point(115, 68);
            label2.Name = "label2";
            label2.Size = new Size(77, 21);
            label2.TabIndex = 6;
            label2.Text = "Identifiant";
            // 
            // Supprimer
            // 
            Supprimer.Location = new Point(405, 234);
            Supprimer.Name = "Supprimer";
            Supprimer.Size = new Size(86, 29);
            Supprimer.TabIndex = 4;
            Supprimer.Text = "Supprimer";
            Supprimer.UseVisualStyleBackColor = true;
            Supprimer.Click += Supprimer_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(214, 235);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(175, 23);
            comboBox1.TabIndex = 3;
            // 
            // btn_add_admin
            // 
            btn_add_admin.BackColor = Color.White;
            btn_add_admin.BackgroundImageLayout = ImageLayout.None;
            btn_add_admin.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            btn_add_admin.Location = new Point(441, 88);
            btn_add_admin.Name = "btn_add_admin";
            btn_add_admin.Size = new Size(86, 29);
            btn_add_admin.TabIndex = 2;
            btn_add_admin.Text = "Ajouter";
            btn_add_admin.UseVisualStyleBackColor = false;
            btn_add_admin.Click += btn_add_admin_Click;
            // 
            // tb_password
            // 
            tb_password.BackColor = SystemColors.HighlightText;
            tb_password.Location = new Point(253, 92);
            tb_password.Name = "tb_password";
            tb_password.Size = new Size(144, 23);
            tb_password.TabIndex = 1;
            // 
            // tb_username
            // 
            tb_username.BackColor = SystemColors.HighlightText;
            tb_username.Location = new Point(72, 92);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(149, 23);
            tb_username.TabIndex = 0;
            // 
            // UserScan
            // 
            UserScan.Controls.Add(comboBox2);
            UserScan.Controls.Add(label16);
            UserScan.Controls.Add(label9);
            UserScan.Controls.Add(label8);
            UserScan.Controls.Add(label7);
            UserScan.Controls.Add(label6);
            UserScan.Controls.Add(label5);
            UserScan.Controls.Add(button3);
            UserScan.Controls.Add(rb_non);
            UserScan.Controls.Add(rb_oui);
            UserScan.Controls.Add(dtp_DateScan);
            UserScan.Controls.Add(n_identificationNumber);
            UserScan.Controls.Add(tb_LastName);
            UserScan.Controls.Add(tb_FirstName);
            UserScan.Location = new Point(4, 24);
            UserScan.Name = "UserScan";
            UserScan.Padding = new Padding(3);
            UserScan.Size = new Size(614, 426);
            UserScan.TabIndex = 1;
            UserScan.Text = "Ajout de scan";
            UserScan.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "VALIDE", "EXPIRÉ" });
            comboBox2.Location = new Point(244, 231);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(199, 23);
            comboBox2.TabIndex = 13;
            // 
            // label16
            // 
            label16.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(94, 226);
            label16.Name = "label16";
            label16.Size = new Size(123, 24);
            label16.TabIndex = 12;
            label16.Text = "Certificat médical :";
            label16.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(118, 274);
            label9.Name = "label9";
            label9.Size = new Size(95, 17);
            label9.TabIndex = 11;
            label9.Text = "Licence valide :";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(123, 178);
            label8.Name = "label8";
            label8.Size = new Size(91, 17);
            label8.TabIndex = 10;
            label8.Text = "Date du scan :";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(142, 124);
            label7.Name = "label7";
            label7.Size = new Size(72, 17);
            label7.TabIndex = 9;
            label7.Text = "Identifiant :";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(153, 74);
            label6.Name = "label6";
            label6.Size = new Size(60, 17);
            label6.TabIndex = 8;
            label6.Text = "Prenom :";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(169, 24);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 7;
            label5.Text = "Nom :";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Location = new Point(279, 342);
            button3.Name = "button3";
            button3.Size = new Size(95, 32);
            button3.TabIndex = 6;
            button3.Text = "Ajouter";
            button3.UseVisualStyleBackColor = true;
            button3.Click += btn_add_scan_Click;
            // 
            // rb_non
            // 
            rb_non.AutoSize = true;
            rb_non.Location = new Point(349, 276);
            rb_non.Name = "rb_non";
            rb_non.Size = new Size(48, 19);
            rb_non.TabIndex = 5;
            rb_non.Text = "Non";
            rb_non.UseVisualStyleBackColor = true;
            // 
            // rb_oui
            // 
            rb_oui.AutoSize = true;
            rb_oui.Checked = true;
            rb_oui.Location = new Point(289, 276);
            rb_oui.Name = "rb_oui";
            rb_oui.Size = new Size(44, 19);
            rb_oui.TabIndex = 4;
            rb_oui.TabStop = true;
            rb_oui.Text = "Oui";
            rb_oui.UseVisualStyleBackColor = true;
            // 
            // dtp_DateScan
            // 
            dtp_DateScan.Location = new Point(243, 178);
            dtp_DateScan.Name = "dtp_DateScan";
            dtp_DateScan.Size = new Size(200, 23);
            dtp_DateScan.TabIndex = 3;
            // 
            // n_identificationNumber
            // 
            n_identificationNumber.Location = new Point(244, 122);
            n_identificationNumber.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            n_identificationNumber.Name = "n_identificationNumber";
            n_identificationNumber.Size = new Size(199, 23);
            n_identificationNumber.TabIndex = 2;
            // 
            // tb_LastName
            // 
            tb_LastName.Location = new Point(243, 73);
            tb_LastName.Name = "tb_LastName";
            tb_LastName.Size = new Size(200, 23);
            tb_LastName.TabIndex = 1;
            // 
            // tb_FirstName
            // 
            tb_FirstName.Location = new Point(243, 24);
            tb_FirstName.Name = "tb_FirstName";
            tb_FirstName.Size = new Size(200, 23);
            tb_FirstName.TabIndex = 0;
            // 
            // ParamsPage
            // 
            ParamsPage.Controls.Add(btn_save_backup);
            ParamsPage.Controls.Add(btn_save_dailybackup);
            ParamsPage.Controls.Add(tb_backup);
            ParamsPage.Controls.Add(label14);
            ParamsPage.Controls.Add(tb_dailybackup);
            ParamsPage.Controls.Add(label13);
            ParamsPage.Controls.Add(label12);
            ParamsPage.Controls.Add(label11);
            ParamsPage.Controls.Add(label10);
            ParamsPage.Controls.Add(button4);
            ParamsPage.Controls.Add(tb_oldBackup);
            ParamsPage.Controls.Add(tb_nextBackup);
            ParamsPage.Controls.Add(n_backupDayBefore);
            ParamsPage.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ParamsPage.Location = new Point(4, 24);
            ParamsPage.Name = "ParamsPage";
            ParamsPage.Padding = new Padding(3);
            ParamsPage.Size = new Size(614, 426);
            ParamsPage.TabIndex = 2;
            ParamsPage.Text = "Paramètres";
            ParamsPage.UseVisualStyleBackColor = true;
            // 
            // btn_save_backup
            // 
            btn_save_backup.Location = new Point(407, 277);
            btn_save_backup.Name = "btn_save_backup";
            btn_save_backup.Size = new Size(98, 25);
            btn_save_backup.TabIndex = 19;
            btn_save_backup.Text = "Sauvegarder";
            btn_save_backup.UseVisualStyleBackColor = true;
            btn_save_backup.Click += btn_save_backup_Click;
            // 
            // btn_save_dailybackup
            // 
            btn_save_dailybackup.Location = new Point(99, 277);
            btn_save_dailybackup.Name = "btn_save_dailybackup";
            btn_save_dailybackup.Size = new Size(104, 25);
            btn_save_dailybackup.TabIndex = 18;
            btn_save_dailybackup.Text = "Sauvegarder";
            btn_save_dailybackup.UseVisualStyleBackColor = true;
            btn_save_dailybackup.Click += btn_save_dailybackup_Click;
            // 
            // tb_backup
            // 
            tb_backup.Location = new Point(320, 246);
            tb_backup.Name = "tb_backup";
            tb_backup.Size = new Size(270, 25);
            tb_backup.TabIndex = 17;
            // 
            // label14
            // 
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(391, 217);
            label14.Name = "label14";
            label14.Size = new Size(141, 15);
            label14.TabIndex = 16;
            label14.Text = "Lien des backup standard";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_dailybackup
            // 
            tb_dailybackup.Location = new Point(24, 246);
            tb_dailybackup.Name = "tb_dailybackup";
            tb_dailybackup.Size = new Size(270, 25);
            tb_dailybackup.TabIndex = 15;
            // 
            // label13
            // 
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(81, 217);
            label13.Name = "label13";
            label13.Size = new Size(156, 15);
            label13.TabIndex = 14;
            label13.Text = "Lien des backup journalières";
            label13.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(267, 91);
            label12.Name = "label12";
            label12.Size = new Size(153, 15);
            label12.TabIndex = 13;
            label12.Text = "Date de la dernière backup :";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(257, 53);
            label11.Name = "label11";
            label11.Size = new Size(163, 15);
            label11.TabIndex = 12;
            label11.Text = "Date de la prochaine backup :";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(14, 53);
            label10.Name = "label10";
            label10.Size = new Size(211, 15);
            label10.TabIndex = 11;
            label10.Text = "Nombre de jour entre chaque backup :";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Location = new Point(69, 112);
            button4.Name = "button4";
            button4.Size = new Size(87, 27);
            button4.TabIndex = 3;
            button4.Text = "Appliquer";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // tb_oldBackup
            // 
            tb_oldBackup.Location = new Point(426, 91);
            tb_oldBackup.Name = "tb_oldBackup";
            tb_oldBackup.ReadOnly = true;
            tb_oldBackup.Size = new Size(163, 25);
            tb_oldBackup.TabIndex = 2;
            // 
            // tb_nextBackup
            // 
            tb_nextBackup.Location = new Point(426, 48);
            tb_nextBackup.Name = "tb_nextBackup";
            tb_nextBackup.ReadOnly = true;
            tb_nextBackup.Size = new Size(163, 25);
            tb_nextBackup.TabIndex = 1;
            // 
            // n_backupDayBefore
            // 
            n_backupDayBefore.Location = new Point(38, 81);
            n_backupDayBefore.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            n_backupDayBefore.Name = "n_backupDayBefore";
            n_backupDayBefore.Size = new Size(161, 25);
            n_backupDayBefore.TabIndex = 0;
            n_backupDayBefore.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // UC_Params
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            MinimumSize = new Size(668, 485);
            Name = "UC_Params";
            Size = new Size(668, 485);
            Load += UC_Params_Load;
            Resize += UC_Params_Resize;
            tabControl1.ResumeLayout(false);
            UserAdmin.ResumeLayout(false);
            UserAdmin.PerformLayout();
            UserScan.ResumeLayout(false);
            UserScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)n_identificationNumber).EndInit();
            ParamsPage.ResumeLayout(false);
            ParamsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)n_backupDayBefore).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage UserScan;
        private TabPage ParamsPage;
        private DateTimePicker dtp_DateScan;
        private NumericUpDown n_identificationNumber;
        private TextBox tb_LastName;
        private TextBox tb_FirstName;
        private Button button3;
        private RadioButton rb_non;
        private RadioButton rb_oui;
        private TextBox tb_oldBackup;
        private TextBox tb_nextBackup;
        private NumericUpDown n_backupDayBefore;
        private Button button4;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label12;
        private Label label11;
        private Label label10;
        private TextBox tb_backup;
        private Label label14;
        private TextBox tb_dailybackup;
        private Label label13;
        private Button btn_save_backup;
        private Button btn_save_dailybackup;
        private TabPage UserAdmin;
        private Label label1;
        private Button button5;
        private Label label15;
        private Button button2;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button Supprimer;
        private ComboBox comboBox1;
        private Button btn_add_admin;
        private TextBox tb_password;
        private TextBox tb_username;
        private ComboBox comboBox2;
        private Label label16;
    }
}
