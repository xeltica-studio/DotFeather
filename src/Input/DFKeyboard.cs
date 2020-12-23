using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Input;


namespace DotFeather
{
	/// <summary>
	/// Class that determines whether a key on the keyboard is pressed. This class can not be inherited.
	/// </summary>
	public static class DFKeyboard
	{
		public static DFKey Unknown { get; } = new DFKey();

		public static DFKey ShiftLeft { get; } = new DFKey();

		public static DFKey ShiftRight { get; } = new DFKey();

		public static DFKey ControlLeft { get; } = new DFKey();

		public static DFKey ControlRight { get; } = new DFKey();

		public static DFKey AltLeft { get; } = new DFKey();

		public static DFKey AltRight { get; } = new DFKey();

		public static DFKey WinLeft { get; } = new DFKey();

		public static DFKey WinRight { get; } = new DFKey();

		public static DFKey Menu { get; } = new DFKey();

		public static DFKey F1 { get; } = new DFKey();

		public static DFKey F2 { get; } = new DFKey();

		public static DFKey F3 { get; } = new DFKey();

		public static DFKey F4 { get; } = new DFKey();

		public static DFKey F5 { get; } = new DFKey();

		public static DFKey F6 { get; } = new DFKey();

		public static DFKey F7 { get; } = new DFKey();

		public static DFKey F8 { get; } = new DFKey();

		public static DFKey F9 { get; } = new DFKey();

		public static DFKey F10 { get; } = new DFKey();

		public static DFKey F11 { get; } = new DFKey();

		public static DFKey F12 { get; } = new DFKey();

		public static DFKey F13 { get; } = new DFKey();

		public static DFKey F14 { get; } = new DFKey();

		public static DFKey F15 { get; } = new DFKey();

		public static DFKey F16 { get; } = new DFKey();

		public static DFKey F17 { get; } = new DFKey();

		public static DFKey F18 { get; } = new DFKey();

		public static DFKey F19 { get; } = new DFKey();

		public static DFKey F20 { get; } = new DFKey();

		public static DFKey F21 { get; } = new DFKey();

		public static DFKey F22 { get; } = new DFKey();

		public static DFKey F23 { get; } = new DFKey();

		public static DFKey F24 { get; } = new DFKey();

		public static DFKey F25 { get; } = new DFKey();

		public static DFKey F26 { get; } = new DFKey();

		public static DFKey F27 { get; } = new DFKey();

		public static DFKey F28 { get; } = new DFKey();

		public static DFKey F29 { get; } = new DFKey();

		public static DFKey F30 { get; } = new DFKey();

		public static DFKey F31 { get; } = new DFKey();

		public static DFKey F32 { get; } = new DFKey();

		public static DFKey F33 { get; } = new DFKey();

		public static DFKey F34 { get; } = new DFKey();

		public static DFKey F35 { get; } = new DFKey();

		public static DFKey Up { get; } = new DFKey();

		public static DFKey Down { get; } = new DFKey();

		public static DFKey Left { get; } = new DFKey();

		public static DFKey Right { get; } = new DFKey();

		public static DFKey Enter { get; } = new DFKey();

		public static DFKey Escape { get; } = new DFKey();

		public static DFKey Space { get; } = new DFKey();

		public static DFKey Tab { get; } = new DFKey();

		public static DFKey BackSpace { get; } = new DFKey();

		public static DFKey Insert { get; } = new DFKey();

		public static DFKey Delete { get; } = new DFKey();

		public static DFKey PageUp { get; } = new DFKey();

		public static DFKey PageDown { get; } = new DFKey();

		public static DFKey Home { get; } = new DFKey();

		public static DFKey End { get; } = new DFKey();

		public static DFKey CapsLock { get; } = new DFKey();

		public static DFKey ScrollLock { get; } = new DFKey();

		public static DFKey PrintScreen { get; } = new DFKey();

		public static DFKey Pause { get; } = new DFKey();

		public static DFKey NumLock { get; } = new DFKey();

		public static DFKey Clear { get; } = new DFKey();

		public static DFKey Sleep { get; } = new DFKey();

		public static DFKey Keypad0 { get; } = new DFKey();

		public static DFKey Keypad1 { get; } = new DFKey();

		public static DFKey Keypad2 { get; } = new DFKey();

