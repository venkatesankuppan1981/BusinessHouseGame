using BusinessHomeGame.Enums;
using BusinessHomeGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessHomeGame.Service
{
    public class PlayGame : IPlayGame
    {
        private const int INITIAL_BANk_AMOUNT = 5000;
        public const int LOTTERY_AMOUNT = 200;
        public const int JAIL_FINE = 150;


        private readonly string[] cells;
        private readonly string[] diceOutputs;
        private readonly int playersCount;

        public List<Player> ListPlayers;
        public int BankAmount;


        public PlayGame(string[] cells, string[] diceOutputs, int players)
        {
            this.cells = cells;
            this.diceOutputs = diceOutputs;
            this.playersCount = players;
            this.ListPlayers = CreatePlayers(players);
            this.BankAmount = INITIAL_BANk_AMOUNT;
        }

        private static List<Player> CreatePlayers(int count)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                players.Add(new Player($"Player {i + 1}"));
            }

            return players;
        }

        public void Play()
        {
            foreach (var diceOutput in diceOutputs)
            {
                var playerDiceOutPuts = diceOutput.Trim().Split(',');

                for (int i = 0; i < playersCount; i++)
                {
                    var cellPosition = GetCellPosition(Convert.ToInt32(playerDiceOutPuts[i]) + ListPlayers[i].DicePosition);
                    CellTypes cellType = (CellTypes)Enum.Parse(typeof(CellTypes), cells[cellPosition - 1]);

                    ListPlayers[i].DicePosition = cellPosition;

                    switch (cellType)
                    {
                        case CellTypes.J://Jailed
                            ListPlayers[i].Jailed(JAIL_FINE);
                            BankAmount += JAIL_FINE;

                            break;
                        case CellTypes.H://Hotel
                            var preOwnedHotelOwner = ListPlayers.Where(p => p.HotelType != HotelTypes.None && p.PlayerName != ListPlayers[i].PlayerName).FirstOrDefault();
                            if (preOwnedHotelOwner != null)
                            {
                                ListPlayers[i].PayRent(preOwnedHotelOwner.HotelType);
                                ListPlayers.Where(p => p.PlayerName == preOwnedHotelOwner.PlayerName).First().GetRent(preOwnedHotelOwner.HotelType);
                            }
                            else
                            {
                                ListPlayers[i].BuyHotel();
                            }

                            break;
                        case CellTypes.L://Lottery
                            ListPlayers[i].GotLottery(LOTTERY_AMOUNT);
                            BankAmount -= LOTTERY_AMOUNT;

                            break;
                        case CellTypes.E://Empty
                            break;
                        default:
                            throw new Exception("Invalid Cell Type");
                    }
                }
            }
        }

        private int GetCellPosition(int position)
        {
            if (position > cells.Length)
            {
                position = cells.Length - position;
            }

            return position < 0 ? -1 * position : position;
        }
    }
}
