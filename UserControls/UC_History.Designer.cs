namespace ScanCode.UserControls
{
    partial class UC_History
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
            textBox1 = new TextBox();
            btn_recherche = new Button();
            dtp_start = new DateTimePicker();
            dtp_end = new DateTimePicker();
            cb_resultBit = new ComboBox();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            label2 = new Label();
            label3 = new Label();
            btn_export = new Button();
            pb_logo = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_logo).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(30, 82);
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(217, 23);
            textBox1.TabIndex = 2;
            // 
            // btn_recherche
            // 
            btn_recherche.BackColor = Color.Firebrick;
            btn_recherche.ForeColor = SystemColors.ButtonHighlight;
            btn_recherche.Location = new Point(561, 78);
            btn_recherche.MaximumSize = new Size(200, 56);
            btn_recherche.Name = "btn_recherche";
            btn_recherche.Size = new Size(95, 28);
            btn_recherche.TabIndex = 7;
            btn_recherche.Text = "Rechercher";
            btn_recherche.UseVisualStyleBackColor = false;
            btn_recherche.Click += btn_recherche_Click;
            // 
            // dtp_start
            // 
            dtp_start.Location = new Point(297, 68);
            dtp_start.Margin = new Padding(2, 1, 2, 1);
            dtp_start.Name = "dtp_start";
            dtp_start.Size = new Size(99, 23);
            dtp_start.TabIndex = 9;
            // 
            // dtp_end
            // 
            dtp_end.Location = new Point(297, 95);
            dtp_end.Margin = new Padding(2, 1, 2, 1);
            dtp_end.Name = "dtp_end";
            dtp_end.Size = new Size(99, 23);
            dtp_end.TabIndex = 10;
            // 
            // cb_resultBit
            // 
            cb_resultBit.FormattingEnabled = true;
            cb_resultBit.Items.AddRange(new object[] { "Valide", "Invalide", "Valide & Invalide" });
            cb_resultBit.Location = new Point(415, 81);
            cb_resultBit.Margin = new Padding(2, 1, 2, 1);
            cb_resultBit.Name = "cb_resultBit";
            cb_resultBit.Size = new Size(132, 23);
            cb_resultBit.TabIndex = 11;
            cb_resultBit.Text = "Licence ...";
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.GridLines = true;
            listView1.Location = new Point(15, 171);
            listView1.Margin = new Padding(2, 1, 2, 1);
            listView1.Name = "listView1";
            listView1.Size = new Size(641, 304);
            listView1.TabIndex = 12;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Nom";
            columnHeader1.Width = 145;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Prenom";
            columnHeader2.Width = 145;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Numero_Licence";
            columnHeader3.Width = 175;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Date_Scan";
            columnHeader4.Width = 155;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Licence";
            columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Information";
            columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Certificat_Medical";
            columnHeader7.Width = 150;
            // 
            // label2
            // 
            label2.BackColor = SystemColors.HighlightText;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(269, 68);
            label2.MaximumSize = new Size(500, 23);
            label2.Name = "label2";
            label2.Size = new Size(26, 23);
            label2.TabIndex = 13;
            label2.Text = "Du";
            // 
            // label3
            // 
            label3.BackColor = SystemColors.HighlightText;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(269, 95);
            label3.MaximumSize = new Size(500, 23);
            label3.Name = "label3";
            label3.Size = new Size(25, 23);
            label3.TabIndex = 14;
            label3.Text = "Au";
            // 
            // btn_export
            // 
            btn_export.BackColor = Color.Gold;
            btn_export.Location = new Point(561, 10);
            btn_export.MaximumSize = new Size(200, 56);
            btn_export.Name = "btn_export";
            btn_export.Size = new Size(95, 28);
            btn_export.TabIndex = 15;
            btn_export.Text = "Exportation";
            btn_export.UseVisualStyleBackColor = false;
            btn_export.Click += btn_export_Click;
            // 
            // pb_logo
            // 
            pb_logo.Location = new Point(8, 10);
            pb_logo.Margin = new Padding(2, 1, 2, 1);
            pb_logo.Name = "pb_logo";
            pb_logo.Size = new Size(50, 50);
            pb_logo.TabIndex = 16;
            pb_logo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(15, 141);
            label1.Name = "label1";
            label1.Size = new Size(202, 18);
            label1.TabIndex = 17;
            label1.Text = "Nombre d'adhérents : 0";
            // 
            // UC_History
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(pb_logo);
            Controls.Add(btn_export);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cb_resultBit);
            Controls.Add(dtp_end);
            Controls.Add(dtp_start);
            Controls.Add(btn_recherche);
            Controls.Add(textBox1);
            Controls.Add(listView1);
            MinimumSize = new Size(668, 485);
            Name = "UC_History";
            Size = new Size(668, 485);
            Load += UC_History_Load;
            Resize += UC_History_Resize;
            ((System.ComponentModel.ISupportInitialize)pb_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button btn_recherche;
        private DateTimePicker dtp_start;
        private DateTimePicker dtp_end;
        private ComboBox cb_resultBit;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label2;
        private Label label3;
        private Button btn_export;
        private PictureBox pb_logo;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Label label1;
    }
}
