using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCinema.Model.Constants
{
    public static class Genres
    {
        public const string All = "Svi";

        public const string Action = "Akcija";

        public const string Fantasy = "Fantazija";

        public const string SportDrama = "Sportska drama";

        public const string Drama = "Drama";

        public const string Music = "Koncertni film";

        public const string Comedy = "Komedija";

        public const string RomCom = "Romantična komedija";

        public const string Horror = "Horror";

        public const string Adventure = "Avantura";

        public static readonly List<string> ListOfGenres = new()
        {
            All,Action,Fantasy,Comedy,Horror,Adventure,SportDrama,Drama,Music,RomCom
        };

    }
}
