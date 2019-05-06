using OpenTK.Input;


namespace DotFeather
{
	/// <summary>
	/// キーボードのキーが押されているかどうか判別するクラスです。このクラスは継承できません。
	/// </summary>
	public sealed class DFKeyboard
	{
		/// <summary></summary>
		public DFKey Unknown { get; } = new DFKey(DFKeyCode.Unknown);

		/// <summary></summary>
		public DFKey ShiftLeft { get; } = new DFKey(DFKeyCode.ShiftLeft);

		/// <summary></summary>
		public DFKey LShift { get; } = new DFKey(DFKeyCode.LShift);

		/// <summary></summary>
		public DFKey ShiftRight { get; } = new DFKey(DFKeyCode.ShiftRight);

		/// <summary></summary>
		public DFKey RShift { get; } = new DFKey(DFKeyCode.RShift);

		/// <summary></summary>
		public DFKey ControlLeft { get; } = new DFKey(DFKeyCode.ControlLeft);

		/// <summary></summary>
		public DFKey LControl { get; } = new DFKey(DFKeyCode.LControl);

		/// <summary></summary>
		public DFKey ControlRight { get; } = new DFKey(DFKeyCode.ControlRight);

		/// <summary></summary>
		public DFKey RControl { get; } = new DFKey(DFKeyCode.RControl);

		/// <summary></summary>
		public DFKey AltLeft { get; } = new DFKey(DFKeyCode.AltLeft);

		/// <summary></summary>
		public DFKey LAlt { get; } = new DFKey(DFKeyCode.LAlt);

		/// <summary></summary>
		public DFKey AltRight { get; } = new DFKey(DFKeyCode.AltRight);

		/// <summary></summary>
		public DFKey RAlt { get; } = new DFKey(DFKeyCode.RAlt);

		/// <summary></summary>
		public DFKey WinLeft { get; } = new DFKey(DFKeyCode.WinLeft);

		/// <summary></summary>
		public DFKey LWin { get; } = new DFKey(DFKeyCode.LWin);

		/// <summary></summary>
		public DFKey WinRight { get; } = new DFKey(DFKeyCode.WinRight);

		/// <summary></summary>
		public DFKey RWin { get; } = new DFKey(DFKeyCode.RWin);

		/// <summary></summary>
		public DFKey Menu { get; } = new DFKey(DFKeyCode.Menu);

		/// <summary></summary>
		public DFKey F1 { get; } = new DFKey(DFKeyCode.F1);

		/// <summary></summary>
		public DFKey F2 { get; } = new DFKey(DFKeyCode.F2);

		/// <summary></summary>
		public DFKey F3 { get; } = new DFKey(DFKeyCode.F3);

		/// <summary></summary>
		public DFKey F4 { get; } = new DFKey(DFKeyCode.F4);

		/// <summary></summary>
		public DFKey F5 { get; } = new DFKey(DFKeyCode.F5);

		/// <summary></summary>
		public DFKey F6 { get; } = new DFKey(DFKeyCode.F6);

		/// <summary></summary>
		public DFKey F7 { get; } = new DFKey(DFKeyCode.F7);

		/// <summary></summary>
		public DFKey F8 { get; } = new DFKey(DFKeyCode.F8);

		/// <summary></summary>
		public DFKey F9 { get; } = new DFKey(DFKeyCode.F9);

		/// <summary></summary>
		public DFKey F10 { get; } = new DFKey(DFKeyCode.F10);

		/// <summary></summary>
		public DFKey F11 { get; } = new DFKey(DFKeyCode.F11);

		/// <summary></summary>
		public DFKey F12 { get; } = new DFKey(DFKeyCode.F12);

		/// <summary></summary>
		public DFKey F13 { get; } = new DFKey(DFKeyCode.F13);

		/// <summary></summary>
		public DFKey F14 { get; } = new DFKey(DFKeyCode.F14);

		/// <summary></summary>
		public DFKey F15 { get; } = new DFKey(DFKeyCode.F15);

		/// <summary></summary>
		public DFKey F16 { get; } = new DFKey(DFKeyCode.F16);

		/// <summary></summary>
		public DFKey F17 { get; } = new DFKey(DFKeyCode.F17);

