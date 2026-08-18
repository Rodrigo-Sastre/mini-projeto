namespace AutoCheck.ConsoleApp.Models
{
    public class ItemVistoria
    {
        public string Nome { get; set; }

        // Inicializamos com um valor padrão para evitar o aviso CS8618
        private string _status = "Bom"; 
        
        public string Status
        {
            get => _status;
            set
            {
                if (value == "Bom" || value == "Regular" || value == "Ruim")
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException("Status inválido! Use 'Bom', 'Regular' ou 'Ruim'.");
                }
            }
        }

        public ItemVistoria(string nome, string status)
        {
            Nome = nome;
            Status = status;
        }
    }
}
