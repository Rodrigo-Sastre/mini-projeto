using System;
using System.Collections.Generic;
using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services
{
    public class MotorVistoria
    {
        public void ProcessarVistoria(Veiculo veiculo)
        {
            double pontuacaoTotal = 0;
            int totalItens = veiculo.VistoriaRealizada.Count;

            foreach (var item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Bom") pontuacaoTotal += 10;
                else if (item.Status == "Regular") pontuacaoTotal += 5;
            }

            double pontuacaoMaxima = totalItens * 10;
            double percentual = ((double)pontuacaoTotal / pontuacaoMaxima) * 100;

            string classificacao = "NÃO CLASSIFICADO";
            if (percentual >= 90) classificacao = "[ APROVADO COM EXCELÊNCIA ]";
            else if (percentual >= 60) classificacao = "[ APROVADO COM APONTAMENTOS ]";
            else classificacao = "[ REPROVADO NA VISTORIA ]";

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("> RESUMO DA PONTUAÇÃO:");
            Console.WriteLine($"  - Pontuação Atingida: {pontuacaoTotal} de {pontuacaoMaxima} pontos possíveis");
            Console.WriteLine($"  - Percentual de Aprovação: {percentual:F1}%");
            Console.WriteLine($"  - Classificação Final: {classificacao}");
            Console.WriteLine("-------------------------------------------------------------------");

            Console.WriteLine($"\n> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");
            foreach (var item in veiculo.VistoriaRealizada)
            {
                string marcador = "";
                int pontos = 0;
                if (item.Status == "Bom") { marcador = "[OK]"; pontos = 10; }
                else if (item.Status == "Regular") { marcador = "[ !]"; pontos = 5; }
                else if (item.Status == "Ruim") { marcador = "[ X]"; pontos = 0; }

                Console.WriteLine($"  {marcador} {item.Nome.PadRight(30, '-')} Status: {item.Status} ({pontos} pts)");
            }

            Console.WriteLine("\n> RELATÓRIO DE MANUTENÇÃO:");
            bool temPendencia = false;

            Console.WriteLine("  🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):");
            foreach (var item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Ruim")
                {
                    Console.WriteLine($"     - {item.Nome}: Repor equipamento obrigatório ausente/danificado.");
                    temPendencia = true;
                }
            }

            Console.WriteLine("\n  🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):");
            foreach (var item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Regular")
                {
                    Console.WriteLine($"     - {item.Nome}: Revisão preventiva.");
                    temPendencia = true;
                }
            }

            if (!temPendencia) Console.WriteLine("  🟢 Nenhuma pendência mecânica.");
        }
    }
}