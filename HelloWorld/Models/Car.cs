using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class Car
    {
        public Car() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string Year { get; set; }
        public string Model { get; set; }
    }
}
