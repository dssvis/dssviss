using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task13;

namespace Task14
{
    public class Department : IEnumerable<Edition>
    {
        public string Name { get; set; }
        public int Count => editions.Count;
        private List<Edition> editions;

        public Department(string name, IEnumerable<Edition> editions)
        {
            Name = name;
            this.editions = new List<Edition>();

            foreach (var ed in editions)
            {
                if (!this.editions.Contains(ed)) 
                    this.editions.Add(ed);
            }
        }

        public IEnumerator<Edition> GetEnumerator() => editions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
