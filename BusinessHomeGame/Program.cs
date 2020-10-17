using BusinessHomeGame.Service;
using System;

namespace BusinessHomeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Cells detail :");
            var cells = Console.ReadLine().Trim().Split(',');
            Console.WriteLine("Enter Dice Output : ");
            var diceOutputs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            Console.WriteLine("Number of Players : ");
            var players = Convert.ToInt32(Console.ReadLine());

            PlayGame playGame = new PlayGame(cells, diceOutputs, players);
            playGame.Play();

            Console.WriteLine("");

            for (int i = 0; i < playGame.ListPlayers.Count; i++)
            {
                Console.WriteLine($"{playGame.ListPlayers[i].PlayerName} has total money {playGame.ListPlayers[i].Amount} and asset of amount : {playGame.ListPlayers[i].TotalAssets}");
            }
            Console.WriteLine($"Balance at Bank : {playGame.BankAmount}");

            Console.ReadLine();
        }
    }
}
