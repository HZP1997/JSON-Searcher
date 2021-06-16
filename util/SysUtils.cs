using System.Reflection;
using System;

namespace Utils {
  public class SysUtils {
    public dynamic DynamicCast(object entity, Type to) {
      var openCast = this.GetType().GetMethod("Cast", BindingFlags.Static | BindingFlags.NonPublic);
      var closeCast = openCast.MakeGenericMethod(to);
      return closeCast.Invoke(entity, new[] { entity });
    }
    
    static T Cast<T>(object entity) where T : class {
      return entity as T;
    }

    public static T ConvertObject<T>(object input) {
      return (T) Convert.ChangeType(input, typeof(T));
    }
  }
}