﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace CommonLib.Extensions.Reflections.GetSignature
{
    static partial class SignatureExtension
    {

        internal static string GetShortSignature(this Type @this)
        {
            if (@this == typeof(bool))
            {
                return "bool";
            }
            if (@this == typeof(byte))
            {
                return "byte";
            }
            if (@this == typeof(char))
            {
                return "char";
            }
            if (@this == typeof(decimal))
            {
                return "decimal";
            }
            if (@this == typeof(double))
            {
                return "double";
            }
            if (@this == typeof(Enum))
            {
                return "enum";
            }
            if (@this == typeof(float))
            {
                return "float";
            }
            if (@this == typeof(int))
            {
                return "int";
            }
            if (@this == typeof(long))
            {
                return "long";
            }
            if (@this == typeof(object))
            {
                return "object";
            }
            if (@this == typeof(sbyte))
            {
                return "sbyte";
            }
            if (@this == typeof(short))
            {
                return "short";
            }
            if (@this == typeof(string))
            {
                return "string";
            }
            if (@this == typeof(uint))
            {
                return "uint";
            }
            if (@this == typeof(ulong))
            {
                return "ulong";
            }
            if (@this == typeof(ushort))
            {
                return "ushort";
            }

            return @this.Name;
        }

        public static string GetSignature(this ConstructorInfo @this)
        {
            // Example:  [Name] [<GenericArguments] ([Parameters])
            var sb = new StringBuilder();

            // Name
            sb.Append(@this.ReflectedType.IsGenericType ? @this.ReflectedType.Name.Substring(0, @this.ReflectedType.Name.IndexOf('`')) : @this.ReflectedType.Name);

            // Parameters
            ParameterInfo[] parameters = @this.GetParameters();
            sb.Append("(");
            sb.Append(string.Join(", ", parameters.Select(x => x.GetSignature())));
            sb.Append(")");

            return sb.ToString();
        }


        public static string GetSignature(this EventInfo @this)
        {
            return null;
        }



        public static string GetSignature(this FieldInfo @this)
        {
            return @this.Name;
        }

        public static string GetSignature(this MemberInfo @this)
        {
            switch (@this.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)@this).GetSignature();
                case MemberTypes.Property:
                    return ((PropertyInfo)@this).GetSignature();
                case MemberTypes.Constructor:
                    return ((ConstructorInfo)@this).GetSignature();
                case MemberTypes.Method:
                    return ((MethodInfo)@this).GetSignature();
                case MemberTypes.TypeInfo:
                    return ((Type)@this).GetSignature();
                case MemberTypes.NestedType:
                    return ((Type)@this).GetSignature();
                case MemberTypes.Event:
                    return ((EventInfo)@this).GetSignature();
                default:
                    return null;
            }
        }


        public static string GetSignature(this MethodInfo @this)
        {
            // Example: [Visibility] [Modifier] [Type] [Name] [<GenericArguments] ([Parameters])
            var sb = new StringBuilder();

            // Name
            sb.Append(@this.Name);

            if (@this.IsGenericMethod)
            {
                sb.Append("<");

                Type[] arguments = @this.GetGenericArguments();

                sb.Append(string.Join(", ", arguments.Select(x => x.GetShortSignature())));

                sb.Append(">");
            }

            // Parameters
            ParameterInfo[] parameters = @this.GetParameters();
            sb.Append("(");
            sb.Append(string.Join(", ", parameters.Select(x => x.GetSignature())));
            sb.Append(")");

            return sb.ToString();
        }



        public static string GetSignature(this ParameterInfo @this)
        {
            var sb = new StringBuilder();

            @this.GetSignature(sb);
            return sb.ToString();
        }

        internal static void GetSignature(this ParameterInfo @this, StringBuilder sb)
        {
            // retval attribute

            string typeName;
            Type elementType = @this.ParameterType.GetElementType();

            if (elementType != null)
            {
                typeName = @this.ParameterType.Name.Replace(elementType.Name, elementType.GetShortSignature());
            }
            else
            {
                typeName = @this.ParameterType.GetShortSignature();
            }

            if (@this.IsOut)
            {
                if (typeName.Contains("&"))
                {
                    typeName = typeName.Replace("&", "");
                    sb.Append("out ");
                }
            }
            else if (@this.ParameterType.IsByRef)
            {
                typeName = typeName.Replace("&", "");
                sb.Append("ref ");
            }
            sb.Append(typeName);
        }



        public static string GetSignature(this PropertyInfo @this)
        {
            // Example: [Name | Indexer[Type]]

            var indexerParameter = @this.GetIndexParameters();
            if (indexerParameter.Length == 0)
            {
                // Name
                return @this.Name;
            }
            var sb = new StringBuilder();

            // Indexer
            sb.Append(@this.Name);
            sb.Append("[");
            sb.Append(string.Join(", ", indexerParameter.Select(x => x.ParameterType.GetShortSignature())));
            sb.Append("]");

            return sb.ToString();
        }


        public static string GetSignature(this Type @this)
        {
            // Example: [Visibility] [Modifier] [Type] [Name] [<GenericArguments>] [:] [Inherited Class] [Inherited Interface]
            var sb = new StringBuilder();

            // Variable
            bool hasInheritedClass = false;

            // Name
            sb.Append(@this.IsGenericType ? @this.Name.Substring(0, @this.Name.IndexOf('`')) : @this.Name);

            // GenericArguments
            if (@this.IsGenericType)
            {
                Type[] arguments = @this.GetGenericArguments();
                sb.Append("<");
                sb.Append(string.Join(", ", arguments.Select(x =>
                {
                    Type[] constraints = x.GetGenericParameterConstraints();

                    foreach (Type constraint in constraints)
                    {
                        GenericParameterAttributes gpa = constraint.GenericParameterAttributes;
                        GenericParameterAttributes variance = gpa & GenericParameterAttributes.VarianceMask;

                        if (variance != GenericParameterAttributes.None)
                        {
                            sb.Append((variance & GenericParameterAttributes.Covariant) != 0 ? "in " : "out ");
                        }
                    }

                    return x.GetShortDeclaraction();
                })));
                sb.Append(">");
            }

            return sb.ToString();
        }

    }
}
