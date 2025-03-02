﻿using BenchmarkDotNet.Attributes;
using System.Diagnostics;
using System.Drawing;
using frontend;
class Program
{
    static void Main()
    {
        Style red = new Style("test", [new frontend.StyleProperties.Color(ConsoleColor.White, ConsoleColor.Red)]);
        Style cyan = new Style("test", [new frontend.StyleProperties.Color(ConsoleColor.White, ConsoleColor.Cyan)]);
        Textbox card1 = new Textbox(["Jaderný reaktor je zařízení, které umožňuje řízené uvolnění jaderné energie, která je následně využívána pro výrobu elektrické energie, výzkum, vzdělávání atd. V principu lze jadernou energii uvolnit 2 rozdílnými způsoby a podle nich lze reaktory rozdělit na:", "štěpný jaderný reaktor – v tomto reaktoru je jaderná energie získávána pomocí štěpení těžkých jader jako 235U, 239Pu a dalších. Tento typ reaktoru ve světě v drtivé většině převažuje[1] a proto se v běžné literatuře i mluvě pod názvem jaderný reaktor téměř výhradně myslí právě tento druh. Patří mezi ně jak reaktory v jaderných elektrárnách, tak reaktory jaderných ponorek i menší výzkumné reaktory pro různé experimenty, výrobu radiofarmak atd."], [red]);
        Textbox card2 = new Textbox(["Jaderný reaktor pracující na principu štěpení těžkých jader je zařízení, ve kterém se uskutečňuje samovolně se udržující řízená štěpná řetězová reakce.[pozn. 1] Tento fyzikální stav zajišťuje vhodné prostorové uspořádání všech hlavních součástí reaktoru (palivo, moderátor, chladivo, řídící tyče atd.). Uvolněná jaderná energie následně zahřívá palivové soubory. Z nich je teplo odváděno chladivem takovým způsobem, aby nedošlo k přehřátí souborů a byla tak zajištěna bezpečnost provozu reaktoru.", "Neutrony při svém vzniku ze štěpení mají relativně vysokou energii, která jim jen s obtížemi dovoluje štěpit palivo (záleží na izotopu použitého paliva). Naopak pomalé neutrony, zpravidla nazývané „tepelnými neutrony“, jsou 235U schopny štěpit s mnohem větší pravděpodobností. Z tohoto neutronově-fyzikálního hlediska dělíme reaktory na:", "Popsat zjednodušený cyklus neutronů lze na základě obrázku nalevo. V reaktoru je za provozu velké množství neutronů s různými energiemi v různých místech. Popis takové situace lze zjednodušit, pokud budeme uvažovat, že neutrony vznikají v tzv. generacích, kdy vždy naráz vznikne velké množství neutronů v palivu a až poslední z nich zanikne, vzniká generace nová. Toto zjednodušení můžeme použít za předpokladu, že neutrony v reaktoru neinteragují mezi sebou a neovlivňují tak svoji energii a směr letu (tvoří tím osamostatněné skupiny neutronů = generace neutronů). Vzhledem k tomu, že množství atomů na jednotkový objem v reaktoru značně převyšuje hustoty toku neutronů bude většina interakcí připadat na neutron-atom a interakcí neutron-neutron bude velmi málo, je toto zanedbání ospravedlnitelné."], [cyan]);
        card1.MaxWidth = 100;
        card2.MaxWidth = 100;
        Container container = new Container([card1, card2]);
        //container.MaxWidth = Console.WindowWidth;
        RenderManager render = new RenderManager(Console.WindowHeight, Console.WindowWidth, 0, 0);
        ConsolePixel[,] frame = container.RenderElement();
        render.RenderFrame(frame);
        frame = container.RenderElement();
        render.RenderFrame(frame);
        while (container.MaxWidth > 75)
        {
            var toRender = container.RenderElement();
            //render._FrameWidth = toRender.GetLength(0);
            //render._FrameHeight = toRender.GetLength(1);
            render.RenderFrame(toRender);
            Console.SetCursorPosition(0, 0);
            container.MaxWidth -= 1;
            Thread.Sleep(100);
        }
        /*Console.BackgroundColor = ConsoleColor.Black;
        Console.ResetColor();
        Console.WriteLine();
        Console.ReadLine();*/


    }
}