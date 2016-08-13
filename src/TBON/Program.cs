using System;
using System.IO;

namespace TBON
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            TBONClass clazz = new TBONClass("Employees", new string[] { "firstName", "lastName", "pay" });
            clazz.AddObject("1").AddAttribute("firstName", "John").AddAttribute("lastName", "Smith").AddAttribute("pay", "50000");
            clazz.AddObject("2").AddAttribute("firstName", "Jane").AddAttribute("lastName", "Doe").AddAttribute("pay", "55000");
            File.WriteAllText(args[0], clazz.Serialize());
            //File.WriteAllText(args[1], Parser.ParseTBONSource(File.ReadAllText(args[0]))[0].Serialize());
        }
    }
}
