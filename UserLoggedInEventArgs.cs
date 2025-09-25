namespace ScanCode
{
    public class UserLoggedInEventArgs : EventArgs
    {
        public string AdditionalInfo { get; }

        public UserLoggedInEventArgs(string additionalInfo)
        {
            AdditionalInfo = additionalInfo;
        }
    }
}
