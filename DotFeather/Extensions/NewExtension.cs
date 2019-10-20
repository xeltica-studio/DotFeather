using System;

namespace DotFeather.Router
{
    /// <summary>
    /// <see cref="New{T}"/> クラスの為の拡張メソッドを提供します。
    /// from https://codeday.me/jp/qa/20190123/149543.html
    /// </summary>
    internal static class NewExtension
    {
        /// <summary>
        /// 指定した型がデフォルトコンストラクターを持っているかどうかを判断します。
        /// </summary>
        /// <param name="t">判断する対象の型。</param>
        /// <returns>デフォルトコンストラクターを持っている場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
        public static bool HasDefaultConstructor(this Type t)
        {
            return t.IsValueType || t.GetConstructor(Type.EmptyTypes) != null;
        }
    }

}