		public static DFKey Keypad3 { get; } = new DFKey();

		public static DFKey Keypad4 { get; } = new DFKey();

		public static DFKey Keypad5 { get; } = new DFKey();

		public static DFKey Keypad6 { get; } = new DFKey();

		public static DFKey Keypad7 { get; } = new DFKey();

		public static DFKey Keypad8 { get; } = new DFKey();

		public static DFKey Keypad9 { get; } = new DFKey();

		public static DFKey KeypadDivide { get; } = new DFKey();

		public static DFKey KeypadMultiply { get; } = new DFKey();

		public static DFKey KeypadMinus { get; } = new DFKey();

		public static DFKey KeypadPlus { get; } = new DFKey();

		public static DFKey KeypadPeriod { get; } = new DFKey();

		public static DFKey KeypadEnter { get; } = new DFKey();

		public static DFKey A { get; } = new DFKey();

		public static DFKey B { get; } = new DFKey();

		public static DFKey C { get; } = new DFKey();

		public static DFKey D { get; } = new DFKey();

		public static DFKey E { get; } = new DFKey();

		public static DFKey F { get; } = new DFKey();

		public static DFKey G { get; } = new DFKey();

		public static DFKey H { get; } = new DFKey();

		public static DFKey I { get; } = new DFKey();

		public static DFKey J { get; } = new DFKey();

		public static DFKey K { get; } = new DFKey();

		public static DFKey L { get; } = new DFKey();

		public static DFKey M { get; } = new DFKey();

		public static DFKey N { get; } = new DFKey();

		public static DFKey O { get; } = new DFKey();

		public static DFKey P { get; } = new DFKey();

		public static DFKey Q { get; } = new DFKey();

		public static DFKey R { get; } = new DFKey();

		public static DFKey S { get; } = new DFKey();

		public static DFKey T { get; } = new DFKey();

		public static DFKey U { get; } = new DFKey();

		public static DFKey V { get; } = new DFKey();

		public static DFKey W { get; } = new DFKey();

		public static DFKey X { get; } = new DFKey();

		public static DFKey Y { get; } = new DFKey();

		public static DFKey Z { get; } = new DFKey();

		public static DFKey Number0 { get; } = new DFKey();

		public static DFKey Number1 { get; } = new DFKey();

		public static DFKey Number2 { get; } = new DFKey();

		public static DFKey Number3 { get; } = new DFKey();

		public static DFKey Number4 { get; } = new DFKey();

		public static DFKey Number5 { get; } = new DFKey();

		public static DFKey Number6 { get; } = new DFKey();

		public static DFKey Number7 { get; } = new DFKey();

		public static DFKey Number8 { get; } = new DFKey();

		public static DFKey Number9 { get; } = new DFKey();

		public static DFKey Tilde { get; } = new DFKey();

		public static DFKey Minus { get; } = new DFKey();

		public static DFKey Plus { get; } = new DFKey();

		public static DFKey BracketLeft { get; } = new DFKey();

		public static DFKey BracketRight { get; } = new DFKey();

		public static DFKey Semicolon { get; } = new DFKey();

		public static DFKey Quote { get; } = new DFKey();

		public static DFKey Comma { get; } = new DFKey();

		public static DFKey Period { get; } = new DFKey();

		public static DFKey Slash { get; } = new DFKey();

		public static DFKey BackSlash { get; } = new DFKey();

		public static DFKey NonUSBackSlash { get; } = new DFKey();

		public static DFKey LastKey { get; } = new DFKey();

		/// <summary>
		/// Get all key codes;
		/// </summary>
		public static IEnumerable<DFKeyCode> AllKeyCodes => allCodes;

		/// <summary>
		/// Get all pressed keys.
		/// </summary>
		public static IEnumerable<DFKeyCode> AllPressedKeys => allCodes.Where(c => KeyOf(c).IsPressed);

		/// <summary>
		/// Get all keys which pressed then.
		/// </summary>
		public static IEnumerable<DFKeyCode> AllDownKeys => allCodes.Where(c => KeyOf(c).IsKeyDown);

		/// <summary>
		/// Get all keys which released then.
		/// </summary>
		public static IEnumerable<DFKeyCode> AllUpKeys => allCodes.Where(c => KeyOf(c).IsKeyUp);

