using System;
using System.Collections.Generic;
using System.Linq;
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
			switch (code)
			{
				case DFKeyCode.Unknown:
					return Unknown;
				case DFKeyCode.ShiftLeft:
					return ShiftLeft;
				case DFKeyCode.ShiftRight:
					return ShiftRight;
				case DFKeyCode.ControlLeft:
					return ControlLeft;
				case DFKeyCode.ControlRight:
					return ControlRight;
				case DFKeyCode.AltLeft:
					return AltLeft;
				case DFKeyCode.AltRight:
					return AltRight;
				case DFKeyCode.WinLeft:
					return WinLeft;
				case DFKeyCode.WinRight:
					return WinRight;
				case DFKeyCode.Menu:
					return Menu;
				case DFKeyCode.F1:
					return F1;
				case DFKeyCode.F2:
					return F2;
				case DFKeyCode.F3:
					return F3;
				case DFKeyCode.F4:
					return F4;
				case DFKeyCode.F5:
					return F5;
				case DFKeyCode.F6:
					return F6;
				case DFKeyCode.F7:
					return F7;
				case DFKeyCode.F8:
					return F8;
				case DFKeyCode.F9:
					return F9;
				case DFKeyCode.F10:
					return F10;
				case DFKeyCode.F11:
					return F11;
				case DFKeyCode.F12:
					return F12;
				case DFKeyCode.F13:
					return F13;
				case DFKeyCode.F14:
					return F14;
				case DFKeyCode.F15:
					return F15;
				case DFKeyCode.F16:
					return F16;
				case DFKeyCode.F17:
					return F17;
				case DFKeyCode.F18:
					return F18;
				case DFKeyCode.F19:
					return F19;
				case DFKeyCode.F20:
					return F20;
				case DFKeyCode.F21:
					return F21;
				case DFKeyCode.F22:
					return F22;
				case DFKeyCode.F23:
					return F23;
				case DFKeyCode.F24:
					return F24;
				case DFKeyCode.F25:
					return F25;
				case DFKeyCode.F26:
					return F26;
				case DFKeyCode.F27:
					return F27;
				case DFKeyCode.F28:
					return F28;
				case DFKeyCode.F29:
					return F29;
				case DFKeyCode.F30:
					return F30;
				case DFKeyCode.F31:
					return F31;
				case DFKeyCode.F32:
					return F32;
				case DFKeyCode.F33:
					return F33;
				case DFKeyCode.F34:
					return F34;
				case DFKeyCode.F35:
					return F35;
				case DFKeyCode.Up:
					return Up;
				case DFKeyCode.Down:
					return Down;
				case DFKeyCode.Left:
					return Left;
				case DFKeyCode.Right:
					return Right;
				case DFKeyCode.Enter:
					return Enter;
				case DFKeyCode.Escape:
					return Escape;
				case DFKeyCode.Space:
					return Space;
				case DFKeyCode.Tab:
					return Tab;
				case DFKeyCode.BackSpace:
					return BackSpace;
				case DFKeyCode.Insert:
					return Insert;
				case DFKeyCode.Delete:
					return Delete;
				case DFKeyCode.PageUp:
					return PageUp;
				case DFKeyCode.PageDown:
					return PageDown;
				case DFKeyCode.Home:
					return Home;
				case DFKeyCode.End:
					return End;
				case DFKeyCode.CapsLock:
					return CapsLock;
				case DFKeyCode.ScrollLock:
					return ScrollLock;
				case DFKeyCode.PrintScreen:
					return PrintScreen;
				case DFKeyCode.Pause:
					return Pause;
				case DFKeyCode.NumLock:
					return NumLock;
				case DFKeyCode.Clear:
					return Clear;
				case DFKeyCode.Sleep:
					return Sleep;
				case DFKeyCode.Keypad0:
					return Keypad0;
				case DFKeyCode.Keypad1:
					return Keypad1;
				case DFKeyCode.Keypad2:
					return Keypad2;
				case DFKeyCode.Keypad3:
					return Keypad3;
				case DFKeyCode.Keypad4:
					return Keypad4;
				case DFKeyCode.Keypad5:
					return Keypad5;
				case DFKeyCode.Keypad6:
					return Keypad6;
				case DFKeyCode.Keypad7:
					return Keypad7;
				case DFKeyCode.Keypad8:
					return Keypad8;
				case DFKeyCode.Keypad9:
					return Keypad9;
				case DFKeyCode.KeypadDivide:
					return KeypadDivide;
				case DFKeyCode.KeypadMultiply:
					return KeypadMultiply;
				case DFKeyCode.KeypadPlus:
					return KeypadPlus;
				case DFKeyCode.KeypadMinus:
					return KeypadMinus;
				case DFKeyCode.KeypadPeriod:
					return KeypadPeriod;
				case DFKeyCode.KeypadEnter:
					return KeypadEnter;
				case DFKeyCode.A:
					return A;
				case DFKeyCode.B:
					return B;
				case DFKeyCode.C:
					return C;
				case DFKeyCode.D:
					return D;
				case DFKeyCode.E:
					return E;
				case DFKeyCode.F:
					return F;
				case DFKeyCode.G:
					return G;
				case DFKeyCode.H:
					return H;
				case DFKeyCode.I:
					return I;
				case DFKeyCode.J:
					return J;
				case DFKeyCode.K:
					return K;
				case DFKeyCode.L:
					return L;
				case DFKeyCode.M:
					return M;
				case DFKeyCode.N:
					return N;
				case DFKeyCode.O:
					return O;
				case DFKeyCode.P:
					return P;
				case DFKeyCode.Q:
					return Q;
				case DFKeyCode.R:
					return R;
				case DFKeyCode.S:
					return S;
				case DFKeyCode.T:
					return T;
				case DFKeyCode.U:
					return U;
				case DFKeyCode.V:
					return V;
				case DFKeyCode.W:
					return W;
				case DFKeyCode.X:
					return X;
				case DFKeyCode.Y:
					return Y;
				case DFKeyCode.Z:
					return Z;
				case DFKeyCode.Number0:
					return Number0;
				case DFKeyCode.Number1:
					return Number1;
				case DFKeyCode.Number2:
					return Number2;
				case DFKeyCode.Number3:
					return Number3;
				case DFKeyCode.Number4:
					return Number4;
				case DFKeyCode.Number5:
					return Number5;
				case DFKeyCode.Number6:
					return Number6;
				case DFKeyCode.Number7:
					return Number7;
				case DFKeyCode.Number8:
					return Number8;
				case DFKeyCode.Number9:
					return Number9;
				case DFKeyCode.Tilde:
					return Tilde;
				case DFKeyCode.Minus:
					return Minus;
				case DFKeyCode.Plus:
					return Plus;
				case DFKeyCode.BracketLeft:
					return BracketLeft;
				case DFKeyCode.BracketRight:
					return BracketRight;
				case DFKeyCode.Semicolon:
					return Semicolon;
				case DFKeyCode.Quote:
					return Quote;
				case DFKeyCode.Comma:
					return Comma;
				case DFKeyCode.Period:
					return Period;
				case DFKeyCode.Slash:
					return Slash;
				case DFKeyCode.BackSlash:
					return BackSlash;
				case DFKeyCode.NonUSBackSlash:
					return NonUSBackSlash;
				case DFKeyCode.LastKey:
					return LastKey;
				default:
					throw new ArgumentOutOfRangeException(nameof(code));
			}
		}

		internal static void Update()
		{
			foreach (var code in allCodes)
			{
				var isPressed = Keyboard.GetState()[code.ToTK()];
				var prevIsPressed = prevState[(int)code];
				KeyOf(code).IsPressed = isPressed;
				KeyOf(code).IsKeyDown = isPressed && !prevIsPressed;
				KeyOf(code).IsKeyUp = !isPressed && prevIsPressed;
				prevState[(int)code] = isPressed;
			}
		}

		private static readonly DFKeyCode[] allCodes = (Enum.GetValues(typeof(DFKeyCode)) as DFKeyCode[]).Distinct().ToArray();
		private static bool[] prevState = new bool[(int)DFKeyCode.LastKey + 1];
	}
}
