using System;
using System.Collections.Generic;
using System.Text;

namespace Module_4.Enums
{
    public static class FriendlyName
    {
        public static string GetFriendlyMonthName(Month month)
        {
            return month switch
            {
                Month.January => "Январь",
                Month.February => "Февраль",
                Month.March => "Март",
                Month.April => "Апрель",
                Month.May => "Май",
                Month.June => "Июнь",
                Month.July => "Июль",
                Month.August => "Август",
                Month.September => "Сентябрь",
                Month.October => "Октябрь",
                Month.November => "Ноябрь",
                Month.December => "Декабрь"
            };
        }
    }
}
