using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos { get; set; }
        public double CapacidadeCargaToneladas { get; set; }

        public Caminhao(string marca, string modelo, int ano, double quilometragem, int qtdEixos, double carga)
            : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadeEixos = qtdEixos;
            this.CapacidadeCargaToneladas = carga;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            var checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Tacógrafo");
            checklist.Add("Sistema de Freios a Air");
            checklist.Add("Trava e Lona da Caçamba");
            return checklist;
        }
    }
}
