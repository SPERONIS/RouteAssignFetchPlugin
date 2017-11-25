# RouteAssignFetchPlugin
## C#中使用实例路由设置和访问属性


###### 在需要被路由的类头加上RoutablePropertyAttrubute特性,继承基类RouteAssignFetch，在需要被route到的属性加上TargetProperty特性。

    [RoutablePropertyAttrubute("Class1")]
    public class Class1 : RouteAssignFetch
    {
        public string HashCode1 { get; set; }

        [TargetProperty("HashCode2")]
        public string HashCode2 { get; set; }

        [TargetProperty("Classs2")]
        public Class2 Classs2 { get; set; }
    }
###### 使用时：

  Class1 class1 = new Class1();
  Class1 class11 = SetValueByRoute("Classs2.Classs3.Prop3","2222223213sda") as Class1;
  Console.WriteLine(class1.GetValueByRoute("Classs2.Classs3.Prop3"));
  
 
