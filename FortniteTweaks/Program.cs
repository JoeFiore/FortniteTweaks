namespace FortniteTweaks
{
    internal static class Program
    {
        // In Program.cs (or Main method file)
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Global Handler for UI thread exceptions
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Global Handler for non-UI thread exceptions (Task/Async)
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.Run(new QuickActions()); // Or whatever your main form is named
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // This will catch exceptions thrown on the main UI thread
            MessageBox.Show("FATAL UI ERROR: " + e.Exception.Message + "\n\n" + e.Exception.StackTrace, "Unhandled UI Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // This will catch exceptions thrown in background threads/tasks
            MessageBox.Show("FATAL BACKGROUND ERROR: " + (e.ExceptionObject as Exception).Message + "\n\n" + (e.ExceptionObject as Exception).StackTrace, "Unhandled Background Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}