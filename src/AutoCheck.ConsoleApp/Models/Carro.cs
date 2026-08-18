using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas { get; set; }

        public Carro(string marca, string modelo, int ano, double quilometragem, int qtdPortas)
            : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadePortas = qtdPortas;
        }

        public override List<string> ObterChecklistObrigatorio()
        {
            var checklist = base.ObterChecklistObrigatorio();
            checklist.Add("Estepe e Macaco");
            checklist.Add("Triângulo de Sinalização");
            checklist.Add("Ar Condicionado Funcional");
            return checklist;
        }
    }
}
