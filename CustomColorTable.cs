namespace ScanCode
{
    internal class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuItemBorder
        {
            get { return Color.Black; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.White; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.White; }
        }
    }
}
