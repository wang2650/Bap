using CommonLib.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CommonLib.Helpers;
using CommonLib.Expressions;

namespace CommonLib.Extensions
{
    public static partial class Extensions
    {
        #region Property(属性表达式)

        /// <summary>
        /// 创建属性表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="propertyName">属性名，支持多级属性名，与句点分隔，范例：Customer.Name</param>
        /// <returns></returns>
        public static Expression Property(this Expression expression, string propertyName)
        {
            if (propertyName.All(t => t != '.'))
            {
                return Expression.Property(expression, propertyName);
            }
            var propertyNameList = propertyName.Split('.');
            Expression result = null;
            for (int i = 0; i < propertyName.Length; i++)
            {
                if (i == 0)
                {
                    result = Expression.Property(expression, propertyNameList[0]);
                    continue;
                }
                result = result.Property(propertyNameList[i]);
            }
            return result;
        }

        /// <summary>
        /// 创建属性表达式
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="member">属性</param>
        /// <returns></returns>
        public static Expression Property(this Expression expression, MemberInfo member)
        {
            return Expression.MakeMemberAccess(expression, member);
        }

        #endregion

        #region And(与表达式)

        /// <summary>
        /// 与操作表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression And(this Expression left, Expression right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            return Expression.AndAlso(left, right);
        }

