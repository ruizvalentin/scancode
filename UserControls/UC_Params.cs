using IniParser;
using IniParser.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using OfficeOpenXml;
using ScanCode.SQL;
using System.Text.RegularExpressions;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;

namespace ScanCode.UserControls
{
    public partial class UC_Params : UserControl
    {
        string username, sourceBDD, configPath;

        private Rectangle tabControlRect;// Pour le responsive sur les supports (voir CDC F2) (Tablette, pc fixe, écran déporté)
        private Rectangle label1Rect; // A changer dans la version suivante (voir projet Locorama (fill dock))
        private Rectangle label2Rect;
        private Rectangle label3Rect;
        private Rectangle tbUserRect;
        private Rectangle tbMdpRect;
        private Rectangle btn1Rect;
        private Rectangle label4Rect;
        private Rectangle btn2Rect;
        private Rectangle btnSuppRect;
        private Rectangle cbRect;
        private Rectangle label15Rect;
        private Rectangle btn5Rect;
        private Size formOriginalSize;

        private Rectangle label5Rect;
        private Rectangle label6Rect;
        private Rectangle label7Rect;
        private Rectangle label8Rect;
        private Rectangle label9Rect;
        private Rectangle label16Rect;
        private Rectangle cb2Rect;
        private Rectangle tbFRect;
        private Rectangle tbLRect;
        private Rectangle nINRect;
        private Rectangle dateRect;
        private Rectangle rbOuiRect;
        private Rectangle rbNonRect;
        private Rectangle btnValideRect;

        private Rectangle label10Rect;
        private Rectangle label11Rect;
        private Rectangle label12Rect;
        private Rectangle label13Rect;
        private Rectangle label14Rect;
        private Rectangle nBDBRect;
        private Rectangle btn4Rect;
        private Rectangle tbNRect;
        private Rectangle tbORect;
        private Rectangle tbDRect;
        private Rectangle tbBRect;
        private Rectangle btnSDRect;
        private Rectangle btnSBRect;

        public UC_Params(string _addInfo, string _configPath)
        {
            InitializeComponent();
            username = _addInfo;
            configPath = _configPath;
            refreshComboBox();
        }

        private void UC_Params_Load(object sender, EventArgs e)
        {
            Params parametre = new Params(sourceBDD);
            tb_backup.Text = parametre.SelectLinkBackup();
            tb_dailybackup.Text = parametre.SelectLinkBackupDaily();
            tb_oldBackup.Text = parametre.SelectLastBackupDate().ToString();
            tb_nextBackup.Text = parametre.SelectNextBackupDate().ToString();
            n_backupDayBefore.Value = parametre.SelectIntervalleDay();
            comboBox2.SelectedIndex = 0;

            formOriginalSize = this.Size;
            tabControlRect = new Rectangle(tabControl1.Location.X, tabControl1.Location.Y, tabControl1.Width, tabControl1.Height);
            label1Rect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2Rect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            label3Rect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, label3.Height);
            tbUserRect = new Rectangle(tb_username.Location.X, tb_username.Location.Y, tb_username.Width, tb_username.Height);
            tbMdpRect = new Rectangle(tb_password.Location.X, tb_password.Location.Y, tb_password.Width, tb_password.Height);
            btn1Rect = new Rectangle(btn_add_admin.Location.X, btn_add_admin.Location.Y, btn_add_admin.Width, btn_add_admin.Height);
            label4Rect = new Rectangle(label4.Location.X, label4.Location.Y, label4.Width, label4.Height);
            btn2Rect = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            btnSuppRect = new Rectangle(Supprimer.Location.X, Supprimer.Location.Y, Supprimer.Width, Supprimer.Height);
            cbRect = new Rectangle(comboBox1.Location.X, comboBox1.Location.Y, comboBox1.Width, comboBox1.Height);
            label15Rect = new Rectangle(label15.Location.X, label15.Location.Y, label15.Width, label15.Height);
            btn5Rect = new Rectangle(button5.Location.X, button5.Location.Y, button5.Width, button5.Height);