		/// <summary></summary>
		public DFKey F18 { get; } = new DFKey(DFKeyCode.F18);

		/// <summary></summary>
		public DFKey F19 { get; } = new DFKey(DFKeyCode.F19);

		/// <summary></summary>
		public DFKey F20 { get; } = new DFKey(DFKeyCode.F20);

		/// <summary></summary>
		public DFKey F21 { get; } = new DFKey(DFKeyCode.F21);

		/// <summary></summary>
		public DFKey F22 { get; } = new DFKey(DFKeyCode.F22);

		/// <summary></summary>
		public DFKey F23 { get; } = new DFKey(DFKeyCode.F23);

		/// <summary></summary>
		public DFKey F24 { get; } = new DFKey(DFKeyCode.F24);

		/// <summary></summary>
		public DFKey F25 { get; } = new DFKey(DFKeyCode.F25);

		/// <summary></summary>
		public DFKey F26 { get; } = new DFKey(DFKeyCode.F26);

		/// <summary></summary>
		public DFKey F27 { get; } = new DFKey(DFKeyCode.F27);

		/// <summary></summary>
		public DFKey F28 { get; } = new DFKey(DFKeyCode.F28);

		/// <summary></summary>
		public DFKey F29 { get; } = new DFKey(DFKeyCode.F29);

		/// <summary></summary>
		public DFKey F30 { get; } = new DFKey(DFKeyCode.F30);

		/// <summary></summary>
		public DFKey F31 { get; } = new DFKey(DFKeyCode.F31);

		/// <summary></summary>
		public DFKey F32 { get; } = new DFKey(DFKeyCode.F32);

		/// <summary></summary>
		public DFKey F33 { get; } = new DFKey(DFKeyCode.F33);

		/// <summary></summary>
		public DFKey F34 { get; } = new DFKey(DFKeyCode.F34);

		/// <summary></summary>
		public DFKey F35 { get; } = new DFKey(DFKeyCode.F35);

		/// <summary></summary>
		public DFKey Up { get; } = new DFKey(DFKeyCode.Up);

		/// <summary></summary>
		public DFKey Down { get; } = new DFKey(DFKeyCode.Down);

		/// <summary></summary>
		public DFKey Left { get; } = new DFKey(DFKeyCode.Left);

		/// <summary></summary>
		public DFKey Right { get; } = new DFKey(DFKeyCode.Right);

		/// <summary></summary>
		public DFKey Enter { get; } = new DFKey(DFKeyCode.Enter);

		/// <summary></summary>
		public DFKey Escape { get; } = new DFKey(DFKeyCode.Escape);

		/// <summary></summary>
		public DFKey Space { get; } = new DFKey(DFKeyCode.Space);

		/// <summary></summary>
		public DFKey Tab { get; } = new DFKey(DFKeyCode.Tab);

		/// <summary></summary>
		public DFKey BackSpace { get; } = new DFKey(DFKeyCode.BackSpace);

		/// <summary></summary>
		public DFKey Back { get; } = new DFKey(DFKeyCode.Back);

		/// <summary></summary>
		public DFKey Insert { get; } = new DFKey(DFKeyCode.Insert);

		/// <summary></summary>
		public DFKey Delete { get; } = new DFKey(DFKeyCode.Delete);

		/// <summary></summary>
		public DFKey PageUp { get; } = new DFKey(DFKeyCode.PageUp);

		/// <summary></summary>
		public DFKey PageDown { get; } = new DFKey(DFKeyCode.PageDown);

		/// <summary></summary>
		public DFKey Home { get; } = new DFKey(DFKeyCode.Home);

		/// <summary></summary>
		public DFKey End { get; } = new DFKey(DFKeyCode.End);

		/// <summary></summary>
		public DFKey CapsLock { get; } = new DFKey(DFKeyCode.CapsLock);

		/// <summary></summary>
		public DFKey ScrollLock { get; } = new DFKey(DFKeyCode.ScrollLock);

		/// <summary></summary>
		public DFKey PrintScreen { get; } = new DFKey(DFKeyCode.PrintScreen);

		/// <summary></summary>
		public DFKey Pause { get; } = new DFKey(DFKeyCode.Pause);

