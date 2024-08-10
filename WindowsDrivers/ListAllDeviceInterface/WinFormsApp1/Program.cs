namespace WinFormsApp1
{
    internal static class Program
    {
        //https://learn.microsoft.com/pt-br/windows/win32/devio/device-events

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}