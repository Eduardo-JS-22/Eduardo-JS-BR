﻿using ConsoleApp.Modelos;
using ConsoleApp.Menus;

Banda queen = new Banda("Queen");
queen.AdicionarNota(new Avaliacao(10));
queen.AdicionarNota(new Avaliacao(8));
queen.AdicionarNota(new Avaliacao(9));
Banda pinkFloyd = new("Pink Floyd");
Banda acDc = new("AC/DC");
acDc.AdicionarNota(new Avaliacao(6));
acDc.AdicionarNota(new Avaliacao(10));
acDc.AdicionarNota(new Avaliacao(8));

// Screen Sound
//List<string> listaDasBandas = new List<string> { "Queen", "Pink Floyd", "AC/DC" };
Dictionary<string, Banda> bandasRegistradas = new();
bandasRegistradas.Add(queen.NomeBanda, queen);
bandasRegistradas.Add(pinkFloyd.NomeBanda, pinkFloyd);
bandasRegistradas.Add(acDc.NomeBanda, acDc);

Dictionary<int, Menu> opcoesMenu = new();
opcoesMenu.Add(1, new MenuRegistrarBanda());
opcoesMenu.Add(2, new MenuRegistrarAlbum());
opcoesMenu.Add(3, new MenuMostrarBandasRegistradas());
opcoesMenu.Add(4, new MenuAvaliarBanda());
opcoesMenu.Add(5, new MenuAvaliarAlbum());
opcoesMenu.Add(6, new MenuExibirDetalhes());
opcoesMenu.Add(0, new MenuSair());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para avaliar um album");
    Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoesMenu.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExebido = opcoesMenu[opcaoEscolhidaNumerica];
        menuASerExebido.Executar(bandasRegistradas);
        if(opcaoEscolhidaNumerica != 0)
        {
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("\nOpção inválida");
        Thread.Sleep(3000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();