		/// <summary></summary>
		public DFKey NumLock { get; } = new DFKey(DFKeyCode.NumLock);

		/// <summary></summary>
		public DFKey Clear { get; } = new DFKey(DFKeyCode.Clear);

		/// <summary></summary>
		public DFKey Sleep { get; } = new DFKey(DFKeyCode.Sleep);

		/// <summary></summary>
		public DFKey Keypad0 { get; } = new DFKey(DFKeyCode.Keypad0);

		/// <summary></summary>
		public DFKey Keypad1 { get; } = new DFKey(DFKeyCode.Keypad1);

		/// <summary></summary>
		public DFKey Keypad2 { get; } = new DFKey(DFKeyCode.Keypad2);

		/// <summary></summary>
		public DFKey Keypad3 { get; } = new DFKey(DFKeyCode.Keypad3);

		/// <summary></summary>
		public DFKey Keypad4 { get; } = new DFKey(DFKeyCode.Keypad4);

		/// <summary></summary>
		public DFKey Keypad5 { get; } = new DFKey(DFKeyCode.Keypad5);

		/// <summary></summary>
		public DFKey Keypad6 { get; } = new DFKey(DFKeyCode.Keypad6);

		/// <summary></summary>
		public DFKey Keypad7 { get; } = new DFKey(DFKeyCode.Keypad7);

		/// <summary></summary>
		public DFKey Keypad8 { get; } = new DFKey(DFKeyCode.Keypad8);

		/// <summary></summary>
		public DFKey Keypad9 { get; } = new DFKey(DFKeyCode.Keypad9);

		/// <summary></summary>
		public DFKey KeypadDivide { get; } = new DFKey(DFKeyCode.KeypadDivide);

		/// <summary></summary>
		public DFKey KeypadMultiply { get; } = new DFKey(DFKeyCode.KeypadMultiply);

		/// <summary></summary>
		public DFKey KeypadSubtract { get; } = new DFKey(DFKeyCode.KeypadSubtract);

		/// <summary></summary>
		public DFKey KeypadMinus { get; } = new DFKey(DFKeyCode.KeypadMinus);

		/// <summary></summary>
		public DFKey KeypadAdd { get; } = new DFKey(DFKeyCode.KeypadAdd);

		/// <summary></summary>
		public DFKey KeypadPlus { get; } = new DFKey(DFKeyCode.KeypadPlus);

		/// <summary></summary>
		public DFKey KeypadDecimal { get; } = new DFKey(DFKeyCode.KeypadDecimal);

		/// <summary></summary>
		public DFKey KeypadPeriod { get; } = new DFKey(DFKeyCode.KeypadPeriod);

		/// <summary></summary>
		public DFKey KeypadEnter { get; } = new DFKey(DFKeyCode.KeypadEnter);

		/// <summary></summary>
		public DFKey A { get; } = new DFKey(DFKeyCode.A);

		/// <summary></summary>
		public DFKey B { get; } = new DFKey(DFKeyCode.B);

		/// <summary></summary>
		public DFKey C { get; } = new DFKey(DFKeyCode.C);

		/// <summary></summary>
		public DFKey D { get; } = new DFKey(DFKeyCode.D);

		/// <summary></summary>
		public DFKey E { get; } = new DFKey(DFKeyCode.E);

		/// <summary></summary>
		public DFKey F { get; } = new DFKey(DFKeyCode.F);

		/// <summary></summary>
		public DFKey G { get; } = new DFKey(DFKeyCode.G);

		/// <summary></summary>
		public DFKey H { get; } = new DFKey(DFKeyCode.H);

		/// <summary></summary>
		public DFKey I { get; } = new DFKey(DFKeyCode.I);

		/// <summary></summary>
		public DFKey J { get; } = new DFKey(DFKeyCode.J);

		/// <summary></summary>
		public DFKey K { get; } = new DFKey(DFKeyCode.K);

		/// <summary></summary>
		public DFKey L { get; } = new DFKey(DFKeyCode.L);

		/// <summary></summary>
		public DFKey M { get; } = new DFKey(DFKeyCode.M);

		/// <summary></summary>
		public DFKey N { get; } = new DFKey(DFKeyCode.N);

