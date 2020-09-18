using System;
using System.Collections.Generic;
using System.Text;

namespace GMV.Core.Extensions
{
    public static partial class DateTimeExtensions
    {
        public static int NextQuarterOfTheHour(this DateTime dateTime) => 
            (dateTime.Minute / 15) > 2 ? 0 : ((dateTime.Minute / 15) + 1) * 15;
    }
}
