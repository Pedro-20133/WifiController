using Renci.SshNet;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WifiController
{
    public partial class MainForm : Form
    {
        private readonly string caminhoArquivo = "configs.json";
        private const string IpPadrao = "192.168.1.1";
        private const string UsuarioPadrao = "admin";

        public MainForm()
        {
            InitializeComponent();
        }

        // Centraliza a lógica de conexão SSH de forma assíncrona para não travar a UI
        private async Task ExecutarOperacaoSshAsync(Func<SshClient, Task> acao, Action<bool> atualizarStatusUI)
        {
            string hostAtual = hostTxt.Text;
            string usuarioAtual = userTxt.Text;
            string senhaAtual = pswTxt.Text;

            // Desabilita botões temporariamente para evitar cliques duplos
            DefinirEstadoBotoes(false);

            await Task.Run(() =>
            {
                try
                {
                    using (var client = new SshClient(hostAtual, usuarioAtual, senhaAtual))
                    {
                        client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(4);
                        client.Connect();

                        if (client.IsConnected)
                        {
                            acao(client).Wait();
                            Invoke(new Action(() => atualizarStatusUI(true)));
                        }
                        client.Disconnect();
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        atualizarStatusUI(false);
                        MessageBox.Show($"Erro na operação SSH:\n{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private void DefinirEstadoBotoes(bool ativo)
        {
            on.Enabled = ativo;
            off.Enabled = ativo;
        }

        private async void on_Click(object sender, EventArgs e)
        {
            await ExecutarOperacaoSshAsync(async (client) =>
            {
                var cmd = client.CreateCommand("wifi up");
                cmd.Execute();
            }, (sucesso) =>
            {
                DefinirEstadoBotoes(true);
                if (sucesso) MessageBox.Show("O Wi-Fi foi reativado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async void off_Click(object sender, EventArgs e)
        {
            await ExecutarOperacaoSshAsync(async (client) =>
            {
                var cmd = client.CreateCommand("wifi down");
                cmd.Execute();
            }, (sucesso) =>
            {
                DefinirEstadoBotoes(true);
                if (sucesso) MessageBox.Show("O Wi-Fi foi desativado com sucesso! O cabo continua ativo.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async void validar_Click(object sender, EventArgs e)
        {
            status.Text = "Status: Conectando...";
            status.ForeColor = Color.Orange;

            await ExecutarOperacaoSshAsync(async (client) => { await Task.CompletedTask; }, (sucesso) =>
            {
                if (sucesso)
                {
                    status.Text = "Status: Conectado com sucesso!";
                    status.ForeColor = Color.Green;
                    DefinirEstadoBotoes(true);
                }
                else
                {
                    status.Text = "Status: Erro de conexão!";
                    status.ForeColor = Color.Red;
                    DefinirEstadoBotoes(false);
                }
            });
        }

        private void SalvarConfiguracoes(string ip, string usuario, string senha)
        {
            try
            {
                var config = new FormConfig { Host = ip, User = usuario, Psw = senha };
                string jsonString = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoArquivo, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar configurações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefinirCamposETela(string ip, string usuario, string senha)
        {
            hostTxt.Text = ip;
            userTxt.Text = usuario;
            pswTxt.Text = senha;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            DefinirCamposETela(IpPadrao, UsuarioPadrao, UsuarioPadrao);
            SalvarConfiguracoes(IpPadrao, UsuarioPadrao, UsuarioPadrao);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(caminhoArquivo))
            {
                try
                {
                    string jsonString = File.ReadAllText(caminhoArquivo);
                    var config = JsonSerializer.Deserialize<FormConfig>(jsonString);
                    DefinirCamposETela(config.Host, config.User, config.Psw);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar configurações. Aplicando padrões: " + ex.Message);
                }
            }

            // Fallback caso o arquivo não exista ou esteja corrompido
            DefinirCamposETela(IpPadrao, UsuarioPadrao, UsuarioPadrao);
            SalvarConfiguracoes(IpPadrao, UsuarioPadrao, UsuarioPadrao);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalvarConfiguracoes(hostTxt.Text, userTxt.Text, pswTxt.Text);
        }
    }

    public class FormConfig
    {
        public string Host { get; set; }
        public string User { get; set; }
        public string Psw { get; set; }
    }
}