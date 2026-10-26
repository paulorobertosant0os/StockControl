using System.Text.Json;

namespace StockControl.Data
{
    /// <summary>
    /// Resolve a string de conexão usada pelo sistema, nesta ordem:
    /// 1. variável de ambiente STOCKCONTROL_CONNECTION;
    /// 2. chave "StockControl" em ConnectionStrings do appsettings.json;
    /// 3. instância local padrão (SQL Server local com autenticação do Windows).
    /// </summary>
    internal static class Conexao
    {
        public const string VariavelAmbiente = "STOCKCONTROL_CONNECTION";

        private const string Padrao =
            @"Server=.\;Database=StockControlDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static string StringConexao { get; } = Resolver();

        private static string Resolver()
        {
            string? doAmbiente = Environment.GetEnvironmentVariable(VariavelAmbiente);

            if (!string.IsNullOrWhiteSpace(doAmbiente))
            {
                return doAmbiente.Trim();
            }

            string? doArquivo = LerDoArquivo();

            return string.IsNullOrWhiteSpace(doArquivo) ? Padrao : doArquivo.Trim();
        }

        private static string? LerDoArquivo()
        {
            try
            {
                string caminho = Path.Combine(AppContext.BaseDirectory, "appsettings.json");

                if (!File.Exists(caminho))
                {
                    return null;
                }

                using var documento = JsonDocument.Parse(File.ReadAllText(caminho));

                if (documento.RootElement.TryGetProperty("ConnectionStrings", out JsonElement conexoes)
                    && conexoes.TryGetProperty("StockControl", out JsonElement valor))
                {
                    return valor.GetString();
                }
            }
            catch (JsonException)
            {
                // Arquivo inválido: segue para o padrão.
            }
            catch (IOException)
            {
                // Arquivo em uso/indisponível: segue para o padrão.
            }

            return null;
        }
    }
}
