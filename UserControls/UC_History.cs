using IniParser.Model;
using IniParser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using ScanCode.SQL;
using Image = System.Drawing.Image;
using Rectangle = System.Drawing.Rectangle;

namespace ScanCode.UserControls
{
    public partial class UC_History : UserControl
    {
        string configPath, logoLink, sourceBDD;
        int nbAdherents = 0, nbLignes = 0;

        private Rectangle TBRect; // Pour le responsive sur les supports (voir CDC F2) (Tablette, pc fixe, écran déporté)
        private Rectangle label1Rect;  // A changer dans la version suivante (voir projet Locorama (fill dock))
        private Rectangle label2Rect;
        private Rectangle label3Rect;
        private Rectangle DTPE3Rect;
        private Rectangle DTPSRect;
        private Rectangle CBRect;
        private Rectangle LVRect;
        private Rectangle btnRecherhceRect;
        private Rectangle btnExportRect;
        private Rectangle pbLogoRect;
        private Size formOriginalSize;


        public UC_History(string _configPath)
        {
            InitializeComponent();

            cb_resultBit.SelectedIndex = 2;
            configPath = _configPath;
            setConfig(configPath);

            pb_logo.Image = Image.FromFile(logoLink);
        }

        // Click sur le bouton recherche, permet de selectionner suivant les filtres les données 
        private void btn_recherche_Click(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim(); // Récupération des filtres 
            DateTime startDate = dtp_start.Value.Date;
            DateTime endDate = dtp_end.Value.Date.AddDays(1).AddSeconds(-1);
            string licenseStatusFilter = " ";
            if (cb_resultBit.SelectedItem != null)
                licenseStatusFilter = cb_resultBit.SelectedItem.ToString();

            UserScan userscan = new UserScan(sourceBDD);
            List<string> data = userscan.selectRequest(searchText, startDate, endDate, licenseStatusFilter); // Requete SQL pour avoir les données 
            nbLignes = data.Count;

            nbAdherents = userscan.selectRequestCount(searchText, startDate, endDate, licenseStatusFilter);
            label1.Text = "Nombre d'adhérents : " + nbAdherents.ToString(); // Maj du nombre d'adhérents suivant les filtres 

            // Vider la ListBox avant d'ajouter de nouveaux éléments
            listView1.Items.Clear();

            // Vérifier si la liste contient des données
            if (data.Count > 0)
            {
                // Ajouter les éléments à la ListBox
                foreach (string element in data)
                {
                    ListViewItem item = new ListViewItem(element.Split(';').First());
                    item.SubItems.Add(element.Split(';')[1]);
                    item.SubItems.Add(element.Split(';')[2]);
                    item.SubItems.Add(element.Split(';')[3]);
                    item.SubItems.Add(element.Split(';')[4]);
                    item.SubItems.Add(element.Split(';')[5]);
                    item.SubItems.Add(element.Split(';').Last());
                    listView1.Items.Add(item);
                }
            }

            listView1.Scrollable = true;
        }

