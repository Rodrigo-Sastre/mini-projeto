using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models
{
    public abstract class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double Quilometragem { get; set; }
        public List<ItemVistoria> VistoriaRealizada { get; set; }

        public Veiculo(string marca, string modelo, int ano, double quilometragem)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Quilometragem = quilometragem;
            VistoriaRealizada = new List<ItemVistoria>();
        }

        public void AdicionarItemVistoriado(string nome, string status)
        {
            VistoriaRealizada.Add(new ItemVistoria(nome, status));
        }

        public virtual List<string> ObterChecklistObrigatorio()
        {
            return new List<string> { "Nível de Óleo do Motor", "Bateria e Sistema Elétrico", "Documentação Regularizada" };
        }
    }
}

