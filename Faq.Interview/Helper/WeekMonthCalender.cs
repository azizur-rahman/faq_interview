using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FAQ.Interview.Helper
{
    public class WeekMonthCalender
    {
        public string MonthName { get; set; }

        public DateTime DayDate { get; set; }

        public int WeekSerialNo {get; set;}

        public int CalaculateWeekNumber(int monthDayNumber)
        {
            int weekNumber = 0;
            if ( monthDayNumber >= 1 && monthDayNumber <=7)
            {
                weekNumber = 1;
            }
            else if (monthDayNumber >= 8 && monthDayNumber <= 14)
            {
                weekNumber = 2;
            }
            else if (monthDayNumber >= 15 && monthDayNumber <= 21)
            {
                weekNumber = 3;
            }
            else if (monthDayNumber >= 22 && monthDayNumber <= 28)
            {
                weekNumber = 4;
            }
            else if (monthDayNumber >= 29)
            {
                weekNumber = 5;
            }

            return weekNumber;
        }

    }
}