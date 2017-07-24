using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data
{
    public static class AsteroidNames
    {
        private static readonly System.Random Random = new System.Random();

        private static readonly List<string> Names = new List<string>(128);

        static AsteroidNames()
        {
            InitializeNames();
        }

        public static void Reset()
        {
            Names.Clear();
            InitializeNames();
        }

        public static string RandomName()
        {
            var indexOfName = Random.Next(0, Names.Count);
            var name = Names[indexOfName];

            // prevent duplicate names
            Names.RemoveAt(indexOfName);

            if (!Names.Any())
            {
                Debug.Log("Used the asteroid name. Next name will be a duplicate.");
            }

            return name;
        }

        private static void InitializeNames()
        {
            Names.Add("Abydos");
            Names.Add("Altair IV");
            Names.Add("Anarres");
            Names.Add("Andromeda");
            Names.Add("Apophis");
            Names.Add("Aquarius");
            Names.Add("Aquila");
            Names.Add("Ara");
            Names.Add("Aries");
            Names.Add("Arrakis");
            Names.Add("Athas");
            Names.Add("Auriga");
            Names.Add("Bara Magna");
            Names.Add("Beachworld");
            Names.Add("Boötes");
            Names.Add("Byss");
            Names.Add("Camelopardalis");
            Names.Add("Cancer");
            Names.Add("Canes Venatici");
            Names.Add("Canopus III");
            Names.Add("Caprica");
            Names.Add("Cardassia IV");
            Names.Add("Carina");
            Names.Add("Cassiopeia");
            Names.Add("Centaurus");
            Names.Add("Cepheus");
            Names.Add("Ceti Alpha V");
            Names.Add("Cetus");
            Names.Add("Columba");
            Names.Add("Coma Berenices");
            Names.Add("Corona Borealis");
            Names.Add("Corvus");
            Names.Add("Crater");
            Names.Add("Crux");
            Names.Add("Cygnus");
            Names.Add("Delphinus");
            Names.Add("Dorvan V");
            Names.Add("Dozaria");
            Names.Add("Draco");
            Names.Add("Equuleus");
            Names.Add("Eridanus");
            Names.Add("Fire");
            Names.Add("Fyrine IV");
            Names.Add("Gamma X");
            Names.Add("Gemini");
            Names.Add("Geonosis");
            Names.Add("Grus");
            Names.Add("Gunsmoke");
            Names.Add("Hercules");
            Names.Add("Hydra");
            Names.Add("Imecka");
            Names.Add("Jakku");
            Names.Add("Katina");
            Names.Add("Kerona");
            Names.Add("Kharak");
            Names.Add("Khoros");
            Names.Add("Klendathu");
            Names.Add("Kobol");
            Names.Add("Kolarus III");
            Names.Add("Korhal");
            Names.Add("Korriban");
            Names.Add("Leo");
            Names.Add("Lepus");
            Names.Add("Libra");
            Names.Add("Lyra");
            Names.Add("M6-117");
            Names.Add("Marak's World");
            Names.Add("Motavia");
            Names.Add("Nacrion");
            Names.Add("Noveria");
            Names.Add("Ocampa");
            Names.Add("Octans");
            Names.Add("Ophiuchus");
            Names.Add("Orion");
            Names.Add("Osiris IV");
            Names.Add("Pallas");
            Names.Add("Pavo");
            Names.Add("Pegasus");
            Names.Add("Perdide");
            Names.Add("Perseus");
            Names.Add("Phoenix");
            Names.Add("Pisces");
            Names.Add("Plyuk");
            Names.Add("Puppis");
            Names.Add("Resurgam");
            Names.Add("Rock Star");
            Names.Add("Sagitta");
            Names.Add("Sagittarius");
            Names.Add("Salt");
            Names.Add("Scorpius");
            Names.Add("Serpens");
            Names.Add("Socorro");
            Names.Add("Starbuck");
            Names.Add("Sur'Kesh");
            Names.Add("Tatooine");
            Names.Add("Taurus");
            Names.Add("Thessia");
            Names.Add("Titania");
            Names.Add("Tophet");
            Names.Add("Torga IV");
            Names.Add("Toroth");
            Names.Add("Triangulum");
            Names.Add("Trisol");
            Names.Add("Tyree");
            Names.Add("Vega");
            Names.Add("Vela");
            Names.Add("Virgo");
            Names.Add("Vulcan");
        }
    }
}