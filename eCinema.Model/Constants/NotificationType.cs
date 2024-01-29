using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Model.Constants
{
    public static class NotificationTypes
    {
        public const string DayOff = "Neradni dan";

        public const string Trending = "Trending";

        public const string SpecialActions = "Posebne ponude";

        public static readonly List<string> ListOfNotificationTypes = new()
        {
            DayOff,Trending,SpecialActions
        };

    }
}
