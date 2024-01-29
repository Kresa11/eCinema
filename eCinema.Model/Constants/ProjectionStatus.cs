using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Model.Constants
{
    public static class ProjectionStatus
    {
        public const string All = "Svi";

        public const string Scheduled = "Zakazana";

        public const string Started = "Počela";

        public const string Finished = "Završila";

        public const string Canceled = "Otkazana";

        public static readonly List<string> ListOfStatuses = new()
        {
            All,Scheduled,Started,Finished,Canceled
        };
    }
}