        // Lors du click sur le bouton exportation, si le choix excel est fait 
        private void Export_Excel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers Excel|*.xlsx";
            saveFileDialog.Title = "Enregistrer le fichier Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportToExcel(filePath); // appel de la fonction pour exporter en excel les données 
            }
        }

        // Permet la création du fichier excel d'export 
        private void ExportToExcel(string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Données");

                // Remplir l'en-tête (noms de colonnes)
                for (int col = 1; col <= listView1.Columns.Count; col++)
                {
                    worksheet.Cells[1, col].Value = listView1.Columns[col - 1].Text;
                }

                worksheet.Cells[1, listView1.Columns.Count + 1].Value = "Jour de la Semaine";
                worksheet.Cells[1, listView1.Columns.Count + 2].Value = "Mois";
                worksheet.Cells[1, listView1.Columns.Count + 3].Value = "Annee";

                // Remplir les données
                for (int row = 0; row < listView1.Items.Count; row++)
                {
                    for (int col = 1; col <= listView1.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col].Value = listView1.Items[row].SubItems[col - 1].Text;
                    }

                    // Maintenant, on prend la date dans la colonne spécifique 
                    string dateText = listView1.Items[row].SubItems[3].Text; // la date est dans la 4e colonne (index 3)
                    DateTime parsedDate;

                    // Essayer de convertir la date en DateTime et afficher le jour de la semaine
                    if (DateTime.TryParseExact(dateText, "dd-MM-yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                    {
                        // Ajouter le jour de la semaine dans la nouvelle colonne
                        worksheet.Cells[row + 2, listView1.Columns.Count + 1].Value = parsedDate.ToString("dddd", new System.Globalization.CultureInfo("fr-FR"));
                        worksheet.Cells[row + 2, listView1.Columns.Count + 2].Value = parsedDate.ToString("MMMM", new System.Globalization.CultureInfo("fr-FR"));
                        worksheet.Cells[row + 2, listView1.Columns.Count + 3].Value = parsedDate.ToString("yyyy", new System.Globalization.CultureInfo("fr-FR"));
                    }
                    else
                    {
                        // Si la date n'est pas valide, laisser la cellule vide
                        worksheet.Cells[row + 2, listView1.Columns.Count + 1].Value = string.Empty;
                        worksheet.Cells[row + 2, listView1.Columns.Count + 2].Value = string.Empty;
                        worksheet.Cells[row + 2, listView1.Columns.Count + 3].Value = string.Empty;
                    }

                }

                // Ajout des informations filtres (CDC F31)
                ExcelWorksheet worksheetInfo = excelPackage.Workbook.Worksheets.Add("InfoFiltre");
                worksheetInfo.Cells[1, 1].Value = "Champs recherche";
                worksheetInfo.Cells[1, 2].Value = "Date débuts";
                worksheetInfo.Cells[1, 3].Value = "Date fin";
                worksheetInfo.Cells[1, 4].Value = "Licence";

                worksheetInfo.Cells[2, 1].Value = textBox1.Text;
                worksheetInfo.Cells[2, 2].Value = dtp_start.Value.Date.ToString("dd/mm/yyyy");
                worksheetInfo.Cells[2, 3].Value = dtp_end.Value.Date.ToString("dd/mm/yyyy");
                worksheetInfo.Cells[2, 4].Value = cb_resultBit.SelectedItem.ToString();

                // Enregistrer le fichier Excel
                FileInfo excelFile = new FileInfo(filePath);
                excelPackage.SaveAs(excelFile);
            }
        }

        // Lors du click sur le bouton exportation, si le choix PDF est fait 
        private void Export_PDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Fichiers PDF|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToPDF(listView1, saveFileDialog.FileName);
            }
        }

        // Permet la création du fichier PDF d'export 
        private void ExportToPDF(ListView listView, string filePath)
        {
            Document pdfDoc = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));

            // Ajouter un événement pour personnaliser l'en-tête
            writer.PageEvent = new CustomHeader();

            pdfDoc.Open();

            pdfDoc.Add(new Paragraph("\n"));
            pdfDoc.Add(new Paragraph($"Nombre de lignes : {nbLignes.ToString()}\n"));
            pdfDoc.Add(new Paragraph($"Nombre d'adhérents : {nbAdherents.ToString()}\n\n"));

            PdfPTable pdfTableInfo = new PdfPTable(4);
            pdfTableInfo.DefaultCell.Padding = 3;
            pdfTableInfo.WidthPercentage = 100;
            pdfTableInfo.HorizontalAlignment = Element.ALIGN_LEFT;

            //Ajout des en-tête dans le tableau 
            PdfPCell cell = new PdfPCell(new Phrase("Champs recherche"));
            pdfTableInfo.AddCell(cell);
            PdfPCell cell2 = new PdfPCell(new Phrase("Date débuts"));
            pdfTableInfo.AddCell(cell2);
            PdfPCell cell3 = new PdfPCell(new Phrase("Date fin"));
            pdfTableInfo.AddCell(cell3);
            PdfPCell cell4 = new PdfPCell(new Phrase("Licence"));
            pdfTableInfo.AddCell(cell4);

            PdfPCell cell5 = new PdfPCell(new Phrase(textBox1.Text));
            pdfTableInfo.AddCell(cell5);
            PdfPCell cell6 = new PdfPCell(new Phrase(dtp_start.Value.Date.ToString("dd/mm/yyyy")));
            pdfTableInfo.AddCell(cell6);
            PdfPCell cell7 = new PdfPCell(new Phrase(dtp_end.Value.Date.ToString("dd/mm/yyyy")));
            pdfTableInfo.AddCell(cell7);
            PdfPCell cell8 = new PdfPCell(new Phrase(cb_resultBit.SelectedItem.ToString()));
            pdfTableInfo.AddCell(cell8);

            pdfDoc.Add(pdfTableInfo);

            pdfDoc.Add(new Paragraph("\n"));
            pdfDoc.Add(new Paragraph("\n"));

            PdfPTable pdfTable = new PdfPTable(listView.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            // Ajouter les en-têtes de colonne
            foreach (ColumnHeader column in listView.Columns)
            {
                PdfPCell cell1 = new PdfPCell(new Phrase(column.Text));
                pdfTable.AddCell(cell1);
            }

            // Ajouter les données
            foreach (ListViewItem item in listView.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    PdfPCell cell1 = new PdfPCell(new Phrase(subItem.Text));
                    pdfTable.AddCell(cell1);
                }
            }

            pdfDoc.Add(pdfTable);
            pdfDoc.Close();
        }

        // Permet de customiser le header du PDF
        public class CustomHeader : PdfPageEventHelper
        {

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                PdfPTable header = new PdfPTable(1);
                header.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
                header.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

                PdfPCell cell = new PdfPCell(new Phrase($"Rapport du registre des entrées du Tir Olympique Lyonnais généré le {DateTime.Now.ToShortDateString()}"));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                header.AddCell(cell);

                PdfPCell cell1 = new PdfPCell();
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                header.AddCell(cell1);

                header.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - document.TopMargin + header.TotalHeight, writer.DirectContent);
            }
        }

        public void setConfig(string filePath)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);

            // Lien
            string section = "Link";

            string key = "logoLink";
            logoLink = data[section][key];
            key = "LinkBDD";
            sourceBDD = data[section][key];
        }

        // Lors du click sur le bouton exportation, la fonction permet d'ouvrir une fenetre pour le choix du format 
        private void btn_export_Click(object sender, EventArgs e)
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


        private void UC_History_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            LVRect = new Rectangle(listView1.Location.X, listView1.Location.Y, listView1.Width, listView1.Height);
            label1Rect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2Rect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, dtp_start.Height);
            label3Rect = new Rectangle(label3.Location.X, label3.Location.Y, label3.Width, dtp_end.Height);
            DTPE3Rect = new Rectangle(dtp_end.Location.X, dtp_end.Location.Y, dtp_end.Width, dtp_end.Height);
            DTPSRect = new Rectangle(dtp_start.Location.X, dtp_start.Location.Y, dtp_start.Width, dtp_start.Height);
            TBRect = new Rectangle(textBox1.Location.X, textBox1.Location.Y, textBox1.Width, textBox1.Height);
            CBRect = new Rectangle(cb_resultBit.Location.X, cb_resultBit.Location.Y, cb_resultBit.Width, cb_resultBit.Height);
            btnExportRect = new Rectangle(btn_export.Location.X, btn_export.Location.Y, btn_export.Width, btn_export.Height);
            btnRecherhceRect = new Rectangle(btn_recherche.Location.X, btn_recherche.Location.Y, btn_recherche.Width, btn_recherche.Height);
            pbLogoRect = new Rectangle(pb_logo.Location.X, pb_logo.Location.Y, pb_logo.Width, pb_logo.Height);
        }

        // Pour le responsive 
        private void UC_History_Resize(object sender, EventArgs e)
        {
            if (logoLink == null || logoLink == "")
                return;

            resizeControl(LVRect, listView1);
            resizeControl(label1Rect, label1);
            resizeControl(label2Rect, label2);
            resizeControl(label3Rect, label3);
            resizeControl(DTPE3Rect, dtp_end);
            resizeControl(DTPSRect, dtp_start);
            resizeControl(TBRect, textBox1);
            resizeControl(CBRect, cb_resultBit);
            resizeControl(btnExportRect, btn_export);
            resizeControl(btnRecherhceRect, btn_recherche);
            resizeControl(pbLogoRect, pb_logo);

            pb_logo.Size = new Size(pb_logo.Height, pb_logo.Height);

            LoadAndDisplayResizedImage(logoLink, pb_logo.Width, pb_logo.Height, pb_logo);

            if (this.Size.Width > 1000 || this.Size.Height > 800)
            {
                foreach (ColumnHeader column in listView1.Columns)
                    column.Width = 300;

                listView1.Font = new System.Drawing.Font(listView1.Font.FontFamily, 12); // Agrandir la taille de police des entêtes
                label1.Font = new System.Drawing.Font(label1.Font.FontFamily, 14);

            }
            else
            {
                foreach (ColumnHeader column in listView1.Columns)
                    column.Width = 150;

                listView1.Font = new System.Drawing.Font(listView1.Font.FontFamily, 9); // Agrandir la taille de police des entêtes
                label1.Font = new System.Drawing.Font(label1.Font.FontFamily, 12);

            }
        }

        // Permet d'afficher une image suivant la taille w et h 
        private void LoadAndDisplayResizedImage(string imagePath, int w, int h, PictureBox pb)
        {
            // Charger l'image à partir du chemin
            Image originalImage = Image.FromFile(imagePath);

            int newWidth = w;
            int newHeight = h;

            // Créer une nouvelle image redimensionnée
            Bitmap resizedImage = new Bitmap(originalImage, newWidth, newHeight);

            pb.Image = resizedImage;

            // Libérer la mémoire des ressources
            originalImage.Dispose();
        }
    }
}

