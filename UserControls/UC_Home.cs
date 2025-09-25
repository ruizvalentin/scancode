using HtmlAgilityPack;
using IniParser.Model;
using IniParser;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ScanCode.SQL;
using System.Net.NetworkInformation;

namespace ScanCode.UserControls
{
    public partial class UC_Home : UserControl
    {
        public System.Windows.Forms.Timer timer;
        HtmlWeb web = new HtmlWeb();
        HtmlAgilityPack.HtmlDocument doc;
        string configPath, actuelImgUser, actuelGreenRed, logoLink, redLink, sourceBDD, greenLink, Wlastname, Wcertif, Wfirstname, Widentificationnumber, Wresult, Wclassresult, userImageLink, chromeDriverLink, Wphoto;

        private Rectangle listBoxRect; // Pour le responsive sur les supports (voir CDC F2) (Tablette, pc fixe, écran déporté)
        private Rectangle labelNom; // A changer dans la version suivante (voir projet Locorama (fill dock))
        private Rectangle labelPrenom;
        private Rectangle labelIden;
        private Rectangle labelError;
        private Rectangle label1Rect;
        private Rectangle label2Rect;
        private Rectangle labelRect;
        private Rectangle btnRect;
        private Rectangle pb1Rect;
        private Rectangle pb2Rect;
        private Rectangle pbLogoRect;
        private Rectangle tbRect;
        private Rectangle label_hcRect;
        private Size formOriginalSize;


