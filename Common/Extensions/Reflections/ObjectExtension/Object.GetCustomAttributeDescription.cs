// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright ?ZZZ Projects Inc. All rights reserved.
using System;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
namespace CommonLib.Extensions.Reflections.ObjectExtension
{
    public static partial class Extensions
    {
        /// <summary>
        ///     An object extension method that gets description attribute.
        /// </summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>The description attribute.</returns>
        public static string GetCustomAttributeDescription(this object value)
        {
            var type = value.GetType();

            var attributes = type.IsEnum ?
                type.GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute)).ToList() :
                type.GetCustomAttributes(typeof(DescriptionAttribute)).ToList();

            if (attributes.Count == 0)
            {
                return null;
            }
            if (attributes.Count == 1)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }

            throw new Exception(string.Format("Ambiguous attribute. Multiple custom attributes of the same type found: {0} attributes found.", attributes.Count));
        }

        /// <summary>An object extension method that gets description attribute.</summary>
        /// <param name="value">The value to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>The description attribute.</returns>
        public static string GetCustomAttributeDescription(this object value, bool inherit)
        {
            var type = value.GetType();

            //var attributes = type.IsEnum ?
            //    type.GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit) :
            //    type.GetCustomAttributes(typeof(DescriptionAttribute));
            string attrDescription = string.Empty;
            int attrLength = 0;
            if (type.IsEnum)
            {
                var attrs = type.GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit);

                attrLength = attrs.Length;

                attrDescription = attrLength == 0 ? string.Empty : attrLength == 1 ? ((DescriptionAttribute)attrs[0]).Description: string.Empty;
            }
            else
            {
                var attrs = type.GetCustomAttributes(typeof(DescriptionAttribute)).ToList();

                attrLength = attrs.Count;

                attrDescription = attrLength == 0 ? string.Empty : attrLength == 1 ? ((DescriptionAttribute)attrs[0]).Description : string.Empty;
            }



            if (attrLength == 0)
            {
                return null;
            }
            if (attrLength == 1)
            {
                return attrDescription;
            }

            throw new Exception(string.Format("Ambiguous attribute. Multiple custom attributes of the same type found: {0} attributes found.", attrLength));
        }

        /// <summary>An object extension method that gets description attribute.</summary>
        /// <param name="value">The value to act on.</param>
        /// <returns>The description attribute.</returns>
        public static string GetCustomAttributeDescription(this MemberInfo value)
        {
            var attributes = value.GetCustomAttributes(typeof(DescriptionAttribute)).ToList();

            if (attributes.Count == 0)
            {
                return null;
            }
            if (attributes.Count == 1)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }

            throw new Exception(string.Format("Ambiguous attribute. Multiple custom attributes of the same type found: {0} attributes found.", attributes.Count));
        }

        /// <summary>An object extension method that gets description attribute.</summary>
        /// <param name="value">The value to act on.</param>
        /// <param name="inherit">true to inherit.</param>
        /// <returns>The description attribute.</returns>
        public static string GetCustomAttributeDescription(this MemberInfo value, bool inherit)
        {
            var attributes = value.GetCustomAttributes(typeof(DescriptionAttribute), inherit);

            if (attributes.Length == 0)
            {
                return null;
            }
            if (attributes.Length == 1)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }

            throw new Exception(string.Format("Ambiguous attribute. Multiple custom attributes of the same type found: {0} attributes found.", attributes.Length));
        }
    }
}