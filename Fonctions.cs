namespace ScanCode
{
    internal class Fonctions
    {
        public Fonctions()
        {
        }

        public void changeColorMainStrip(ToolStripMenuItem item, List<ToolStripMenuItem> listTool)
        {
            foreach (ToolStripMenuItem list in listTool)
            {
                list.BackColor = Color.Gold;
            }

            item.BackColor = Color.White;
        }
    }
}




