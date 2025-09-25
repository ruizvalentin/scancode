namespace ScanCode
{
    public partial class CustomExportDialogue : Form
    {
        public bool ExportToPdf { get; private set; } = false;
        public bool ExportToExcel { get; private set; } = false;

        public CustomExportDialogue()
        {
            InitializeComponent();
        }

        private void btnExportToPdf_Click(object sender, EventArgs e) // Lors de l'export en pdf, maj du statut
        {
            ExportToPdf = true;
            Close();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e) // Lors de l'export en excel, maj du statut
        {
            ExportToExcel = true;
            Close();
        }
    }
}

