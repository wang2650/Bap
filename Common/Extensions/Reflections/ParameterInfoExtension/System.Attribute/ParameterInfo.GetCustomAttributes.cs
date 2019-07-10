// Description: C# Extension Methods | Enhance the .NET Framework and .NET Core with over 1000 extension methods.
// Website & Documentation: https://csharp-extension.com/
// Issues: https://github.com/zzzprojects/Z.ExtensionMethods/issues
// License (MIT): https://github.com/zzzprojects/Z.ExtensionMethods/blob/master/LICENSE
// More projects: https://zzzprojects.com/
// Copyright ?ZZZ Projects Inc. All rights reserved.
using System;
using System.Reflection;
namespace CommonLib.Extensions.Reflections.ParameterInfoExtensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. A parameter specifies the method
        ///     parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element)
        {
            return Attribute.GetCustomAttributes(element);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, and the type of the custom attribute to search for.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Type attributeType)
        {
            return Attribute.GetCustomAttributes(element, attributeType);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, the type of the custom attribute to search for, and whether to search ancestors of the method
        ///     parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes of type  applied to , or an empty array if no such custom
        ///     attributes exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Type attributeType, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, attributeType, inherit);
        }

        /// <summary>
        ///     Retrieves an array of the custom attributes applied to a method parameter. Parameters specify the method
        ///     parameter, and whether to search ancestors of the method parameter.
        /// </summary>
        /// <param name="element">An object derived from the  class that describes a parameter of a member of a class.</param>
        /// <param name="inherit">If true, specifies to also search the ancestors of  for custom attributes.</param>
        /// <returns>
        ///     An  array that contains the custom attributes applied to , or an empty array if no such custom attributes
        ///     exist.
        /// </returns>
        public static Attribute[] GetCustomAttributes(this ParameterInfo element, Boolean inherit)
        {
            return Attribute.GetCustomAttributes(element, inherit);
        }
    }
}