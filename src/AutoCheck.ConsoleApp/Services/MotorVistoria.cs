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
            double percentual = (pontuacaoTotal / pontuacaoMaxima) * 100;

            Console.WriteLine("\n> RESUMO DA PONTUAÇÃO:");
            Console.WriteLine($"  - Pontuação Atingida: {pontuacaoTotal} de {pontuacaoMaxima} pontos possíveis");
            Console.WriteLine($"  - Percentual de Aprovação: {percentual:F1}%");

            string classificacao = "";
            if (percentual >= 90) classificacao = "[ APROVADO COM EXCELÊNCIA ]";
            else if (percentual >= 60) classificacao = "[ APROVADO COM APONTAMENTOS ]";
            else classificacao = "[ REPROVADO NA VISTORIA ]";
            
            Console.WriteLine($"  - Classificação Final: {classificacao}");

            Console.WriteLine("\n> RELATÓRIO DE MANUTENÇÃO:");
            bool temPendencia = false;
            
            Console.WriteLine("  🔴 ITENS CRÍTICOS / REPROVADOS:");
            foreach (var item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Ruim") {
                    Console.WriteLine($"     - {item.Nome}: Reparo/Troca imediata.");
                    temPendencia = true;
                }
            }

            Console.WriteLine("  🟡 ITENS DE ATENÇÃO:");
            foreach (var item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Regular") {
                    Console.WriteLine($"     - {item.Nome}: Revisão preventiva.");
                    temPendencia = true;
                }
            }

            if (!temPendencia) Console.WriteLine("  🟢 Nenhuma pendência mecânica.");
        }
    }
}
