using System;

namespace DotFeather.Helpers
{
	public static class DFMath
	{
		/// <summary>
		/// 線形補間移動を計算します。
		/// </summary>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static float Lerp(float time, float start, float end) => start + (end - start) * time;

		/// <summary>
		/// 加減速移動を計算します。
		/// </summary>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static float EaseInOut(float time, float start, float end) =>
				(time /= 0.5f) < 1
				? (end - start) * 0.5f * time * time * time + start
				: (end - start) * 0.5f * ((time -= 2) * time * time + 2) + start;

		/// <summary>
		/// 加速移動を計算します。
		/// </summary>
		/// <returns>The in.</returns>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static float EaseIn(float time, float start, float end) => (end - start) * time * time * time + start;

		/// <summary>
		/// 減速移動を計算します。
		/// </summary>
		/// <returns>The out.</returns>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static float EaseOut(float time, float start, float end) => (end - start) * (--time * time * time + 1) + start;

		/// <summary>
		/// 線形補間移動を計算します。
		/// </summary>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static Vector Lerp(float time, Vector start, Vector end) => new Vector(Lerp(time, start.X, end.X), Lerp(time, start.Y, end.Y));

		/// <summary>
		/// 減速移動を計算します。
		/// </summary>
		/// <returns>The out.</returns>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static Vector EaseOut(float time, Vector start, Vector end) => new Vector(EaseOut(time, start.X, end.X), EaseOut(time, start.Y, end.Y));

		/// <summary>
		/// 加速移動を計算します。
		/// </summary>
		/// <returns>The out.</returns>
		/// <param name="time">Time.</param>
		/// <param name="start">Start.</param>
		/// <param name="end">End.</param>
		public static Vector EaseIn(float time, Vector start, Vector end) => new Vector(EaseIn(time, start.X, end.X), EaseIn(time, start.Y, end.Y));
		
		/// <summary>
		/// 角度を弧度に変換します。
		/// </summary>
		/// <returns>The radian.</returns>
		/// <param name="degree">Degree.</param>
		public static float ToRadian(float degree) => degree / 180f * (float)Math.PI;

		/// <summary>
		/// 弧度を角度に変換します。
		/// </summary>
		/// <returns>The degree.</returns>
		/// <param name="radian">Radian.</param>
		public static float ToDegree(float radian) => radian * 180f / (float)Math.PI;
	}
}
