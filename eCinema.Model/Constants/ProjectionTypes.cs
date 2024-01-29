using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Model.Constants
{
    public static class ProjectionTypes
    {
        public const string All = "Svi";

        public const string EveningProjection = "Vecernja projekcija";

        public const string WeekendProjection = "Vikend projekcija";

        public const string MorningProjection = "Jutarnja projekcija";

        public const string SchoolProjection = "Školska projekcija";

        public const string SpecialOffer = "Specialna ponuda";

        public static readonly List<string> ListTypes = new()
        {
            All,EveningProjection,WeekendProjection,MorningProjection,SchoolProjection,SpecialOffer
        };
    }
}
