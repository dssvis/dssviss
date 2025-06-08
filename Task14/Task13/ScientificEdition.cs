using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13;

namespace Task14
{
    public class ScientificEdition : Edition
    {
        public string Field { get; set; }
        public string Annotation { get; set; }

        public ScientificEdition(string title, string authors, int year, string publisher, int inventoryNumber,
            EditionStatus status, float price, string field, string annotation)
            : base(title, authors, year, publisher, inventoryNumber, status, price)
        {
            Field = field;
            Annotation = annotation;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            return baseInfo.Concat(new string[]
            {
                $"Область науки и техники: {Field}",
                $"Аннотация: {Annotation}"
            }).ToArray();
        }
    }
}
