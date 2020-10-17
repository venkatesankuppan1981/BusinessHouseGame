using BusinessHomeGame.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessHomeGame.Models
{
    public class Player : IPlayer
    {
        public int Amount { get; set; }
        public string PlayerName { get; set; }
        public int TotalAssets { get; set; }
        public HotelTypes HotelType { get; set; }
        public int DicePosition { get; set; }

        public Player(string name)
        {
            this.Amount = 1000;
            this.TotalAssets = 0;
            this.HotelType = HotelTypes.None;
            this.PlayerName = name;
            this.DicePosition = 0;
        }

        public void BuyHotel()
        {
            switch (HotelType)
            {
                case HotelTypes.Silver:
                    if (Amount >= 100)
                    {
                        UpgradeHotel(HotelTypes.Gold);
                    }

                    break;
                case HotelTypes.Gold:
                    if (Amount >= 200)
                    {
                        UpgradeHotel(HotelTypes.Platinum);
                    }

                    break;
                case HotelTypes.None:
                    if (Amount > 200)
                    {
                        UpgradeHotel(HotelTypes.Silver);
                    }

                    break;
                case HotelTypes.Platinum:
                default:
                    break;
            }
        }

        private void UpgradeHotel(HotelTypes newHotel)
        {
            switch (newHotel)
            {
                case HotelTypes.Silver:
                    TotalAssets = 200;
                    Amount -= 200;
                    HotelType = HotelTypes.Silver;
                    break;
                case HotelTypes.Gold:
                    TotalAssets = 300;
                    Amount -= 100;
                    HotelType = HotelTypes.Gold;
                    break;
                case HotelTypes.Platinum:
                    TotalAssets = 500;
                    Amount -= 200;
                    HotelType = HotelTypes.Platinum;
                    break;
                case HotelTypes.None:
                default:
                    break;
            }
        }

        public void GotLottery(int lottery)
        {
            this.Amount += lottery;
        }

        public void Jailed(int fine)
        {
            this.Amount -= fine;
        }

        public void PayRent(HotelTypes hotelType)
        {
            switch (hotelType)
            {
                case HotelTypes.Silver:
                    this.Amount -= 50;
                    break;
                case HotelTypes.Gold:
                    this.Amount -= 150;
                    break;
                case HotelTypes.Platinum:
                    this.Amount -= 300;
                    break;
                case HotelTypes.None:
                default:
                    break;
            }
        }

        public void GetRent(HotelTypes hotelType)
        {
            switch (hotelType)
            {
                case HotelTypes.Silver:
                    this.Amount += 50;
                    break;
                case HotelTypes.Gold:
                    this.Amount += 150;
                    break;
                case HotelTypes.Platinum:
                    this.Amount += 300;
                    break;
                case HotelTypes.None:
                default:
                    break;
            }
        }
    }
}
