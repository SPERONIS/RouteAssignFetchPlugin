using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RouteAssignFetchPlugin
{
    /// <summary>
    /// 路由签名
    /// </summary>
    public class RouteAssignFetch
    {

        /// <summary>
        /// 通过路由取值
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        public object GetValueByRoute(string route)
        {
            string[] routeItems = route.Split('.');
            object obj = this;
            PropertyInfo info = GetTargetType(ref obj, routeItems[0]);
            Type type = info.PropertyType;
            object value = info.GetValue(this, null);
            if (type.GetCustomAttribute(typeof(RoutablePropertyAttrubute)) != null)//TODO：如果没有设置RoutablePropertyAttrubute也可以获取值?s
                return type.GetMethod("GetValueByRoute").Invoke(value, new object[] { string.Join(".", routeItems.Skip(1).Take(routeItems.Length - 1).ToArray()) });
            else
                return value;
        }

        /// <summary>
        /// 通过路由赋值
        /// </summary>
        /// <param name="route"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public RouteAssignFetch SetValueByRoute(string route, object value)
        {
            string[] routeItems = route.Split('.');
            object obj = this;
            object instance = null;
            PropertyInfo info = GetTargetType(ref obj, routeItems[0]);
            Type type = info.PropertyType;
            if (type.GetCustomAttribute(typeof(RoutablePropertyAttrubute)) == null)
            {
                obj.GetType().GetProperty(routeItems[0]).SetValue(obj, value, null);
                return this;
            }
            else
            {
                instance = info.GetValue(obj, null);
                if (instance == null)
                    instance = Activator.CreateInstance(type);
                obj.GetType().GetProperty(routeItems[0]).SetValue(obj, instance, null);
                Attribute _attr = instance.GetType().GetCustomAttribute(typeof(RoutablePropertyAttrubute));
                if (_attr == null)
                    return this;
                else
                {
                    object res = type.GetMethod("SetValueByRoute").Invoke(instance, new object[] { string.Join(".", routeItems.Skip(1).Take(routeItems.Length - 1).ToArray()), value });
                    instance = res;
                }

            }
            return this;
        }



        private PropertyInfo GetTargetType(ref object obj, string routeItem)
        {
            PropertyInfo[] infos = obj.GetType().GetProperties();
            foreach (PropertyInfo info in infos)
            {
                TargetPropertyAttribute objAttr = info.GetCustomAttribute(typeof(TargetPropertyAttribute)) as TargetPropertyAttribute;
                if (objAttr != null && objAttr.Routable && objAttr.PropertyName == routeItem)
                {
                    return info;
                }
            }
            throw new Exception("未找到节点路由：" + routeItem);
        }
    }
}