        /// <summary>
        /// 与操作表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            return left.Compose(right, Expression.AndAlso);
        }

        #endregion

        #region Or(或表达式)

        /// <summary>
        /// 或操作表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression Or(this Expression left, Expression right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            return Expression.OrElse(left, right);
        }

        /// <summary>
        /// 或操作表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            if (left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            return left.Compose(right, Expression.OrElse);
        }

        #endregion

        #region Value(获取Lambda表达式的值)

        /// <summary>
        /// 获取Lambda表达式的值
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="expression">表达式</param>
        /// <returns></returns>
        public static object Value<T>(this Expression<Func<T, bool>> expression)
        {
            return Lambda.GetValue(expression);
        }

        #endregion

        #region Equal(等于表达式)

        /// <summary>
        /// 创建等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression Equal(this Expression left, Expression right)
        {
            return Expression.Equal(left, right);
        }

        /// <summary>
        /// 创建等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Equal(this Expression left, object value)
        {
            return left.Equal(Lambda.Constant(value, left));
        }

        #endregion

        #region NotEqual(不等于表达式)

        /// <summary>
        /// 创建不等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression NotEqual(this Expression left, Expression right)
        {
            return Expression.NotEqual(left, right);
        }

        /// <summary>
        /// 创建不等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression NotEqual(this Expression left, object value)
        {
            return left.NotEqual(Lambda.Constant(value, left));
        }

        #endregion

        #region Greater(大于表达式)

        /// <summary>
        /// 创建大于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression Greater(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }

        /// <summary>
        /// 创建大于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Greater(this Expression left, object value)
        {
            return left.Greater(Lambda.Constant(value, left));
        }

        #endregion

        #region GreaterEqual(大于等于表达式)

        /// <summary>
        /// 创建大于等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression GreaterEqual(this Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right);
        }

        /// <summary>
        /// 创建大于等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression GreaterEqual(this Expression left, object value)
        {
            return left.GreaterEqual(Lambda.Constant(value, left));
        }

        #endregion

        #region Less(小于表达式)

        /// <summary>
        /// 创建小于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression Less(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right);
        }

        /// <summary>
        /// 创建小于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Less(this Expression left, object value)
        {
            return left.Less(Lambda.Constant(value, left));
        }

        #endregion

        #region LessEqual(小于等于表达式)

        /// <summary>
        /// 创建小于等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <returns></returns>
        public static Expression LessEqual(this Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right);
        }

        /// <summary>
        /// 创建小于等于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression LessEqual(this Expression left, object value)
        {
            return left.LessEqual(Lambda.Constant(value, left));
        }

        #endregion

        #region StartsWith(头匹配)

        /// <summary>
        /// 创建大于运算表达式
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression StartsWith(this Expression left, object value)
        {
            return left.Call("StartsWith", new[] { typeof(string) }, value);
        }

        #endregion

        #region EndsWith(尾匹配)

        /// <summary>
        /// 尾匹配
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression EndsWith(this Expression left, object value)
        {
            return left.Call("EndsWith", new[] { typeof(string) }, value);
        }

        #endregion

        #region Contains(模糊匹配)

        /// <summary>
        /// 模糊匹配
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Contains(this Expression left, object value)
        {
            return left.Call("Contains", new[] { typeof(string) }, value);
        }

        #endregion

        #region Operation(操作)

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Operation(this Expression left, Operator @operator, object value)
        {
            switch (@operator)
            {
                case Operator.Equal:
                    return left.Equal(value);
                case Operator.NotEqual:
                    return left.NotEqual(value);
                case Operator.Greater:
                    return left.Greater(value);
                case Operator.GreaterEqual:
                    return left.GreaterEqual(value);
                case Operator.Less:
                    return left.Less(value);
                case Operator.LessEqual:
                    return left.LessEqual(value);
                case Operator.Starts:
                    return left.StartsWith(value);
                case Operator.Ends:
                    return left.EndsWith(value);
                case Operator.Contains:
                    return left.Contains(value);
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="operator">运算符</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public static Expression Operation(this Expression left, Operator @operator, Expression value)
        {
            switch (@operator)
            {
                case Operator.Equal:
                    return left.Equal(value);
                case Operator.NotEqual:
                    return left.NotEqual(value);
                case Operator.Greater:
                    return left.Greater(value);
                case Operator.GreaterEqual:
                    return left.GreaterEqual(value);
                case Operator.Less:
                    return left.Less(value);
                case Operator.LessEqual:
                    return left.LessEqual(value);
            }
            throw new NotImplementedException();
        }

        #endregion

        #region Call(调用方法表达式)

        /// <summary>
        /// 创建调用方法表达式
        /// </summary>
        /// <param name="instance">调用的实例</param>
        /// <param name="methodName">方法名</param>
        /// <param name="values">参数值列表</param>
        /// <returns></returns>
        public static Expression Call(this Expression instance, string methodName, params Expression[] values)
        {
            return Expression.Call(instance, instance.Type.GetTypeInfo().GetMethod(methodName), values);
        }

        /// <summary>
        /// 创建调用方法表达式
        /// </summary>
        /// <param name="instance">调用的实例</param>
        /// <param name="methodName">方法名</param>
        /// <param name="values">参数值列表</param>
        /// <returns></returns>
        public static Expression Call(this Expression instance, string methodName, params object[] values)
        {
            if (values == null || values.Length == 0)
            {
                return Expression.Call(instance, instance.Type.GetTypeInfo().GetMethod(methodName));
            }
            return Expression.Call(instance, instance.Type.GetTypeInfo().GetMethod(methodName),
                values.Select(Expression.Constant));
        }

        /// <summary>
        /// 创建调用方法表达式
        /// </summary>
        /// <param name="instance">调用的实例</param>
        /// <param name="methodName">方法名</param>
        /// <param name="paramTypes">参数类型列表</param>
        /// <param name="values">参数值列表</param>
        /// <returns></returns>
        public static Expression Call(this Expression instance, string methodName, Type[] paramTypes,
            params object[] values)
        {
            if (values == null || values.Length == 0)
            {
                return Expression.Call(instance, instance.Type.GetTypeInfo().GetMethod(methodName, paramTypes));
            }
            return Expression.Call(instance, instance.Type.GetTypeInfo().GetMethod(methodName, paramTypes),
                values.Select(Expression.Constant));
        }

        #endregion

        #region Compose(组合表达式)

        /// <summary>
        /// 组合表达式
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="first">左操作数</param>
        /// <param name="second">右操作数</param>
        /// <param name="merge">合并操作</param>
        /// <returns></returns>
        internal static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second,
            Func<Expression, Expression, Expression> merge)
        {
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] })
                .ToDictionary(p => p.s, p => p.f);
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        #endregion

        #region ToLambda(创建Lambda表达式)

        /// <summary>
        /// 创建Lambda表达式
        /// </summary>
        /// <typeparam name="TDelegate">委托类型</typeparam>
        /// <param name="body">表达式</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body,
            params ParameterExpression[] parameters)
        {
            if (body == null)
            {
                return null;
            }
            return Expression.Lambda<TDelegate>(body, parameters);
        }

        #endregion

        #region ToPredicate(创建谓词表达式)

        /// <summary>
        /// 创建谓词表达式
        /// </summary>
        /// <typeparam name="T">委托类型</typeparam>
        /// <param name="body">表达式</param>
        /// <param name="parameters">参数列表</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> ToPredicate<T>(this Expression body,
            params ParameterExpression[] parameters)
        {
            return ToLambda<Func<T, bool>>(body, parameters);
        }

        #endregion
        #region Required(断言)
        /// <summary>
        /// 验证指定值的断言表达式是否为真，不为值抛出<see cref="Exception"/>异常
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="assertionFunc">要验证的断言</param>
        /// <param name="message">异常消息</param>
        public static void Required<T>(this T value, Func<T, bool> assertionFunc, string message)
        {
            CheckHelper.Required<T>(value, assertionFunc, message);
        }

        /// <summary>
        /// 验证指定值的断言表达式是否为真，不为真抛出<see cref="Exception"/>异常
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="assertionFunc">要验证的断言</param>
        /// <param name="message">异常消息</param>
        public static void Required<T, TException>(this T value, Func<T, bool> assertionFunc, string message)
            where TException : Exception
        {
            CheckHelper.Required<T, TException>(value, assertionFunc, message);
        }

        #endregion


        #region CheckNotNull(不可空检查)

        /// <summary>
        /// 检查参数不能为空引用，否则抛出<see cref="ArgumentNullException"/>异常
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="paramName">参数名</param>
        public static void CheckNotNull<T>(this T value, string paramName) where T : class
        {
            CheckHelper.NotNull<T>(value, paramName);
        }

        /// <summary>
        /// 检查字符串不能为空引用或空字符串，否则抛出<see cref="ArgumentNullException"/>异常或<see cref="ArgumentException"/>异常
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <param name="paramName">参数名</param>
        public static void CheckNotNullOrEmpty(this string value, string paramName)
        {
            CheckHelper.NotNullOrEmpty(value, paramName);
        }

        /// <summary>
        /// 检查Guid值不能为Guid.Empty，否则抛出<see cref="ArgumentException"/>异常
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <param name="paramName">参数名</param>
        public static void CheckNotEmpty(this Guid value, string paramName)
        {
            CheckHelper.NotEmpty(value, paramName);
        }

        /// <summary>
        /// 检查集合不能为空引用或空集合，否则抛出<see cref="ArgumentNullException"/>异常或<see cref="ArgumentException"/>异常。
        /// </summary>
        /// <typeparam name="T">集合项的类型</typeparam>
        /// <param name="collection">要判断的值</param>
        /// <param name="paramName">参数名</param>
        public static void CheckNotNullOrEmpty<T>(this IEnumerable<T> collection, string paramName)
        {
            CheckHelper.NotNullOrEmpty<T>(collection, paramName);
        }

        #endregion






        #region IsNullableType(是否可空类型)

        /// <summary>
        /// 是否可空类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type)
        {
            return ((type != null) && type.IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// 是否可空类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="genericParameterType">通用参数类型</param>
        /// <returns></returns>
        public static bool IsNullableType(this Type type, Type genericParameterType)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return genericParameterType == Nullable.GetUnderlyingType(type);
        }

        #endregion

        #region IsNullableEnum(是否可空枚举类型)

        /// <summary>
        /// 是否可空枚举类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool IsNullableEnum(this Type type)
        {
            return Nullable.GetUnderlyingType(type)?.GetTypeInfo().IsEnum ?? false;
        }

        #endregion

        #region HasAttribute(是否有指定特性)

        /// <summary>
        /// 是否有指定特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">类型</param>
        /// <param name="inherit">是否允许继承链搜索</param>
        /// <returns></returns>
        public static bool HasAttribute<T>(this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetTypeInfo().IsDefined(typeof(T), inherit);
        }

        #endregion

        #region GetAttributes(获取指定特性集合)

        /// <summary>
        /// 获取指定特性集合
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">类型</param>
        /// <param name="inherit">是否允许继承链搜索</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributes<T>(this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<T>(inherit);
        }

        #endregion

        #region GetAttribute(获取指定特性)

        /// <summary>
        /// 获取指定特性
        /// </summary>
        /// <typeparam name="T">特性类型</typeparam>
        /// <param name="type">类型</param>
        /// <param name="inherit">是否允许继承链搜索</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type, bool inherit = false) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<T>(inherit).FirstOrDefault();
        }

        #endregion

        #region IsCustomType(是否自定义类型)

        /// <summary>
        /// 是否自定义类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool IsCustomType(this Type type)
        {
            if (type.IsPrimitive)
            {
                return false;
            }

            if (type.IsArray && type.HasElementType && type.GetElementType().IsPrimitive)
            {
                return false;
            }

            return type != typeof(object) && type != typeof(Guid) &&
                   Type.GetTypeCode(type) == TypeCode.Object && !type.IsGenericType;
        }

        #endregion

        #region IsAnonymousType(是否匿名类型)

        /// <summary>
        /// 是否匿名类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool IsAnonymousType(this Type type)
        {
            const string csharpAnonPrefix = "<>f__AnonymousType";
            const string vbAnonPrefix = "VB$Anonymous";
            var typeName = type.Name;
            return typeName.StartsWith(csharpAnonPrefix) || typeName.StartsWith(vbAnonPrefix);
        }

        #endregion

        #region IsBaseType(是否基类型)

        /// <summary>
        /// 是否基类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="checkingType">检查类型</param>
        /// <returns></returns>
        public static bool IsBaseType(this Type type, Type checkingType)
        {
            while (type != typeof(object))
            {
                if (type == null)
                {
                    continue;
                }

                if (type == checkingType)
                {
                    return true;
                }

                type = type.BaseType;
            }

            return false;
        }

        #endregion

        #region CanUseForDb(能否用于数据库存储)

        /// <summary>
        /// 能否用于数据库存储
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public static bool CanUseForDb(this Type type)
        {
            return type == typeof(string)
                   || type == typeof(int)
                   || type == typeof(long)
                   || type == typeof(uint)
                   || type == typeof(ulong)
                   || type == typeof(float)
                   || type == typeof(double)
                   || type == typeof(Guid)
                   || type == typeof(byte[])
                   || type == typeof(decimal)
                   || type == typeof(char)
                   || type == typeof(bool)
                   || type == typeof(DateTime)
                   || type == typeof(TimeSpan)
                   || type == typeof(DateTimeOffset)
                   || type.GetTypeInfo().IsEnum
                   || Nullable.GetUnderlyingType(type) != null && CanUseForDb(Nullable.GetUnderlyingType(type));
        }

        #endregion

        #region CheckIO(文件检查)

        /// <summary>
        /// 检查指定路径的文件夹必须存在，否则抛出<see cref="DirectoryNotFoundException"/>异常
        /// </summary>
        /// <param name="directory">目录路径</param>
        /// <param name="paramName">参数名</param>
        public static void CheckDirectoryExists(this string directory, string paramName = null)
        {
            Check.DirectoryExists(directory, paramName);
        }

        /// <summary>
        /// 检查指定路径的文件必须存在，否则抛出<see cref="FileNotFoundException"/>异常。
        /// </summary>
        /// <param name="fileName">文件路径，包含文件名</param>
        /// <param name="paramName">参数名</param>
        public static void CheckFileExists(this string fileName, string paramName = null)
        {
            Check.FileExists(fileName, paramName);
        }

        #endregion

    }
}