		/// <summary>
		///Get a specific key by <see cref="DFKeyCode"/>.
		/// </summary>
		public static DFKey KeyOf(DFKeyCode code)
		{
			return code switch
			{
				DFKeyCode.Unknown => Unknown,
				DFKeyCode.ShiftLeft => ShiftLeft,
				DFKeyCode.ShiftRight => ShiftRight,
				DFKeyCode.ControlLeft => ControlLeft,
				DFKeyCode.ControlRight => ControlRight,
				DFKeyCode.AltLeft => AltLeft,
				DFKeyCode.AltRight => AltRight,
				DFKeyCode.WinLeft => WinLeft,
				DFKeyCode.WinRight => WinRight,
				DFKeyCode.Menu => Menu,
				DFKeyCode.F1 => F1,
				DFKeyCode.F2 => F2,
				DFKeyCode.F3 => F3,
				DFKeyCode.F4 => F4,
				DFKeyCode.F5 => F5,
				DFKeyCode.F6 => F6,
				DFKeyCode.F7 => F7,
				DFKeyCode.F8 => F8,
				DFKeyCode.F9 => F9,
				DFKeyCode.F10 => F10,
				DFKeyCode.F11 => F11,
				DFKeyCode.F12 => F12,
				DFKeyCode.F13 => F13,
				DFKeyCode.F14 => F14,
				DFKeyCode.F15 => F15,
				DFKeyCode.F16 => F16,
				DFKeyCode.F17 => F17,
				DFKeyCode.F18 => F18,
				DFKeyCode.F19 => F19,
				DFKeyCode.F20 => F20,
				DFKeyCode.F21 => F21,
				DFKeyCode.F22 => F22,
				DFKeyCode.F23 => F23,
				DFKeyCode.F24 => F24,
				DFKeyCode.F25 => F25,
				DFKeyCode.F26 => F26,
				DFKeyCode.F27 => F27,
				DFKeyCode.F28 => F28,
				DFKeyCode.F29 => F29,
				DFKeyCode.F30 => F30,
				DFKeyCode.F31 => F31,
				DFKeyCode.F32 => F32,
				DFKeyCode.F33 => F33,
				DFKeyCode.F34 => F34,
				DFKeyCode.F35 => F35,
				DFKeyCode.Up => Up,
				DFKeyCode.Down => Down,
				DFKeyCode.Left => Left,
				DFKeyCode.Right => Right,
				DFKeyCode.Enter => Enter,
				DFKeyCode.Escape => Escape,
				DFKeyCode.Space => Space,
				DFKeyCode.Tab => Tab,
				DFKeyCode.BackSpace => BackSpace,
				DFKeyCode.Insert => Insert,
				DFKeyCode.Delete => Delete,
				DFKeyCode.PageUp => PageUp,
				DFKeyCode.PageDown => PageDown,
				DFKeyCode.Home => Home,
				DFKeyCode.End => End,
				DFKeyCode.CapsLock => CapsLock,
				DFKeyCode.ScrollLock => ScrollLock,
				DFKeyCode.PrintScreen => PrintScreen,
				DFKeyCode.Pause => Pause,
				DFKeyCode.NumLock => NumLock,
				DFKeyCode.Clear => Clear,
				DFKeyCode.Sleep => Sleep,
				DFKeyCode.Keypad0 => Keypad0,
				DFKeyCode.Keypad1 => Keypad1,
				DFKeyCode.Keypad2 => Keypad2,
				DFKeyCode.Keypad3 => Keypad3,
				DFKeyCode.Keypad4 => Keypad4,
				DFKeyCode.Keypad5 => Keypad5,
				DFKeyCode.Keypad6 => Keypad6,
				DFKeyCode.Keypad7 => Keypad7,
				DFKeyCode.Keypad8 => Keypad8,
				DFKeyCode.Keypad9 => Keypad9,
				DFKeyCode.KeypadDivide => KeypadDivide,
				DFKeyCode.KeypadMultiply => KeypadMultiply,
				DFKeyCode.KeypadPlus => KeypadPlus,
				DFKeyCode.KeypadMinus => KeypadMinus,
				DFKeyCode.KeypadPeriod => KeypadPeriod,
				DFKeyCode.KeypadEnter => KeypadEnter,
				DFKeyCode.A => A,
				DFKeyCode.B => B,
				DFKeyCode.C => C,
				DFKeyCode.D => D,
				DFKeyCode.E => E,
				DFKeyCode.F => F,
				DFKeyCode.G => G,
				DFKeyCode.H => H,
				DFKeyCode.I => I,
				DFKeyCode.J => J,
				DFKeyCode.K => K,
				DFKeyCode.L => L,
				DFKeyCode.M => M,
				DFKeyCode.N => N,
				DFKeyCode.O => O,
				DFKeyCode.P => P,
				DFKeyCode.Q => Q,
				DFKeyCode.R => R,
				DFKeyCode.S => S,
				DFKeyCode.T => T,
				DFKeyCode.U => U,
				DFKeyCode.V => V,
				DFKeyCode.W => W,
				DFKeyCode.X => X,
				DFKeyCode.Y => Y,
				DFKeyCode.Z => Z,
				DFKeyCode.Number0 => Number0,
				DFKeyCode.Number1 => Number1,
				DFKeyCode.Number2 => Number2,
				DFKeyCode.Number3 => Number3,
				DFKeyCode.Number4 => Number4,
				DFKeyCode.Number5 => Number5,
				DFKeyCode.Number6 => Number6,
				DFKeyCode.Number7 => Number7,
				DFKeyCode.Number8 => Number8,
				DFKeyCode.Number9 => Number9,
				DFKeyCode.Tilde => Tilde,
				DFKeyCode.Minus => Minus,
				DFKeyCode.Plus => Plus,
				DFKeyCode.BracketLeft => BracketLeft,
				DFKeyCode.BracketRight => BracketRight,
				DFKeyCode.Semicolon => Semicolon,
				DFKeyCode.Quote => Quote,
				DFKeyCode.Comma => Comma,
				DFKeyCode.Period => Period,
				DFKeyCode.Slash => Slash,
				DFKeyCode.BackSlash => BackSlash,
				DFKeyCode.NonUSBackSlash => NonUSBackSlash,
				DFKeyCode.LastKey => LastKey,
				_ => throw new ArgumentOutOfRangeException(nameof(code)),
			};
		}

