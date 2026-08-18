using System;
using System.Collections.Generic;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

var vistorias = new List<Veiculo>();
var motor = new MotorVistoria();
bool executando = true;

while (executando)
{
    Console.WriteLine("\n--- AUTOCHECK .NET - MENU PRINCIPAL ---");
    Console.WriteLine("1 - Realizar Nova Vistoria");
    Console.WriteLine("2 - Exibir Relatório das Vistorias");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine() ?? "";

    switch (opcao)
    {
        case "1":
            RealizarVistoria(vistorias);
            break;
        case "2":
            ExibirRelatorios(vistorias, motor);
            break;
        case "0":
            executando = false;
            Console.WriteLine("Encerrando sistema...");
            break;
        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}

static void RealizarVistoria(List<Veiculo> vistorias)
{
    // Lógica para coletar dados do veículo e itens de inspeção
    // (Dica: use Console.ReadLine para Marca, Modelo, Ano, etc.)
    Console.WriteLine("Funcionalidade de Nova Vistoria em desenvolvimento...");
}

static void ExibirRelatorios(List<Veiculo> vistorias, MotorVistoria motor)
{
    if (vistorias.Count == 0)
    {
        Console.WriteLine("Nenhuma vistoria realizada até o momento.");
        return;
    }
    foreach (var v in vistorias)
    {
        motor.ProcessarVistoria(v);
    }
}
