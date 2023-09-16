namespace UI.UIServices
{
    public sealed class Services : IServices
    {
        private readonly IStatus status;
        
        public Services(MainWindow mainWindow)
        {
            status = new Status(mainWindow.StatusLabel);
        }

        public IStatus Status => status ?? new StatusDummy();
    }
}