            label5Rect = new Rectangle(label5.Location.X, label5.Location.Y, label5.Width, label5.Height);
            label6Rect = new Rectangle(label6.Location.X, label6.Location.Y, label6.Width, label6.Height);
            label7Rect = new Rectangle(label7.Location.X, label7.Location.Y, label7.Width, label7.Height);
            label8Rect = new Rectangle(label8.Location.X, label8.Location.Y, label8.Width, label8.Height);
            label9Rect = new Rectangle(label9.Location.X, label9.Location.Y, label9.Width, label9.Height);
            label16Rect = new Rectangle(label16.Location.X, label16.Location.Y, label16.Width, label16.Height);
            cb2Rect = new Rectangle(comboBox2.Location.X, comboBox2.Location.Y, comboBox2.Width, comboBox2.Height);
            tbFRect = new Rectangle(tb_FirstName.Location.X, tb_FirstName.Location.Y, tb_FirstName.Width, tb_FirstName.Height);
            tbLRect = new Rectangle(tb_LastName.Location.X, tb_LastName.Location.Y, tb_LastName.Width, tb_LastName.Height);
            nINRect = new Rectangle(n_identificationNumber.Location.X, n_identificationNumber.Location.Y, n_identificationNumber.Width, n_identificationNumber.Height);
            dateRect = new Rectangle(dtp_DateScan.Location.X, dtp_DateScan.Location.Y, dtp_DateScan.Width, dtp_DateScan.Height);
            rbOuiRect = new Rectangle(rb_oui.Location.X, rb_oui.Location.Y, rb_oui.Width, rb_oui.Height);
            rbNonRect = new Rectangle(rb_non.Location.X, rb_non.Location.Y, rb_non.Width, rb_non.Height);
            btnValideRect = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);

