﻿using ConsoleApp.Modelos;

namespace ConsoleApp.Menus;

internal class MenuAvaliarAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        base.Executar(bandasRegistradas);

        ExibirTituloDaOpcao("Avaliar album");
        Console.Write("Digite o nome da banda que deseja avaliar: ");
        string nomeDaBanda = Console.ReadLine()!;
        Banda banda = bandasRegistradas[nomeDaBanda];
        if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {
            Console.Write("Digite o nome do album que deseja avaliar: ");
            string nomeDoAlbum = Console.ReadLine()!;
            if (banda.Albuns.Any(a => a.NomeAlbum.Equals(nomeDoAlbum)))
            {
                Album album = banda.Albuns.First(a => a.NomeAlbum.Equals(nomeDoAlbum));
                Console.Write($"Qual a nota que o album {nomeDoAlbum} merece: ");
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
                album.AdicionarNota(nota);
                Console.WriteLine($"\nA nota {nota.Nota} foi registrada com sucesso para o album {nomeDoAlbum}");
                Thread.Sleep(2000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"\nO album {nomeDoAlbum} não foi encontrado!");
                Console.WriteLine("Digite uma tecla para voltar ao menu principal");
                Console.ReadKey();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