        public UC_Home(string _configPath)
        {
            InitializeComponent();
            FillListBoxWithData();
            configPath = _configPath;

            // Initialisation du Timer
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 secondes en millisecondes, pour la selection et utilisation lecteur QRCode et textbox
            timer.Tick += Timer_Tick;
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size; // Pour le responsive 
            listBoxRect = new Rectangle(lv_todayScan.Location.X, lv_todayScan.Location.Y, lv_todayScan.Width, lv_todayScan.Height);
            labelNom = new Rectangle(lb_nom.Location.X, lb_nom.Location.Y, lb_nom.Width, lb_nom.Height);
            labelPrenom = new Rectangle(lb_prenom.Location.X, lb_prenom.Location.Y, lb_prenom.Width, lb_prenom.Height);
            labelIden = new Rectangle(lb_identificationNumber.Location.X, lb_identificationNumber.Location.Y, lb_identificationNumber.Width, lb_identificationNumber.Height);
            labelError = new Rectangle(lb_messageError.Location.X, lb_messageError.Location.Y, lb_messageError.Width, lb_messageError.Height);
            label1Rect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2Rect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            labelRect = new Rectangle(label.Location.X, label.Location.Y, label.Width, label.Height);
            btnRect = new Rectangle(btn_start.Location.X, btn_start.Location.Y, btn_start.Width, btn_start.Height);
            pb1Rect = new Rectangle(pictureBox1.Location.X, pictureBox1.Location.Y, pictureBox1.Width, pictureBox1.Height);
            pb2Rect = new Rectangle(pictureBox2.Location.X, pictureBox2.Location.Y, pictureBox2.Width, pictureBox2.Height);
            pbLogoRect = new Rectangle(pb_logo.Location.X, pb_logo.Location.Y, pb_logo.Width, pb_logo.Height);
            tbRect = new Rectangle(textBoxScannedData.Location.X, textBoxScannedData.Location.Y, textBoxScannedData.Width, textBoxScannedData.Height);
            label_hcRect = new Rectangle(label_hc.Location.X, label_hc.Location.Y, label_hc.Width, label_hc.Height);

            setConfig(configPath);
            resetChamps();
            LoadAndDisplayResizedImage(logoLink, pb_logo.Width, pb_logo.Height, pb_logo); // logo du club, mise à l'echelle

            btn_start.Visible = false;
            label_hc.Visible = false;

            UserScanNI userScanNI = new UserScanNI(sourceBDD);
            List<string> data = userScanNI.SelectAll(); // Check s'il y a des scans hors internet

            if (data.Count > 0)
            {
                btn_start.Visible = true; // Faire apparaitre le bouton pour relire les scans enregistrés 
                label_hc.Visible = true;
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            textBoxScannedData.Focus(); // Pour le lecteur de QRCode (Rubrique contrainte CDC)
        }

        private string getbyID(string _id) // retourne le champs en string suivant l'ID pour le webscrapping 
        {
            string data = doc.GetElementbyId(_id).InnerText;
            return System.Net.WebUtility.HtmlDecode(data);
        }

        private string getClassByID(string _id) // Retourne le champs en string suivant l'ID avec une classe pour le webscrapping 
        {
            HtmlNode targetElement = doc.DocumentNode.SelectSingleNode($"//*[@id='{_id}']");

            // Vérifier si l'élément a été trouvé et récupérer la classe
            if (targetElement != null)
            {
                string elementClass = targetElement.GetAttributeValue("class", "");
                return elementClass;
            }

            return null;
        }

        //
        // Lorsque le lecteur de QRCode scan, click sur enter at the end, vérification de l'information scannée 
        //
        private void TextBoxScannedData_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Vérifiez si la touche entrée (Enter) est pressée 
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                resetChamps(); // On supprime tout ce qui aurait pu être rentrer avant par erreur 

                string scannedDataTempo = textBoxScannedData.Text.Trim();
                if (scannedDataTempo.Length < 5) // URL au moins > 5, première vérification
                {
                    textBoxScannedData.Text = string.Empty;

                    AutoClosingMessageBox.Show("Attetion, veuilliez scanner le QRCode seulement !", "Error", 15000);

                    return;
                }

                string firstFiveCharacters = scannedDataTempo.Substring(0, 5);

                if (int.TryParse(firstFiveCharacters, out int result)) // S'il y a des chiffres, erreur de l'utilisateur car scan du barcode et pas du QRCode
                {
                    UserScanBarCode userScanBarCode = new UserScanBarCode(sourceBDD);
                    userScanBarCode.insert(scannedDataTempo, DateTime.Now);

                    textBoxScannedData.Text = string.Empty;

                    AutoClosingMessageBox.Show("Attetion, veuilliez scanner le QRCode seulement et non pas le BarCode", "Error", 15000);

                    return;
                }
                else if (!scannedDataTempo.Contains("http")) // Si pas http au début, erreur de l'utilisateur 
                {
                    textBoxScannedData.Text = string.Empty;
                    AutoClosingMessageBox.Show("Attetion, veuilliez scanner le QRCode seulement !", "Error", 15000);
                    return;
                }

                string scannedData = scannedDataTempo;
                int startIndex = scannedDataTempo.IndexOf("http");

                if (startIndex != -1)
                    scannedData = scannedDataTempo.Substring(startIndex);

                if (!IsInternetAvailable()) // Si pas de connexion, enregistrement en BDD en attendant de retrouver une connexion 
                {
                    UserScanNI userScanNI = new UserScanNI(sourceBDD);
                    userScanNI.insert(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), scannedData);

                    MessageBox.Show("Scan enregistré en attendant le retour de la connexion internet", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScannedData.Text = string.Empty;

                    btn_start.Visible = true;
                    label_hc.Visible = true;

                    return;
                }

                ScanLink(scannedData, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), true); // Appel de la fonction si les prérequis précédent sont correct 
            }
        }

        //
        // Permet d'enregistrer la photo de la licence 
        //
        private void btnDownloadImage_Click(string url, string identificationNumber)
        {

            // Emplacement où enregistrer l'image localement 
            string localFilePath = Path.Combine(userImageLink, identificationNumber + ".jpg");
            if (File.Exists(localFilePath))
                return;

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(chromeDriverLink);
            service.HideCommandPromptWindow = true; // Pour cacher la fenêtre de la console du chromedriver

            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--window-size=50,30"); // Dimensions de la fenêtre
            options.AddArgument(GetWindowPositionArgument()); // Position de la fenêtre en haut à droite


            // Créer une instance du navigateur ChromeDriver
            using (IWebDriver driver = new ChromeDriver(service, options))
            {
                try
                { // Simulation click de l'utilisateur
                    driver.Navigate().GoToUrl(url);
                    Thread.Sleep(2000);
                    IWebElement imageElement = driver.FindElement(By.Id(Wphoto));

                    OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(driver);
                    action.ContextClick(imageElement).Perform();

                    Thread.Sleep(1000);

                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait(localFilePath);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(2000);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du téléchargement de l'image : " + ex.Message);
                }
                finally
                {
                    driver.Quit();
                }
            }
        }

        // Utile pour positionner la fenetre 
        static string GetWindowPositionArgument()
        {
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            int x = screen.Width - 500;
            return $"--window-position={x},0";
        }

        // Permet d'ajouter un scan à la list du jour
        private void FillListBoxWithData()
        {
            int nbScanToday = 0;

            UserScan userScan = new UserScan(sourceBDD);
            List<string> data = userScan.selectFirstLastNameToday();

            nbScanToday = userScan.selectNbScanToday();
            
            // Vérifier si la liste contient des données
            if (data.Count > 0)
            {
                lv_todayScan.Items.Clear();

                // Ajouter les éléments à la ListBox
                foreach (string element in data)
                {
                    ListViewItem item = new ListViewItem(element.Split(';').First());
                    item.SubItems.Add(element.Split(';')[1]);
                    item.SubItems.Add(element.Split(';')[2]);
                    item.SubItems.Add(element.Split(';').Last());
                    lv_todayScan.Items.Add(item);
                }
            }

            label1.Text = "Scan de la journée : " + nbScanToday.ToString();

            lv_todayScan.Scrollable = true;
        }

        // SI l'utilisateur click sur le bouton récupération, on vérifie les scans hors connexion save 
        private void btn_start_Click(object sender, EventArgs e)
        {
            DialogResult resultYesNo = MessageBox.Show("Voulez-vous vérifier les scans enregistrés ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultYesNo == DialogResult.Yes)
            {
                if (!IsInternetAvailable()) // Vérification de la connexion 
                {
                    MessageBox.Show("La connexion internet n'est toujours pas rétablie");
                    return;
                }

                UserScanNI userScanNI = new UserScanNI(sourceBDD);
                List<string> data = userScanNI.SelectAll(); // Selection de tout les scans

                if (data.Count > 0)
                {
                    foreach (string element in data)
                    {
                        bool result = ScanLink(element.Split(';')[1], element.Split(';')[0], false); // On réalise le scan 

                        if (result)
                            userScanNI.Delete(element.Split(';')[0]); // si result good, on delete de la bdd pour ne pas le refaire
                    }

                    btn_start.Visible = false;
                    label_hc.Visible = false;

                }
                MessageBox.Show("Vérification terminée, " + data.Count + " scan ajouté(s)");
            }
        }

        // Permet de reset l'ensemble des champs à l'écran 
        private void resetChamps()
        {
            lb_nom.Text = "";
            lb_prenom.Text = "";
            lb_messageError.Visible = false;
            lb_identificationNumber.Text = "";
            pictureBox2.Visible = false;
            pictureBox1.Image = null;
        }

        // Vérification de si une connexion internet existe belle est bien 
        private bool IsInternetAvailable()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                // Requête à une adresse qui est généralement disponible pour tester la connectivité
                Ping ping = new Ping();
                try
                {
                    PingReply reply = ping.Send("www.google.com");
                    if (reply != null && reply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                }
                catch (PingException)
                {
                    return false;
                }
            }

            return false;
        }

        // Permet de scan un QRCode et de récupérer l'ensemble des informations 
        private bool ScanLink(string _link, string _date, bool _updateDashBoard)
        {
            try
            {
                doc = web.Load(_link);

                textBoxScannedData.Enabled = false;

                // On récupère toute les infos (nom, prénom ...)
                string lastName = getbyID(Wlastname);
                string firstName = getbyID(Wfirstname);
                string identificationNumber = getbyID(Widentificationnumber) ?? "0";
                string result = getbyID(Wresult);
                string classResult = getClassByID(Wclassresult);
                string certif = getbyID(Wcertif);
                certif = certif.Split(':').Last();
                int resultBit = 0;

                if (classResult != null) // Si une donnée est bien présente (bonne adresse web)
                {
                    if (classResult == "MessageValidation") // Si une donnée est bien présente pour valider ou non la licence
                    {
                        resultBit = 1;
                        btnDownloadImage_Click(_link, identificationNumber); // téléchargement de l'image de l'utilisateur

                        if (_updateDashBoard)
                        {
                            lb_nom.Text = firstName; // Affichage des informations
                            lb_prenom.Text = lastName;
                            lb_messageError.Visible = false;
                            lb_messageError.Text = "";
                            lb_identificationNumber.Text = identificationNumber;
                            if (File.Exists(greenLink))
                                LoadAndDisplayResizedImage(greenLink, pictureBox1.Width, pictureBox1.Height, pictureBox1);
                            actuelGreenRed = greenLink;

                            if (certif != null && certif != "" && certif.Trim() == "EXPIRÉ") // Vérification du statut du certif médical 
                            {
                                lb_messageError.Visible = true;
                                lb_messageError.Text = "Attention, certificat médical expiré";
                            }

                            pictureBox2.Visible = true;
                            LoadAndDisplayResizedImage(userImageLink + identificationNumber + ".jpg", pictureBox2.Width, pictureBox2.Height, pictureBox2); // Photo du user
                            actuelImgUser = userImageLink + identificationNumber + ".jpg";
                        }
                    }
                    else // Si pas de licence
                    {
                        resultBit = 0;

                        if (_updateDashBoard)
                        {
                            if (File.Exists(redLink))
                                LoadAndDisplayResizedImage(redLink, pictureBox1.Width, pictureBox1.Height, pictureBox1);
                            actuelGreenRed = redLink;

                            lb_messageError.Visible = true; // Indication d'une ereur 
                            lb_nom.Text = firstName; // Affichage des informations présente 
                            lb_prenom.Text = lastName;
                            lb_messageError.Text = result;
                            lb_identificationNumber.Text = identificationNumber;

                            if (identificationNumber != "")
                            {
                                btnDownloadImage_Click(_link, identificationNumber);
                                pictureBox2.Visible = true;
                                LoadAndDisplayResizedImage(userImageLink + identificationNumber + ".jpg", pictureBox2.Width, pictureBox2.Height, pictureBox2);
                                actuelImgUser = userImageLink + identificationNumber + ".jpg";
                            }
                        }
                    }
                }


                // SQL et enregistrement des donées 
                UserScan userScan = new UserScan(sourceBDD);
                userScan.insert(lastName == "" ? "Null" : lastName, firstName == "" ? "Null" : firstName, Int32.Parse(identificationNumber == "" ? "0" : identificationNumber), result, resultBit, _date, 1, certif == "" ? "Null" : certif.Trim());

                textBoxScannedData.Enabled = true;
                textBoxScannedData.Text = string.Empty;

                FillListBoxWithData(); // Ajout du scan à la list 

                Params parametre = new Params(sourceBDD);
                parametre.PerformBackup(parametre.SelectLinkBackupDaily(), "backup_tempo"); // Backup temporaire 

                return true;

            }
            catch (Exception ex)
            {
                textBoxScannedData.Enabled = true;
                textBoxScannedData.Text = string.Empty;
                MessageBox.Show("Erreur scan qrcode : " + ex.Message);

                return false;
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

        // Récupération des params de config
        public void setConfig(string filePath)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);

            // Lien
            string section = "Link";

            string key = "logoLink";
            logoLink = data[section][key];
            key = "greenLink";
            greenLink = data[section][key];
            key = "redLink";
            redLink = data[section][key];
            key = "userImageLink";
            userImageLink = data[section][key];
            key = "chromeDriverLink";
            chromeDriverLink = data[section][key];
            key = "LinkBDD";
            sourceBDD = data[section][key];

            // WebScrapping
            section = "Scrapping";

            key = "lastName";
            Wlastname = data[section][key];
            key = "firstName";
            Wfirstname = data[section][key];
            key = "identificationNumber";
            Widentificationnumber = data[section][key];
            key = "result";
            Wresult = data[section][key];
            key = "classResult";
            Wclassresult = data[section][key];
            key = "photo";
            Wphoto = data[section][key];
            key = "certif";
            Wcertif = data[section][key];
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
        private void UC_Home_Resize(object sender, EventArgs e)
        {
            if (logoLink == null || logoLink == "")
                return;

            resizeControl(listBoxRect, lv_todayScan);
            resizeControl(labelNom, lb_nom);
            resizeControl(labelPrenom, lb_prenom);
            resizeControl(labelIden, lb_identificationNumber);
            resizeControl(labelError, lb_messageError);
            resizeControl(label1Rect, label1);
            resizeControl(label2Rect, label2);
            resizeControl(labelRect, label);
            resizeControl(btnRect, btn_start);
            resizeControl(pb1Rect, pictureBox1);
            resizeControl(pb2Rect, pictureBox2);
            resizeControl(pbLogoRect, pb_logo);
            resizeControl(tbRect, textBoxScannedData);
            resizeControl(label_hcRect, label_hc);

            pictureBox1.Size = new Size(pictureBox1.Height, pictureBox1.Height);

            pb_logo.Size = new Size(pb_logo.Height, pb_logo.Height);
            LoadAndDisplayResizedImage(logoLink, pb_logo.Width, pb_logo.Height, pb_logo);

            if (this.Size.Width > 1000 || this.Size.Height > 800)
            {
                label.Font = new Font(label.Font.FontFamily, 14);
                label1.Font = new Font(label1.Font.FontFamily, 14);
                lb_identificationNumber.Font = new Font(lb_identificationNumber.Font.FontFamily, 12);
                lb_messageError.Font = new Font(lb_messageError.Font.FontFamily, 12);
                lb_nom.Font = new Font(lb_nom.Font.FontFamily, 12);
                lb_prenom.Font = new Font(lb_prenom.Font.FontFamily, 12);
                label_hc.Font = new Font(label_hc.Font.FontFamily, 12);


                foreach (ColumnHeader column in lv_todayScan.Columns)
                {
                    column.Width = 350;
                }

                lv_todayScan.Font = new Font(lv_todayScan.Font.FontFamily, 12); // Agrandir la taille de police des entêtes

            }
            else
            {
                label.Font = new Font(label.Font.FontFamily, 12);
                label1.Font = new Font(label1.Font.FontFamily, 12);
                lb_identificationNumber.Font = new Font(lb_identificationNumber.Font.FontFamily, 9);
                lb_messageError.Font = new Font(lb_messageError.Font.FontFamily, 9);
                lb_nom.Font = new Font(lb_nom.Font.FontFamily, 9);
                lb_prenom.Font = new Font(lb_prenom.Font.FontFamily, 9);
                label_hc.Font = new Font(label_hc.Font.FontFamily, 9);

                foreach (ColumnHeader column in lv_todayScan.Columns)
                {
                    column.Width = 150;
                }

                lv_todayScan.Font = new Font(lv_todayScan.Font.FontFamily, 9); // Agrandir la taille de police des entêtes

            }

            if (pictureBox1.Image != null)
                LoadAndDisplayResizedImage(actuelGreenRed, pictureBox1.Width, pictureBox1.Height, pictureBox1);
            if (pictureBox2.Image != null)
                LoadAndDisplayResizedImage(actuelImgUser, pictureBox2.Width, pictureBox2.Height, pictureBox2);
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, pictureBox2.ClientRectangle,
                Color.Black, 3, ButtonBorderStyle.Solid,
                Color.Black, 3, ButtonBorderStyle.Solid,
                Color.Black, 3, ButtonBorderStyle.Solid,
                Color.Black, 3, ButtonBorderStyle.Solid);
        }

        private void lb_messageError_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, textBoxScannedData.ClientRectangle,
                Color.Red, 3, ButtonBorderStyle.Solid,
                Color.Red, 3, ButtonBorderStyle.Solid,
                Color.Red, 3, ButtonBorderStyle.Solid,
                Color.Red, 3, ButtonBorderStyle.Solid);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}