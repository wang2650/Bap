// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright ?ZZZ Projects Inc. All rights reserved.
namespace CommonLib.Extensions.Reflections.ObjectExtension
{
    public static partial class TypeComparison
    {
        /// <summary>
        ///     A T extension method that query if '@this' is class.
        /// </summary>
        /// <typeparam name="T">Generic type parameter.</typeparam>
        /// <param name="this">The @this to act on.</param>
        /// <returns>true if class, false if not.</returns>
        public static bool IsClass<T>(this T @this)
        {
            return @this.GetType().IsClass;
        }
    }
}