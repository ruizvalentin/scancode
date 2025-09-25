using IniParser;
using IniParser.Model;
using OfficeOpenXml;
using ScanCode.SQL;
using ScanCode.UserControls;

namespace ScanCode
{
    public partial class Form1 : Form
    {
        static Form1? _obj;
        List<ToolStripMenuItem> list = new List<ToolStripMenuItem>();
        Fonctions functions = new Fonctions();
        public System.Windows.Forms.Timer timerGlobal;
        string configPath = "config.ini", sourceBDD;

        public static Form1 Instance // Instance de form pour la selection du user control
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Form1();
                }
                return _obj;
            }
        }

        public Panel PanelContainer // Pour la gestion du user control dans le panel
        {
            get { return panel; }
            set { panel = value; }
        }

        private class MyRenderer : ToolStripProfessionalRenderer // Permet de customiser les couleurs du menustrip (demande CDC F12)
        {
            public MyRenderer() : base(new CustomColorTable()) { }
        }

        public Form1()
        {
            InitializeComponent();

            menuStrip1.Renderer = new MyRenderer(); // Application maj menustrip
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            setConfig(configPath); // lecture du config.ini et des informations

            Params parametre = new Params(sourceBDD);
            // Calculer la prochaine date de sauvegarde en fonction de l'intervalle spécifié
            DateTime lastBackupDate = parametre.SelectLastBackupDate();
            DateTime nextBackupDate = lastBackupDate.AddDays(parametre.SelectIntervalleDay());

            // Vérifier si la prochaine sauvegarde doit être effectuée aujourd'hui
            if (nextBackupDate.Date <= DateTime.Today)
            {
                parametre.PerformBackup(parametre.SelectLinkBackup(), DateTime.Now.ToString("ddMMyyyyHHmmss"));
                parametre.UpdateNextBackupDate(DateTime.Now.AddDays(parametre.SelectIntervalleDay()));
                parametre.UpdateOldBackupDate(DateTime.Now);
            }

            _obj = this;

            UC_Home uc_home = new UC_Home(configPath);
            uc_home.Dock = DockStyle.Fill;
            panel.Controls.Add(uc_home);
            timerGlobal = uc_home.timer; // timer utile pour selectionner le textbox ou le lecteur de QRCode doit ecrire la donnée 
            timerGlobal.Start();

            list.Add(acceuilToolStripMenuItem);
            list.Add(historiqueToolStripMenuItem);
            list.Add(connexionToolStripMenuItem);

            functions.changeColorMainStrip(acceuilToolStripMenuItem, list);

            this.WindowState = FormWindowState.Maximized;
        }

        private void acceuilToolStripMenuItem_Click(object sender, EventArgs e) // Lors de la selection de la page acceuil
        {
            if (!Form1.Instance.PanelContainer.Controls.ContainsKey("UC_Home"))
            {
                UC_Home ccf = new UC_Home(configPath);
                ccf.Dock = DockStyle.Fill;
                Form1.Instance.PanelContainer.Controls.Add(ccf);
            }
            functions.changeColorMainStrip(acceuilToolStripMenuItem, list);
            Form1.Instance.PanelContainer.Controls["UC_Home"].BringToFront();

            timerGlobal.Start();
        }

        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e) // Lors de la selection de la page historique
        {
            if (!Form1.Instance.PanelContainer.Controls.ContainsKey("UC_History"))
            {
                UC_History ccf = new UC_History(configPath);
                ccf.Dock = DockStyle.Fill;
                Form1.Instance.PanelContainer.Controls.Add(ccf);
            }
            functions.changeColorMainStrip(historiqueToolStripMenuItem, list);
            Form1.Instance.PanelContainer.Controls["UC_History"].BringToFront();

            timerGlobal.Stop();
        }

        private void connexionToolStripMenuItem_Click(object sender, EventArgs e) // Lors de la selection de la page params (connexion)
        {
            if (!Form1.Instance.PanelContainer.Controls.ContainsKey("UC_Login"))
            {
                UC_Login ccf = new UC_Login(configPath);
                ccf.UserLoggedIn += OnUserLoggedIn;
                ccf.Dock = DockStyle.Fill;
                Form1.Instance.PanelContainer.Controls.Add(ccf);
            }
            functions.changeColorMainStrip(connexionToolStripMenuItem, list);
            Form1.Instance.PanelContainer.Controls["UC_Login"].BringToFront();

            timerGlobal.Stop();
        }

        private void OnUserLoggedIn(object sender, UserLoggedInEventArgs e) // Si l'utilisateur est connecté  
        {
            string additionalInfo = e.AdditionalInfo;

            UC_Params ccf = new UC_Params(additionalInfo, configPath);
            ccf.Dock = DockStyle.Fill;
            Form1.Instance.PanelContainer.Controls.Add(ccf);

            functions.changeColorMainStrip(connexionToolStripMenuItem, list);
            Form1.Instance.PanelContainer.Controls["UC_Params"].BringToFront();

            timerGlobal.Stop();
        }

        public void setConfig(string filePath) // lecture du config.ini
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile(filePath);

            // Lien
            string section = "Link";

            string key = "LinkBDD";
            sourceBDD = data[section][key];
        }
    }
}