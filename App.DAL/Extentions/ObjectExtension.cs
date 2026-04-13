using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Extentions
{
   public static class ObjectExtension
    {
        public static bool IsNull<T>(this T dest)
        {
            return dest is null;
        }

        /// <summary>
        /// Kiểm tra xem đối tượng có thuộc tính với tên chỉ định không.
        /// </summary>
        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        /// <summary>
        /// Lấy giá trị của thuộc tính được chỉ định từ đối tượng.
        /// Trả về giá trị mặc định của kiểu T nếu thuộc tính không tồn tại.
        /// </summary>
        public static T GetPropertyValue<T>(this object obj, string propName)
        {
            if (!obj.HasProperty(propName))
            {
                return default;
            }
            return (T)obj.GetType().GetProperty(propName).GetValue(obj, null);
        }

        /// <summary>
        /// Cố gắng thiết lập giá trị cho thuộc tính của đối tượng.
        /// Trả về true nếu thành công, ngược lại trả về false.
        /// </summary>
        public static bool TrySetProperty(this object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lấy mô tả của lớp từ thuộc tính `DescriptionAttribute` nếu có.
        /// </summary>
        public static string GetClassDescription<T>(this T t) where T : class
        {
            var descriptionAttribute = t.GetType().GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0]
                as DescriptionAttribute;

            return descriptionAttribute.Description;
        }

        /// <summary>
        /// Lấy mô tả của thành viên (thuộc tính hoặc phương thức) từ thuộc tính `DescriptionAttribute` nếu có.
        /// </summary>
        public static string GetMemberDescription<T>(this T t, string memberName) where T : class
        {
            var memberInfo = t.GetType().GetMember(memberName)[0];
            var descriptionAttribute = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)[0] as DescriptionAttribute;
            return descriptionAttribute.Description;
        }

        /// <summary>
        /// Lấy mô tả của thuộc tính từ thuộc tính `DescriptionAttribute` nếu có.
        /// Trả về null nếu không tìm thấy thuộc tính hoặc mô tả.
        /// </summary>
        public static string? GetDescription<T>(this string fieldName) where T : class
        {
            string? result;
            var propertyInfo = typeof(T).GetProperty(fieldName.ToString());
            if (propertyInfo != null)
            {
                try
                {
                    var descriptionAttribute = propertyInfo.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
                    result = descriptionAttribute?.Description ?? string.Empty;
                }
                catch
                {
                    result = null;
                }
            }
            else
            {
                result = null;
            }

            return result;
        }
    }
}
