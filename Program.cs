 1 - Console.WriteLine("Hello, World!");
       1 + using System;
       2 + using AutoCheck.ConsoleApp.Models;
       3 + using AutoCheck.ConsoleApp.Services;
       4 +
       5 + // Teste rápido para validar o motor
       6 + var meuCarro = new Carro("Toyota", "Corolla", 2021, 45000, 4);
       7 + meuCarro.AdicionarItemVistoriado("Nível de Óleo do Motor", "Bom");
       8 + meuCarro.AdicionarItemVistoriado("Triângulo de Sinalização", "Ruim");
       9 +
      10 + var motor = new MotorVistoria();
      11 + motor.ProcessarVistoria(meuCarro);