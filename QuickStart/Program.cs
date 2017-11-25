using RouteAssignFetchPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class1 class11 = class1.SetValueByRoute("HashCode2", "sdasdwd2").SetValueByRoute("Classs2.Prop2", "sdasghasfsd").SetValueByRoute("HashCode1", "sda3").SetValueByRoute("Classs2.Classs3.Prop3", "2222223213sda") as Class1;

            Console.WriteLine(class1.GetValueByRoute("HashCode2"));
            Console.WriteLine(class1.GetValueByRoute("Classs2.Prop2"));
            Console.WriteLine(class1.GetValueByRoute("HashCode1"));
            Console.WriteLine(class1.GetValueByRoute("Classs2.Classs3.Prop3"));
            Console.ReadKey();
        }
    }


    [RoutablePropertyAttrubute("Class1")]
    public class Class1 : RouteAssignFetch
    {
        [TargetProperty("HashCode1")]
        public string HashCode1 { get; set; }

        [TargetProperty("HashCode2")]
        public string HashCode2 { get; set; }

        [TargetProperty("Classs2")]
        public Class2 Classs2 { get; set; }


    }

    [RoutablePropertyAttrubute("Class2")]
    public class Class2 : RouteAssignFetch
    {
        [TargetProperty("Prop2")]
        public string Prop2 { get; set; }

        [TargetProperty("Classs3")]
        public Class3 Classs3 { get; set; }
    }


    [RoutablePropertyAttrubute("Class3")]
    public class Class3 : RouteAssignFetch
    {
        [TargetProperty("Prop3")]
        public string Prop3 { get; set; }

    }


}
