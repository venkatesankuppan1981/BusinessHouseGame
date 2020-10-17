using BusinessHomeGame.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessHomeGame.Models
{
    public interface IPlayer
    {
        void BuyHotel();
        void GotLottery(int lottery);
        void Jailed(int fine);
        void PayRent(HotelTypes hotelType);
        void GetRent(HotelTypes hotelType);
    }
}