		/// <summary>
		/// Get input string from the keyboard buffer.
		/// </summary>
		public static string GetString()
		{
			if (!HasChar()) return "";

			var buf = new StringBuilder();
			while (HasChar())
				buf.Append(GetChar());
			return buf.ToString();
		}

		/// <summary>
		/// Get an input char from the keyboard buffer.
		/// </summary>
		public static char GetChar() => HasChar() ? keychars.Dequeue() : '\0';

		/// <summary>
		/// Check whether some chars in the keyboard buffer.
		/// </summary>
		/// <returns></returns>
		public static bool HasChar() => keychars.Count > 0;

		internal static void Update()
		{
			Parallel.ForEach(allCodes, code =>
			{
				var isPressed = Keyboard.GetState()[code.ToTK()];
				var prevIsPressed = prevState[(int)code];
				var key = KeyOf(code);
				key.IsPressed = isPressed;
				key.IsKeyDown = isPressed && !prevIsPressed;
				key.IsKeyUp = !isPressed && prevIsPressed;
				key.ElapsedFrameCount = isPressed ? key.ElapsedFrameCount + 1 : 0;
				key.ElapsedTime = isPressed ? key.ElapsedTime + Time.DeltaTime : 0;
				prevState[(int)code] = isPressed;
			});
		}

		internal static void OnKeyPress(DFKeyPressEventArgs e) => KeyPress?.Invoke(e);
		internal static void OnKeyDown(DFKeyEventArgs e) => KeyDown?.Invoke(e);
		internal static void OnKeyUp(DFKeyEventArgs e) => KeyUp?.Invoke(e);

		public static event Action<DFKeyEventArgs>? KeyDown;
		public static event Action<DFKeyPressEventArgs>? KeyPress;
		public static event Action<DFKeyEventArgs>? KeyUp;

		internal static readonly Queue<char> keychars = new();

		private static readonly DFKeyCode[] allCodes = (Enum.GetValues(typeof(DFKeyCode)) as DFKeyCode[]).Distinct().ToArray();
		private static readonly bool[] prevState = new bool[(int)DFKeyCode.LastKey + 1];
	}
}
