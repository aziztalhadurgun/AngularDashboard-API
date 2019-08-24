using System;
using System.Collections.Generic;

namespace Advantage.API
{
    public class Helpers
    {
        private static Random _rand = new Random();

        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSuffix.Count;

            if (names.Count >= maxNames)
            {
                throw new System.InvalidOperationException("Maximum number of unique names exceeded!");
            } 
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            var bizName  = prefix + suffix;

            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }

            return bizName;
        }

        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState()
        {
            return GetRandom(trState);
        }

        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100,5000);
        }

        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-50);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan  = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes),0);

            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;

            if (timePassed < minLeadTime)
            {
                return null;
            }

            return orderPlaced.AddDays(_rand.Next(7,14));
        }

        private static readonly List<string> trState = new List<string>()
        {
            "Adana","Adıyaman","Afyonkarahisar","Aksaray","Amasya","Ankara","Antalya","Ardahan",
            "Artvin","Aydın","Ağrı","Balıkesir","Bartın","Batman","Bayburt","Bilecik","Bingöl",
            "Bitlis","Bolu","Burdur","Bursa","Denizli","Diyarbakır","Düzce","Edirne","Elazığ",
            "Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun","Gümüşhane","Hakkâri","Hatay",
            "İstanbul","İzmir","Kahramanmaraş","Karabük","Karaman","Kars","Kastamonu","Kayseri",
            "Kilis","Kocaeli","Konya","Kütahya","Kırklareli","Kırıkkale","Kırşehir","Malatya",
            "Manisa","Mardin","Mersin","Muğla","Muş","Nevşehir","Niğde","Ordu","Osmaniye","Rize",
            "Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirdağ","Tokat","Trabzon","Tunceli","Uşak",
            "Van","Yalova","Yozgat","Zonguldak","Çanakkale","Çankırı","Çorum","Isparta","Iğdır",
            "Şanlıurfa","Şırnak"
        };

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "MainSt",
            "Enterprise",
            "Ready",
            "Quick",
            "Budget",
            "Peak",
            "Magic",
            "Family",
            "Comfort"
        };

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Comporation",
            "Co",
            "Logistics",
            "Transit",
            "Bakery",
            "Goods",
            "Foods",
            "Cleaners",
            "Hotels",
            "Planners",
            "Automotive",
            "Books"
        };
    }
}