// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright ?ZZZ Projects Inc. All rights reserved.
using System.Reflection;
namespace CommonLib.Extensions.Reflections.ObjectExtension
{
    public static partial class Extensions
    {
        /// <summary>A T extension method that gets property or field.</summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <param name="name">The name.</param>
        /// <returns>The property or field.</returns>
        public static MemberInfo GetPropertyOrField<T>(this T @this, string name)
        {
            PropertyInfo property = @this.GetProperty(name);
            if (property != null)
            {
                return property;
            }

            FieldInfo field = @this.GetField(name);
            if (field != null)
            {
                return field;
            }

            return null;
        }
    }
}