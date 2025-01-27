using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_Json_Binary
{
        public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Taetigkeit { get; set; }
        public override string ToString()
        {
            return $"{Name} {Email} {Taetigkeit}";
        }
    }

}
