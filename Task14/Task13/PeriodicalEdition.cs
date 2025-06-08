using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13;

namespace Task14
{
    public class PeriodicalEdition : Edition
    {
        public string Period { get; set; }    
        public string Type { get; set; }  

        public PeriodicalEdition(string title, string authors, int year, string publisher, int inventoryNumber,
            EditionStatus status, float price, string period, string type)
            : base(title, authors, year, publisher, inventoryNumber, status, price)
        {
            Period = period;
            Type = type;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return baseInfo.Concat(new string[]
            {
                $"Период выхода: {Period}",
                $"Вид периодики: {Type}"
            }).ToArray();
        }
    }
}
