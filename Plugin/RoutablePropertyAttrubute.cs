using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteAssignFetchPlugin
{
    public class RoutablePropertyAttrubute:Attribute
    {
        /// <summary>
        /// 标记为可路由的类
        /// </summary>
        /// <param name="ClassName">类名</param>
        public RoutablePropertyAttrubute(string className)
        {
            this.ClassName = className;
        }
        public string ClassName { get; set; }

    }

    public class TargetPropertyAttribute:Attribute
    {
        public TargetPropertyAttribute(string propertyName,bool routable=true)
        {
            this.PropertyName = propertyName;
            this.Routable = routable;
        }
        public string PropertyName { get; set; }
        public bool Routable { get; set; }
    }
}
