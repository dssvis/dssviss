using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13;

namespace Task14
{
    public class FictionEdition : Edition
    {
        public string Genre { get; set; }
        public string Language { get; set; }
        public string Type { get; set; } // Проза или Стихи

        public FictionEdition(string title, string authors, int year, string publisher, int inventoryNumber,
            EditionStatus status, float price, string genre, string language, string type)
            : base(title, authors, year, publisher, inventoryNumber, status, price)
        {
            Genre = genre;
            Language = language;
            Type = type;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return baseInfo.Concat(new string[]
            {
                $"Жанр: {Genre}",
                $"Язык произведения: {Language}",
                $"Вид произведения: {Type}"
            }).ToArray();
        }
    }
}