		/// <summary></summary>
		public DFKey O { get; } = new DFKey(DFKeyCode.O);

		/// <summary></summary>
		public DFKey P { get; } = new DFKey(DFKeyCode.P);

		/// <summary></summary>
		public DFKey Q { get; } = new DFKey(DFKeyCode.Q);

		/// <summary></summary>
		public DFKey R { get; } = new DFKey(DFKeyCode.R);

		/// <summary></summary>
		public DFKey S { get; } = new DFKey(DFKeyCode.S);

		/// <summary></summary>
		public DFKey T { get; } = new DFKey(DFKeyCode.T);

		/// <summary></summary>
		public DFKey U { get; } = new DFKey(DFKeyCode.U);

		/// <summary></summary>
		public DFKey V { get; } = new DFKey(DFKeyCode.V);

		/// <summary></summary>
		public DFKey W { get; } = new DFKey(DFKeyCode.W);

		/// <summary></summary>
		public DFKey X { get; } = new DFKey(DFKeyCode.X);

		/// <summary></summary>
		public DFKey Y { get; } = new DFKey(DFKeyCode.Y);

		/// <summary></summary>
		public DFKey Z { get; } = new DFKey(DFKeyCode.Z);

		/// <summary></summary>
		public DFKey Number0 { get; } = new DFKey(DFKeyCode.Number0);

		/// <summary></summary>
		public DFKey Number1 { get; } = new DFKey(DFKeyCode.Number1);

		/// <summary></summary>
		public DFKey Number2 { get; } = new DFKey(DFKeyCode.Number2);

		/// <summary></summary>
		public DFKey Number3 { get; } = new DFKey(DFKeyCode.Number3);

		/// <summary></summary>
		public DFKey Number4 { get; } = new DFKey(DFKeyCode.Number4);

		/// <summary></summary>
		public DFKey Number5 { get; } = new DFKey(DFKeyCode.Number5);

		/// <summary></summary>
		public DFKey Number6 { get; } = new DFKey(DFKeyCode.Number6);

		/// <summary></summary>
		public DFKey Number7 { get; } = new DFKey(DFKeyCode.Number7);

		/// <summary></summary>
		public DFKey Number8 { get; } = new DFKey(DFKeyCode.Number8);

		/// <summary></summary>
		public DFKey Number9 { get; } = new DFKey(DFKeyCode.Number9);

		/// <summary></summary>
		public DFKey Tilde { get; } = new DFKey(DFKeyCode.Tilde);

		/// <summary></summary>
		public DFKey Grave { get; } = new DFKey(DFKeyCode.Grave);

		/// <summary></summary>
		public DFKey Minus { get; } = new DFKey(DFKeyCode.Minus);

		/// <summary></summary>
		public DFKey Plus { get; } = new DFKey(DFKeyCode.Plus);

		/// <summary></summary>
		public DFKey BracketLeft { get; } = new DFKey(DFKeyCode.BracketLeft);

		/// <summary></summary>
		public DFKey LBracket { get; } = new DFKey(DFKeyCode.LBracket);

		/// <summary></summary>
		public DFKey BracketRight { get; } = new DFKey(DFKeyCode.BracketRight);

		/// <summary></summary>
		public DFKey RBracket { get; } = new DFKey(DFKeyCode.RBracket);

		/// <summary></summary>
		public DFKey Semicolon { get; } = new DFKey(DFKeyCode.Semicolon);

		/// <summary></summary>
		public DFKey Quote { get; } = new DFKey(DFKeyCode.Quote);

		/// <summary></summary>
		public DFKey Comma { get; } = new DFKey(DFKeyCode.Comma);

		/// <summary></summary>
		public DFKey Period { get; } = new DFKey(DFKeyCode.Period);

		/// <summary></summary>
		public DFKey Slash { get; } = new DFKey(DFKeyCode.Slash);

		/// <summary></summary>
		public DFKey BackSlash { get; } = new DFKey(DFKeyCode.BackSlash);

		/// <summary></summary>
		public DFKey NonUSBackSlash { get; } = new DFKey(DFKeyCode.NonUSBackSlash);

		/// <summary></summary>
		public DFKey LastKey { get; } = new DFKey(DFKeyCode.LastKey);

	}

}
