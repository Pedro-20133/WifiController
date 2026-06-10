using System;
using System.Threading;
using System.Windows.Forms;

namespace WifiController
{
    internal static class Program
    {
        // Uma string única para identificar a sua aplicação no sistema operacional.
        // Você pode mudar esse ID para qualquer outro texto/GUID exclusivo.
        private static string mutexId = "Global\\WifiController_Unique_Mutex_Id_12345";

        [STAThread]
        static void Main()
        {
            // Tenta criar ou abrir o Mutex. O 'criouNovo' será true apenas se for a PRIMEIRA instância.
            using (Mutex mutex = new Mutex(true, mutexId, out bool criouNovo))
            {
                if (!criouNovo)
                {
                    // Se 'criouNovo' for false, significa que já existe outra instância rodando.
                    MessageBox.Show("O aplicativo WifiController já está em execução!",
                                    "Aviso",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                    // Retorna imediatamente, impedindo o Application.Run de iniciar o form
                    return;
                }

                // Se chegou aqui, esta é a única instância ativa. O app segue normalmente:
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            // Ao sair do bloco 'using', o Mutex é liberado automaticamente para futuras execuções.
        }
    }
}