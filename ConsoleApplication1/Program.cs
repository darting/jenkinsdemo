using Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        static void Main(string[] args) {

            using (var db = new SchoolContext()) {
                while (true) {
                    var cmd = Console.ReadLine();
                    switch (cmd) {
                        case "q":
                            return;
                        case "list":
                            var l = db.Students.ToList();
                            l.ForEach(s => Console.WriteLine("{0}", s.ToString()));
                            break;
                        case "h":
                            break;
                    }
                    Console.WriteLine("");
                    Console.WriteLine("cmd done.");
                }
            }
        }
    }
}
