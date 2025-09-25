namespace ScanCode.UserControls
{
    partial class UC_Home
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
            components = new System.ComponentModel.Container();
            label = new Label();
            label1 = new Label();
            textBoxScannedData = new TextBox();
            pictureBox1 = new PictureBox();
            lb_nom = new Label();
            lb_prenom = new Label();
            lb_messageError = new Label();
            lv_todayScan = new ListView();
            Nom = new ColumnHeader();
            Prenom = new ColumnHeader();
            Identification = new ColumnHeader();
            Licence_Valide = new ColumnHeader();
            lb_identificationNumber = new Label();
            pictureBox2 = new PictureBox();
            pb_logo = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            label2 = new Label();
            btn_start = new Button();
            label_hc = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_logo).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label.Location = new Point(261, 10);
            label.Name = "label";
            label.Size = new Size(130, 18);
            label.TabIndex = 0;
            label.Text = "Dernier Scan : ";
            label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(18, 194);
            label1.Name = "label1";
            label1.Size = new Size(174, 18);
            label1.TabIndex = 1;
            label1.Text = "Scan de la journée :";
            // 
            // textBoxScannedData
            // 
            textBoxScannedData.ForeColor = SystemColors.WindowText;
            textBoxScannedData.Location = new Point(409, 237);
            textBoxScannedData.Name = "textBoxScannedData";
            textBoxScannedData.Size = new Size(232, 23);
            textBoxScannedData.TabIndex = 4;
            textBoxScannedData.KeyPress += TextBoxScannedData_KeyPress;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(70, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(76, 76);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // lb_nom
            // 
            lb_nom.AutoSize = true;
            lb_nom.Location = new Point(174, 74);
            lb_nom.Margin = new Padding(1, 0, 1, 0);
            lb_nom.Name = "lb_nom";
            lb_nom.Size = new Size(35, 15);
            lb_nom.TabIndex = 6;
            lb_nom.Text = "ghfgj";
            // 
            // lb_prenom
            // 
            lb_prenom.AutoSize = true;
            lb_prenom.Location = new Point(271, 74);
            lb_prenom.Margin = new Padding(1, 0, 1, 0);
            lb_prenom.Name = "lb_prenom";
            lb_prenom.Size = new Size(36, 15);
            lb_prenom.TabIndex = 7;
            lb_prenom.Text = "gfhfg";
            // 
            // lb_messageError
            // 
            lb_messageError.AutoSize = true;
            lb_messageError.BackColor = Color.Gold;
            lb_messageError.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
            lb_messageError.Location = new Point(159, 131);
            lb_messageError.Margin = new Padding(0);
            lb_messageError.Name = "lb_messageError";
            lb_messageError.Size = new Size(33, 19);
            lb_messageError.TabIndex = 8;
            lb_messageError.Text = "gfhf";
            // 
            // lv_todayScan
            // 
            lv_todayScan.BackColor = Color.White;
            lv_todayScan.Columns.AddRange(new ColumnHeader[] { Nom, Prenom, Identification, Licence_Valide });
            lv_todayScan.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lv_todayScan.GridLines = true;
            lv_todayScan.Location = new Point(18, 214);
            lv_todayScan.Margin = new Padding(2);
            lv_todayScan.Name = "lv_todayScan";
            lv_todayScan.Size = new Size(637, 261);
            lv_todayScan.TabIndex = 9;
            lv_todayScan.UseCompatibleStateImageBehavior = false;
            lv_todayScan.View = View.Details;
            // 
            // Nom
            // 
            Nom.Text = "Nom";
            Nom.Width = 150;
            // 
            // Prenom
            // 
            Prenom.Text = "Prenom";
            Prenom.Width = 150;
            // 
            // Identification
            // 
            Identification.Text = "Numero_Licence";
            Identification.Width = 180;
            // 
            // Licence_Valide
            // 
            Licence_Valide.Text = "Licence_Valide";
            Licence_Valide.Width = 130;
            // 
            // lb_identificationNumber
            // 
            lb_identificationNumber.AutoSize = true;
            lb_identificationNumber.Location = new Point(372, 75);
            lb_identificationNumber.Margin = new Padding(2, 0, 2, 0);
            lb_identificationNumber.Name = "lb_identificationNumber";
            lb_identificationNumber.Size = new Size(38, 15);
            lb_identificationNumber.TabIndex = 11;
            lb_identificationNumber.Text = "label2";
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(471, 66);
            pictureBox2.Margin = new Padding(2);
            pictureBox2.MaximumSize = new Size(153, 190);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(92, 114);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            pictureBox2.Paint += pictureBox2_Paint;
            // 
            // pb_logo
            // 
            pb_logo.Location = new Point(8, 10);
            pb_logo.Margin = new Padding(2);
            pb_logo.Name = "pb_logo";
            pb_logo.Size = new Size(50, 50);
            pb_logo.TabIndex = 13;
            pb_logo.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.ForeColor = Color.Firebrick;
            label2.Location = new Point(238, 30);
            label2.Name = "label2";
            label2.Size = new Size(172, 15);
            label2.TabIndex = 14;
            label2.Text = "---------------------------------";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click;
            // 
            // btn_start
            // 
            btn_start.BackColor = Color.Firebrick;
            btn_start.ForeColor = SystemColors.ButtonHighlight;
            btn_start.Location = new Point(518, 24);
            btn_start.Margin = new Padding(2);
            btn_start.MaximumSize = new Size(176, 100);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(126, 28);
            btn_start.TabIndex = 10;
            btn_start.Text = "Récupération";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // label_hc
            // 
            label_hc.AutoSize = true;
            label_hc.Location = new Point(440, 7);
            label_hc.Name = "label_hc";
            label_hc.Size = new Size(215, 15);
            label_hc.TabIndex = 15;
            label_hc.Text = "Récupération des scans hors connexion";
            // 
            // UC_Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label_hc);
            Controls.Add(label2);
            Controls.Add(pb_logo);
            Controls.Add(lb_identificationNumber);
            Controls.Add(btn_start);
            Controls.Add(lv_todayScan);
            Controls.Add(lb_messageError);
            Controls.Add(lb_prenom);
            Controls.Add(lb_nom);
            Controls.Add(pictureBox1);
            Controls.Add(textBoxScannedData);
            Controls.Add(label1);
            Controls.Add(label);
            Controls.Add(pictureBox2);
            MinimumSize = new Size(668, 485);
            Name = "UC_Home";
            Size = new Size(668, 485);
            Load += UC_Home_Load;
            Resize += UC_Home_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox textBoxScannedData;
        private PictureBox pictureBox1;
        private Label lb_nom;
        private Label lb_prenom;
        private Label lb_messageError;
        private ListView lv_todayScan;
        private ColumnHeader Nom;
        private ColumnHeader Prenom;
        private ColumnHeader Identification;
        private ColumnHeader Licence_Valide;
        private Label lb_identificationNumber;
        private PictureBox pictureBox2;
        private PictureBox pb_logo;
        private System.Windows.Forms.Timer timer1;
        private Label label2;
        public Label label;
        private Button btn_start;
        private Label label_hc;
    }
}
