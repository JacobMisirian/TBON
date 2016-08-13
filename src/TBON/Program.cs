using System;
using System.IO;

namespace TBON
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            /*
            TBONClass clazz = new TBONClass("Employee", new string[] { "lastName", "duties"  });
            clazz.AddObject("John").AddAttribute("lastName", "Smith").AddAttribute("duties", new string[] { "manager", "grunt" });
            clazz.AddObject("Suzy").AddAttribute("lastName", "Jenkins");

            File.WriteAllText(args[0], clazz.Serialize());*/

            File.WriteAllText(args[1], Parser.ParseTBONSource(File.ReadAllText(args[0]))[0].Serialize());
        }
    }
}