            label10Rect = new Rectangle(label10.Location.X, label10.Location.Y, label10.Width, label10.Height);
            label11Rect = new Rectangle(label11.Location.X, label11.Location.Y, label11.Width, label11.Height);
            label12Rect = new Rectangle(label12.Location.X, label12.Location.Y, label12.Width, label12.Height);
            label13Rect = new Rectangle(label13.Location.X, label13.Location.Y, label13.Width, label13.Height);
            label14Rect = new Rectangle(label14.Location.X, label14.Location.Y, label14.Width, label14.Height);
            nBDBRect = new Rectangle(n_backupDayBefore.Location.X, n_backupDayBefore.Location.Y, n_backupDayBefore.Width, n_backupDayBefore.Height);
            btn4Rect = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);
            tbNRect = new Rectangle(tb_nextBackup.Location.X, tb_nextBackup.Location.Y, tb_nextBackup.Width, tb_nextBackup.Height);
            tbORect = new Rectangle(tb_oldBackup.Location.X, tb_oldBackup.Location.Y, tb_oldBackup.Width, tb_oldBackup.Height);
            tbDRect = new Rectangle(tb_dailybackup.Location.X, tb_dailybackup.Location.Y, tb_dailybackup.Width, tb_dailybackup.Height);
            tbBRect = new Rectangle(tb_backup.Location.X, tb_backup.Location.Y, tb_backup.Width, tb_backup.Height);
            btnSDRect = new Rectangle(btn_save_dailybackup.Location.X, btn_save_dailybackup.Location.Y, btn_save_dailybackup.Width, btn_save_dailybackup.Height);
            btnSBRect = new Rectangle(btn_save_backup.Location.X, btn_save_backup.Location.Y, btn_save_backup.Width, btn_save_backup.Height);



            setConfig(configPath);
        }

        //
        // Permet d'ajouter un nouveau administrateur au système 
        //
        private void btn_add_admin_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == null || tb_password.Text == null) // vérification des champs 
                MessageBox.Show("Veuillez renseigner le nom d'utilisateur et un mot de passe");
            else if (tb_username.Text.Length < 3)
                MessageBox.Show("Le nom d'utilisateur doit comporter au minimum 3 caractères");
            else
            {
                string pattern = @"^(?=.*[@#$%^&+=/\\?""'])(?=.{8,})";
                Match match = Regex.Match(tb_password.Text, pattern);

                if (match.Success)
                {
                    UserAdmin userAdmin = new UserAdmin(sourceBDD);
                    bool verif = userAdmin.VerifUserName(tb_username.Text); // Check if another admin account use the same username 
                    if (verif)
                    {
                        MessageBox.Show("Un compte administrateur comporte déjà ce nom d'utilisateur, ajout impossible");
                        return;
                    }

                    userAdmin.insertAdmin(tb_username.Text, tb_password.Text); // Ajout de l'admin

                    tb_username.Text = "";
                    tb_password.Text = "";

                    MessageBox.Show("Administrateur correctement ajouter");
                    refreshComboBox();
                }
                else
                    MessageBox.Show("Le mot de passe doit contenir au minimum 8 caractères dont un spéciale");
            }
        }

        //
        // Ajout d'un scan manuellement 
        //
        private void btn_add_scan_Click(object sender, EventArgs e)
        {
            if (tb_FirstName.Text == null || tb_LastName.Text == null)
                MessageBox.Show("Veuillez renseigner le nom et le prenom");
            else
            {
                int result = 0;
                if (rb_oui.Checked)
                    result = 1;

                try
                {
                    UserScan userAdmin = new UserScan(sourceBDD);
                    userAdmin.insert(tb_LastName.Text, tb_FirstName.Text, (int)n_identificationNumber.Value, "Ajouter à la main par : " + username + " le : " + DateTime.Now.ToString(), result, dtp_DateScan.Value.Date.ToString("dd-MM-yyyy HH:mm:ss"), 0, comboBox2.Text);

                    MessageBox.Show("L'ajout a correctement été effectué");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur durant l'inscirption : " + ex.Message, "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Maj du nb de jour entre deux backups auto 
        private void button4_Click(object sender, EventArgs e)
        {
            Params parametre = new Params(sourceBDD);
            parametre.UpdateDayBeforeBackup((int)n_backupDayBefore.Value);
            parametre.UpdateNextBackupDate(parametre.SelectLastBackupDate().AddDays(parametre.SelectIntervalleDay()));

            tb_nextBackup.Text = parametre.SelectNextBackupDate().ToString();
            n_backupDayBefore.Value = parametre.SelectIntervalleDay();
        }

        // Mettre à jour le combobox avec les admins
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            refreshComboBox();
        }

        // Permet de supprimer un compte admin 
        private void Supprimer_Click(object sender, EventArgs e)
        {
            UserAdmin userAdmin = new UserAdmin(sourceBDD);
            userAdmin.Delete(comboBox1.SelectedItem.ToString());

            refreshComboBox();
        }

        // Fonction pour mettre à jour le combobox avec les admins
        private void refreshComboBox()
        {
            UserAdmin userAdmin = new UserAdmin(sourceBDD);
            List<string> data = userAdmin.SelectAll();

            comboBox1.Items.Clear();

            foreach (string s in data)
            {
                comboBox1.Items.Add(s);
            }

            comboBox1.SelectedIndex = 0;
        }

        // Permet de mettre à jour le lien pour les backups daily 
        private void btn_save_dailybackup_Click(object sender, EventArgs e)
        {
            string userInputPath = tb_dailybackup.Text;
            Params parametre = new Params(sourceBDD);
            bool isValidPath = Directory.Exists(userInputPath);

            if (isValidPath)
            {
                if (!userInputPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) && !userInputPath.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()))
                    userInputPath = userInputPath + System.IO.Path.DirectorySeparatorChar;

                parametre.UpdateLinkbackupDaily(userInputPath);
            }
            else
            {
                MessageBox.Show("Lien fournie non valide");
            }

            tb_dailybackup.Text = parametre.SelectLinkBackupDaily();
        }

        // Permet de mettre à jour le lien pour les backups classique 
        private void btn_save_backup_Click(object sender, EventArgs e)
        {

            string userInputPath = tb_backup.Text;
            Params parametre = new Params(sourceBDD);
            bool isValidPath = Directory.Exists(userInputPath);

            if (isValidPath)
            {
                if (!userInputPath.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) && !userInputPath.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()))
                    userInputPath = userInputPath + System.IO.Path.DirectorySeparatorChar;

                parametre.UpdateLinkbackup(userInputPath);
            }
            else
            {
                MessageBox.Show("Lien fournie non valide");
            }

            tb_backup.Text = parametre.SelectLinkBackup();
        }

        // Permet de télécharger l'audit trail au format PDF ou EXCEL
        private void btn_dwn_audit_Click(object sender, EventArgs e)
        {
            using (var dialog = new CustomExportDialogue())
            {
                dialog.btnExportToPdf.Text = "Exporter en PDF";
                dialog.btnExportToExcel.Text = "Exporter en Excel";

                dialog.ShowDialog();

                if (dialog.ExportToPdf)
                    Export_PDF();
                else if (dialog.ExportToExcel)
                    Export_Excel();
            }
        }

        // EXPORT en PDF
        private void Export_PDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers PDF|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportToPDF(saveFileDialog.FileName);
        }

        // Création du PDF
        private void ExportToPDF(string filename)
        {
            UserScanBarCode userScanBarCode = new UserScanBarCode(sourceBDD);
            List<string> dataList = userScanBarCode.SelectAll();

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, fs);

                // Ajouter un événement pour personnaliser l'en-tête
                writer.PageEvent = new CustomHeader();

                document.Open();

                document.Add(new Paragraph("\n"));
                document.Add(new Paragraph("\n"));

                // Ajouter un tableau
                PdfPTable table = new PdfPTable(2);
                table.AddCell("Numéro de Licence");
                table.AddCell("Date");

                foreach (var data in dataList)
                {
                    var parts = data.Split(';');
                    if (parts.Length >= 2)
                    {
                        table.AddCell(parts[0]);
                        table.AddCell(parts[1]);
                    }
                }

                document.Add(table);

                document.Close();
            }
        }

        // Personnalisation de l'entête 
        public class CustomHeader : PdfPageEventHelper
        {

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                PdfPTable header = new PdfPTable(1);
                header.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                header.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                PdfPCell cell = new PdfPCell(new Phrase($"Rapport des erreurs code barre du Tir Olympique Lyonnais généré le {DateTime.Now.ToShortDateString()}"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                header.AddCell(cell);

                PdfPCell cell1 = new PdfPCell();
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                header.AddCell(cell1);

                header.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - document.TopMargin + header.TotalHeight, writer.DirectContent);
            }
        }

        // Export en Excel 
        private void Export_Excel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers Excel|*.xlsx";
            saveFileDialog.Title = "Enregistrer le fichier Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                ExportToExcel(saveFileDialog.FileName);
        }

        // Création du fichier Excel 
        private void ExportToExcel(string filePath)
        {
            UserScanBarCode userScanBarCode = new UserScanBarCode(sourceBDD);
            List<string> dataList = userScanBarCode.SelectAll();

            // Créer un nouveau fichier Excel
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Données");

                // En-têtes de colonnes
                worksheet.Cells["A1"].Value = "Numéro de Licence";
                worksheet.Cells["B1"].Value = "Date";

                int row = 2;

                foreach (var data in dataList)
                {
                    var parts = data.Split(';');
                    if (parts.Length >= 2)
                    {
                        worksheet.Cells[$"A{row}"].Value = parts[0];
                        worksheet.Cells[$"B{row}"].Value = parts[1];

                        row++;
                    }
                }

                // Enregistrer le fichier Excel
                FileInfo excelFile = new FileInfo(filePath);
                package.SaveAs(excelFile);
            }
        }

        public void setConfig(string filePath)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);

            // Lien
            string section = "Link";

            string key = "LinkBDD";
            sourceBDD = data[section][key];
        }

        // Pour le responsive 
        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);


            int newX = (int)(OriginalControlRect.X * xRatio);
            int newY = (int)(OriginalControlRect.Y * yRatio);

            int newWidth = (int)(OriginalControlRect.Width * xRatio);
            int newHeight = (int)(OriginalControlRect.Height * yRatio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newWidth, newHeight);
        }

        // Pour le responsive 
        private void UC_Params_Resize(object sender, EventArgs e)
        {
            if (sourceBDD == null || sourceBDD == "")
                return;

            resizeControl(tabControlRect, tabControl1);
            resizeControl(label1Rect, label1);
            resizeControl(label2Rect, label2);
            resizeControl(label3Rect, label3);
            resizeControl(tbUserRect, tb_username);
            resizeControl(tbMdpRect, tb_password);
            resizeControl(btn1Rect, btn_add_admin);
            resizeControl(label4Rect, label4);
            resizeControl(btn2Rect, button2);
            resizeControl(btnSuppRect, Supprimer);
            resizeControl(cbRect, comboBox1);
            resizeControl(label15Rect, label15);
            resizeControl(btn5Rect, button5);

            resizeControl(label5Rect, label5);
            resizeControl(label6Rect, label6);
            resizeControl(label7Rect, label7);
            resizeControl(label8Rect, label8);
            resizeControl(label9Rect, label9);
            resizeControl(label16Rect, label16);
            resizeControl(cb2Rect, comboBox2);
            resizeControl(tbFRect, tb_FirstName);
            resizeControl(tbLRect, tb_LastName);
            resizeControl(nINRect, n_identificationNumber);
            resizeControl(dateRect, dtp_DateScan);
            resizeControl(rbOuiRect, rb_oui);
            resizeControl(rbNonRect, rb_non);
            resizeControl(btnValideRect, button3);

            resizeControl(label10Rect, label10);
            resizeControl(label11Rect, label11);
            resizeControl(label12Rect, label12);
            resizeControl(label13Rect, label13);
            resizeControl(label14Rect, label14);
            resizeControl(nBDBRect, n_backupDayBefore);
            resizeControl(btn4Rect, button4);
            resizeControl(tbNRect, tb_nextBackup);
            resizeControl(tbORect, tb_oldBackup);
            resizeControl(tbDRect, tb_dailybackup);
            resizeControl(tbBRect, tb_backup);
            resizeControl(btnSDRect, btn_save_dailybackup);
            resizeControl(btnSBRect, btn_save_backup);


            if (this.Size.Width > 1000 || this.Size.Height > 800)
            {
                label2.Font = new Font(label2.Font.FontFamily, 14);
                label1.Font = new Font(label1.Font.FontFamily, 14);
                label3.Font = new Font(label3.Font.FontFamily, 14);
                label4.Font = new Font(label4.Font.FontFamily, 14);
                label15.Font = new Font(label15.Font.FontFamily, 14);

                label5.Font = new Font(label5.Font.FontFamily, 14);
                label6.Font = new Font(label6.Font.FontFamily, 14);
                label7.Font = new Font(label7.Font.FontFamily, 14);
                label8.Font = new Font(label8.Font.FontFamily, 14);
                label9.Font = new Font(label9.Font.FontFamily, 14);
                label16.Font = new Font(label16.Font.FontFamily, 14);

                label10.Font = new Font(label10.Font.FontFamily, 14);
                label11.Font = new Font(label11.Font.FontFamily, 14);
                label12.Font = new Font(label12.Font.FontFamily, 14);
                label13.Font = new Font(label13.Font.FontFamily, 14);
                label14.Font = new Font(label14.Font.FontFamily, 14);
            }
            else
            {
                label2.Font = new Font(label2.Font.FontFamily, 9);
                label1.Font = new Font(label1.Font.FontFamily, 9);
                label3.Font = new Font(label3.Font.FontFamily, 9);
                label4.Font = new Font(label4.Font.FontFamily, 9);
                label15.Font = new Font(label15.Font.FontFamily, 9);

                label5.Font = new Font(label5.Font.FontFamily, 9);
                label6.Font = new Font(label6.Font.FontFamily, 9);
                label7.Font = new Font(label7.Font.FontFamily, 9);
                label8.Font = new Font(label8.Font.FontFamily, 9);
                label9.Font = new Font(label9.Font.FontFamily, 9);
                label16.Font = new Font(label16.Font.FontFamily, 9);

                label10.Font = new Font(label10.Font.FontFamily, 9);
                label11.Font = new Font(label11.Font.FontFamily, 9);
                label12.Font = new Font(label12.Font.FontFamily, 9);
                label13.Font = new Font(label13.Font.FontFamily, 9);
                label14.Font = new Font(label14.Font.FontFamily, 9);
            }
        }
    }
}
