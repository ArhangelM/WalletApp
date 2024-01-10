using Microsoft.AspNetCore.Mvc;
using WalletApp.BLL.Interfaces;

namespace WalletApp.BLL.Services
{
    [ApiController]
    [Route("[controller]")]
    public class DailyPointsService : ControllerBase, IDailyPointsService
    {

        [HttpGet]
        [Route("[action]")]
        public string GetDailyPoints()
        {
            long points = (long)Math.Round(AmountPoints(DaysForPoints()));

            string[] naming = {"", "K", "M", "B", "KK", "MM", "BB" };
            var index = 0;
            while (true)
            {
                if (points > 1000)
                {
                    index++;
                    var balance = points % 1000;
                    points /= 1000;
                    if (balance >= 500)
                        points++;
                }
                else
                    break;
            }
            
            return $"{points}{naming[index]}";
        }

        private int DaysForPoints()
        {
            var date = DateTime.Now;
            var days = date.Day;
            int season;

            if (date.Month >= 3 && date.Month <= 5)
                season = 1;
            else if (date.Month >= 6 && date.Month <= 8)
                season = 2;
            else if (date.Month >= 9 && date.Month <= 11)
                season = 3;
            else
                season = 4;

            var startMonth = season * 3;
            if (startMonth != date.Month)
            {
                if (startMonth == 12)
                {
                    days += DateTime.DaysInMonth(date.Year, startMonth);
                    startMonth = 1;
                }

                for (int i = startMonth; i < date.Month; i++)
                    days += DateTime.DaysInMonth(date.Year, i);
            }

            return days;
        }
        private decimal AmountPoints(int days)
        {
            decimal points;

            if (days == 1)
                points = 2;
            else if (days == 2)
                points = 5;
            else
            {
                decimal beforeYesterday = 2;
                decimal yesterday = 3;
                points = 5;

                for (int i = 0; i < days - 2; i++)
                {
                    decimal today = beforeYesterday + yesterday * 0.6m;
                    points += today;
                    beforeYesterday = yesterday;
                    yesterday = today;
                }
            }
            return points;
        }
    }
}
