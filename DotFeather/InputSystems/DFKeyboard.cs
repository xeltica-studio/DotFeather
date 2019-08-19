using System;
using System.Linq;
using OpenTK.Input;


namespace DotFeather
{
	/// <summary>
	/// キーボードのキーが押されているかどうか判別するクラスです。このクラスは継承できません。
	/// </summary>
	public sealed class DFKeyboard
	{
		/// <summary></summary>
		public DFKey Unknown { get; } = new DFKey();

		/// <summary></summary>
		public DFKey ShiftLeft { get; } = new DFKey();

		/// <summary></summary>
		public DFKey ShiftRight { get; } = new DFKey();

		/// <summary></summary>
		public DFKey ControlLeft { get; } = new DFKey();

		/// <summary></summary>
		public DFKey ControlRight { get; } = new DFKey();

		/// <summary></summary>
		public DFKey AltLeft { get; } = new DFKey();

		/// <summary></summary>
		public DFKey AltRight { get; } = new DFKey();

		/// <summary></summary>
		public DFKey WinLeft { get; } = new DFKey();

		/// <summary></summary>
		public DFKey WinRight { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Menu { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F1 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F2 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F3 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F4 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F5 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F6 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F7 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F8 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F9 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F10 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F11 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F12 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F13 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F14 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F15 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F16 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F17 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F18 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F19 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F20 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F21 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F22 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F23 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F24 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F25 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F26 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F27 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F28 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F29 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F30 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F31 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F32 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F33 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F34 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F35 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Up { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Down { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Left { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Right { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Enter { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Escape { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Space { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Tab { get; } = new DFKey();

		/// <summary></summary>
		public DFKey BackSpace { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Insert { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Delete { get; } = new DFKey();

		/// <summary></summary>
		public DFKey PageUp { get; } = new DFKey();

		/// <summary></summary>
		public DFKey PageDown { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Home { get; } = new DFKey();

		/// <summary></summary>
		public DFKey End { get; } = new DFKey();

		/// <summary></summary>
		public DFKey CapsLock { get; } = new DFKey();

		/// <summary></summary>
		public DFKey ScrollLock { get; } = new DFKey();

		/// <summary></summary>
		public DFKey PrintScreen { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Pause { get; } = new DFKey();

		/// <summary></summary>
		public DFKey NumLock { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Clear { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Sleep { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad0 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad1 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad2 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad3 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad4 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad5 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad6 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad7 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad8 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Keypad9 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadDivide { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadMultiply { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadMinus { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadPlus { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadPeriod { get; } = new DFKey();

		/// <summary></summary>
		public DFKey KeypadEnter { get; } = new DFKey();

		/// <summary></summary>
		public DFKey A { get; } = new DFKey();

		/// <summary></summary>
		public DFKey B { get; } = new DFKey();

		/// <summary></summary>
		public DFKey C { get; } = new DFKey();

		/// <summary></summary>
		public DFKey D { get; } = new DFKey();

		/// <summary></summary>
		public DFKey E { get; } = new DFKey();

		/// <summary></summary>
		public DFKey F { get; } = new DFKey();

		/// <summary></summary>
		public DFKey G { get; } = new DFKey();

		/// <summary></summary>
		public DFKey H { get; } = new DFKey();

		/// <summary></summary>
		public DFKey I { get; } = new DFKey();

		/// <summary></summary>
		public DFKey J { get; } = new DFKey();

		/// <summary></summary>
		public DFKey K { get; } = new DFKey();

		/// <summary></summary>
		public DFKey L { get; } = new DFKey();

		/// <summary></summary>
		public DFKey M { get; } = new DFKey();

		/// <summary></summary>
		public DFKey N { get; } = new DFKey();

		/// <summary></summary>
		public DFKey O { get; } = new DFKey();

		/// <summary></summary>
		public DFKey P { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Q { get; } = new DFKey();

		/// <summary></summary>
		public DFKey R { get; } = new DFKey();

		/// <summary></summary>
		public DFKey S { get; } = new DFKey();

		/// <summary></summary>
		public DFKey T { get; } = new DFKey();

		/// <summary></summary>
		public DFKey U { get; } = new DFKey();

		/// <summary></summary>
		public DFKey V { get; } = new DFKey();

		/// <summary></summary>
		public DFKey W { get; } = new DFKey();

		/// <summary></summary>
		public DFKey X { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Y { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Z { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number0 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number1 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number2 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number3 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number4 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number5 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number6 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number7 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number8 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Number9 { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Tilde { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Minus { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Plus { get; } = new DFKey();

		/// <summary></summary>
		public DFKey BracketLeft { get; } = new DFKey();

		/// <summary></summary>
		public DFKey BracketRight { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Semicolon { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Quote { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Comma { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Period { get; } = new DFKey();

		/// <summary></summary>
		public DFKey Slash { get; } = new DFKey();

		/// <summary></summary>
		public DFKey BackSlash { get; } = new DFKey();

		/// <summary></summary>
		public DFKey NonUSBackSlash { get; } = new DFKey();

		/// <summary></summary>
		public DFKey LastKey { get; } = new DFKey();

		/// <summary>
		/// <see cref="DFKeyCode"/> を指定して特定のキーを取得します。
		/// </summary>
		/// <value></value>
		public DFKey this[DFKeyCode code]
		{
			get
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
		}

		internal void Update()
		{
			foreach (var code in allCodes)
			{
				var isPressed = Keyboard.GetState()[code.ToTK()];
				var prevIsPressed = prevState[(int)code];
				this[code].IsPressed = isPressed;
				this[code].IsKeyDown = isPressed && !prevIsPressed;
				this[code].IsKeyUp = !isPressed && prevIsPressed;
				prevState[(int)code] = isPressed;
			}
		}

		private readonly DFKeyCode[] allCodes = (Enum.GetValues(typeof(DFKeyCode)) as DFKeyCode[]).Distinct().ToArray();
		private bool[] prevState = new bool[(int)DFKeyCode.LastKey + 1];
	}
}
