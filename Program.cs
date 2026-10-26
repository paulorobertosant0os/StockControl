namespace StockControl
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (_, e) => MostrarFalha(e.Exception);

            Application.Run(new Form1());
        }

        private static void MostrarFalha(Exception ex)
        {
            try
            {
                Tema.MostrarErro(
                    null,
                    "Algo deu errado",
                    "Ocorreu um erro inesperado e a ação não foi concluída.\n\nDetalhes: " + ex.Message);
            }
            catch
            {
                // Nunca deixa o tratamento de erro derrubar o aplicativo.
            }
        }
    }
}
