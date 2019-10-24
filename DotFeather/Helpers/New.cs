using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace DotFeather
{
    /// <summary>
    /// リフレクションを用いつつも高速に、動的にインスタンスを生成します。
    /// Code from https://codeday.me/jp/qa/20190123/149543.html
    /// </summary>
    internal static class New<T>
    {
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <returns></returns>
        internal static readonly Func<T> Instance = Creator();

        static Func<T> Creator()
        {
            Type t = typeof(T);
            if (t == typeof(string))
                return Expression.Lambda<Func<T>>(Expression.Constant(string.Empty)).Compile();

            if (t.HasDefaultConstructor())
                return Expression.Lambda<Func<T>>(Expression.New(t)).Compile();

            return () => (T)FormatterServices.GetUninitializedObject(t);
        }
    }
}
