using IniParser.Model;
using IniParser;
using ScanCode.SQL;

namespace ScanCode.UserControls
{
    public partial class UC_Login : UserControl
    {
        public event EventHandler<UserLoggedInEventArgs> UserLoggedIn;

        string configPath, logoLink, sourceBDD;

        private Rectangle tbMDPRect; // Pour le responsive sur les supports (voir CDC F2) (Tablette, pc fixe, écran déporté)
        private Rectangle tbIDRect; // A changer dans la version suivante (voir projet Locorama (fill dock))
        private Rectangle label1Rect;
        private Rectangle label2Rect;
        private Rectangle btnRect;
        private Rectangle logoRect;
        private Size formOriginalSize;

        public UC_Login(string _configPath)
        {
            InitializeComponent();
            configPath = _configPath;
            setConfig(configPath);
        }

        // Lors du click sur le bouton connexion 
        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string password = tb_mdp.Text;

            UserAdmin userAdmin = new UserAdmin(sourceBDD);
            bool isValidLogin = userAdmin.CheckLoginCredentials(username, password); // Vérification si le compte avec mdp existe 

            if (isValidLogin) // Si la connexion est bonne
            {
                UserLoggedIn?.Invoke(this, new UserLoggedInEventArgs(tb_username.Text));

                tb_username.Text = "";
                tb_mdp.Text = "";
            }
            else // Sinon message d'erreur 
            {
                MessageBox.Show("Identifiants invalides. Veuillez réessayer.", "Erreur de Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_Login_Load(object sender, EventArgs e)
        {
            formOriginalSize = this.Size;
            btnRect = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            label1Rect = new Rectangle(label1.Location.X, label1.Location.Y, label1.Width, label1.Height);
            label2Rect = new Rectangle(label2.Location.X, label2.Location.Y, label2.Width, label2.Height);
            tbMDPRect = new Rectangle(tb_mdp.Location.X, tb_mdp.Location.Y, tb_mdp.Width, tb_mdp.Height);
            tbIDRect = new Rectangle(tb_username.Location.X, tb_username.Location.Y, tb_username.Width, tb_username.Height);
            logoRect = new Rectangle(pb_logo.Location.X, pb_logo.Location.Y, pb_logo.Width, pb_logo.Height);

            pb_logo.Image = Image.FromFile(logoLink);
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
        private void UC_Login_Resize(object sender, EventArgs e)
        {
            if (logoLink == null || logoLink == "")
                return;

            resizeControl(btnRect, button1);
            resizeControl(label2Rect, label2);
            resizeControl(label1Rect, label1);
            resizeControl(tbMDPRect, tb_mdp);
            resizeControl(tbIDRect, tb_username);
            resizeControl(logoRect, pb_logo);

            if (this.Size.Width > 1000 || this.Size.Height > 800)
            {
                label2.Font = new Font(label2.Font.FontFamily, 14);
                label1.Font = new Font(label1.Font.FontFamily, 14);
            }
            else
            {
                label2.Font = new Font(label2.Font.FontFamily, 9);
                label1.Font = new Font(label1.Font.FontFamily, 9);
            }

            pb_logo.Size = new Size(pb_logo.Height, pb_logo.Height);

            LoadAndDisplayResizedImage(logoLink, pb_logo.Width, pb_logo.Height, pb_logo);
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
