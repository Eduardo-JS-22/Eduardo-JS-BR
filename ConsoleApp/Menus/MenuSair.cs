﻿using ConsoleApp.Modelos;

namespace ConsoleApp.Menus;

internal class MenuSair : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.WriteLine("\nTchau tchau :)");
    }
}
