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
    Console.WriteLine("\n--- NOVA VISTORIA ---");
    
    Console.Write("Tipo de veículo (Carro, Moto, Caminhao): ");
    string tipo = Console.ReadLine() ?? "";
    
    Console.Write("Marca: ");
    string marca = Console.ReadLine() ?? "";
    
    Console.Write("Modelo: ");
    string modelo = Console.ReadLine() ?? "";
    
    int ano = LerInt("Ano: ");
    double km = LerDouble("Quilometragem: ");

    Veiculo? novoVeiculo = null;

    if (tipo.Equals("Carro", StringComparison.OrdinalIgnoreCase))
    {
        int portas = LerInt("Quantidade de Portas: ");
        novoVeiculo = new Carro(marca, modelo, ano, km, portas);
    }
    else if (tipo.Equals("Moto", StringComparison.OrdinalIgnoreCase))
    {
        int cilindradas = LerInt("Cilindradas: ");
        novoVeiculo = new Moto(marca, modelo, ano, km, cilindradas);
    }
    else if (tipo.Equals("Caminhao", StringComparison.OrdinalIgnoreCase))
    {
        int eixos = LerInt("Quantidade de Eixos: ");
        double carga = LerDouble("Capacidade de Carga (Ton): ");
        novoVeiculo = new Caminhao(marca, modelo, ano, km, eixos, carga);
    }
    else
    {
        Console.WriteLine("Tipo de veículo inválido.");
        return;
    }

    foreach (var item in novoVeiculo.ObterChecklistObrigatorio())
    {
        Console.Write($"Status do item '{item}' (Bom/Regular/Ruim): ");
        string entrada = Console.ReadLine() ?? "";
        
        if (string.IsNullOrEmpty(entrada)) entrada = "Bom"; 
        
        string status = char.ToUpper(entrada[0]) + entrada.Substring(1).ToLower();
        
        novoVeiculo.AdicionarItemVistoriado(item, status);
    }

    vistorias.Add(novoVeiculo);
    Console.WriteLine("\nVistoria registrada com sucesso!");
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

static int LerInt(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        if (int.TryParse(Console.ReadLine(), out int valor))
            return valor;
        Console.WriteLine("Entrada inválida. Digite um número inteiro.");
    }
}

static double LerDouble(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        if (double.TryParse(Console.ReadLine(), out double valor))
            return valor;
        Console.WriteLine("Entrada inválida. Digite um número válido.");
    }
}
