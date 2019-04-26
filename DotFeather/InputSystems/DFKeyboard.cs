using OpenTK.Input;


namespace DotFeather
{
	/// <summary>
	/// キーボードのキーが押されているかどうか判別するクラスです。このクラスは継承できません。
	/// </summary>
	public sealed class DFKeyboard
	{
		/// <summary></summary>
		public DFKey Unknown { get; } = new DFKey(Key.Unknown);

		/// <summary></summary>
		public DFKey ShiftLeft { get; } = new DFKey(Key.ShiftLeft);

		/// <summary></summary>
		public DFKey LShift { get; } = new DFKey(Key.LShift);

		/// <summary></summary>
		public DFKey ShiftRight { get; } = new DFKey(Key.ShiftRight);

		/// <summary></summary>
		public DFKey RShift { get; } = new DFKey(Key.RShift);

		/// <summary></summary>
		public DFKey ControlLeft { get; } = new DFKey(Key.ControlLeft);

		/// <summary></summary>
		public DFKey LControl { get; } = new DFKey(Key.LControl);

		/// <summary></summary>
		public DFKey ControlRight { get; } = new DFKey(Key.ControlRight);

		/// <summary></summary>
		public DFKey RControl { get; } = new DFKey(Key.RControl);

		/// <summary></summary>
		public DFKey AltLeft { get; } = new DFKey(Key.AltLeft);

		/// <summary></summary>
		public DFKey LAlt { get; } = new DFKey(Key.LAlt);

		/// <summary></summary>
		public DFKey AltRight { get; } = new DFKey(Key.AltRight);

		/// <summary></summary>
		public DFKey RAlt { get; } = new DFKey(Key.RAlt);

		/// <summary></summary>
		public DFKey WinLeft { get; } = new DFKey(Key.WinLeft);

		/// <summary></summary>
		public DFKey LWin { get; } = new DFKey(Key.LWin);

		/// <summary></summary>
		public DFKey WinRight { get; } = new DFKey(Key.WinRight);

		/// <summary></summary>
		public DFKey RWin { get; } = new DFKey(Key.RWin);

		/// <summary></summary>
		public DFKey Menu { get; } = new DFKey(Key.Menu);

		/// <summary></summary>
		public DFKey F1 { get; } = new DFKey(Key.F1);

		/// <summary></summary>
		public DFKey F2 { get; } = new DFKey(Key.F2);

		/// <summary></summary>
		public DFKey F3 { get; } = new DFKey(Key.F3);

		/// <summary></summary>
		public DFKey F4 { get; } = new DFKey(Key.F4);

		/// <summary></summary>
		public DFKey F5 { get; } = new DFKey(Key.F5);

		/// <summary></summary>
		public DFKey F6 { get; } = new DFKey(Key.F6);

		/// <summary></summary>
		public DFKey F7 { get; } = new DFKey(Key.F7);

		/// <summary></summary>
		public DFKey F8 { get; } = new DFKey(Key.F8);

		/// <summary></summary>
		public DFKey F9 { get; } = new DFKey(Key.F9);

		/// <summary></summary>
		public DFKey F10 { get; } = new DFKey(Key.F10);

		/// <summary></summary>
		public DFKey F11 { get; } = new DFKey(Key.F11);

		/// <summary></summary>
		public DFKey F12 { get; } = new DFKey(Key.F12);

		/// <summary></summary>
		public DFKey F13 { get; } = new DFKey(Key.F13);

		/// <summary></summary>
		public DFKey F14 { get; } = new DFKey(Key.F14);

		/// <summary></summary>
		public DFKey F15 { get; } = new DFKey(Key.F15);

		/// <summary></summary>
		public DFKey F16 { get; } = new DFKey(Key.F16);

		/// <summary></summary>
		public DFKey F17 { get; } = new DFKey(Key.F17);

		/// <summary></summary>
		public DFKey F18 { get; } = new DFKey(Key.F18);

		/// <summary></summary>
		public DFKey F19 { get; } = new DFKey(Key.F19);

		/// <summary></summary>
		public DFKey F20 { get; } = new DFKey(Key.F20);

		/// <summary></summary>
		public DFKey F21 { get; } = new DFKey(Key.F21);

		/// <summary></summary>
		public DFKey F22 { get; } = new DFKey(Key.F22);

		/// <summary></summary>
		public DFKey F23 { get; } = new DFKey(Key.F23);

		/// <summary></summary>
		public DFKey F24 { get; } = new DFKey(Key.F24);

		/// <summary></summary>
		public DFKey F25 { get; } = new DFKey(Key.F25);

		/// <summary></summary>
		public DFKey F26 { get; } = new DFKey(Key.F26);

		/// <summary></summary>
		public DFKey F27 { get; } = new DFKey(Key.F27);

		/// <summary></summary>
		public DFKey F28 { get; } = new DFKey(Key.F28);

		/// <summary></summary>
		public DFKey F29 { get; } = new DFKey(Key.F29);

		/// <summary></summary>
		public DFKey F30 { get; } = new DFKey(Key.F30);

		/// <summary></summary>
		public DFKey F31 { get; } = new DFKey(Key.F31);

		/// <summary></summary>
		public DFKey F32 { get; } = new DFKey(Key.F32);

		/// <summary></summary>
		public DFKey F33 { get; } = new DFKey(Key.F33);

		/// <summary></summary>
		public DFKey F34 { get; } = new DFKey(Key.F34);

		/// <summary></summary>
		public DFKey F35 { get; } = new DFKey(Key.F35);

		/// <summary></summary>
		public DFKey Up { get; } = new DFKey(Key.Up);

		/// <summary></summary>
		public DFKey Down { get; } = new DFKey(Key.Down);

		/// <summary></summary>
		public DFKey Left { get; } = new DFKey(Key.Left);

		/// <summary></summary>
		public DFKey Right { get; } = new DFKey(Key.Right);

		/// <summary></summary>
		public DFKey Enter { get; } = new DFKey(Key.Enter);

		/// <summary></summary>
		public DFKey Escape { get; } = new DFKey(Key.Escape);

		/// <summary></summary>
		public DFKey Space { get; } = new DFKey(Key.Space);

		/// <summary></summary>
		public DFKey Tab { get; } = new DFKey(Key.Tab);

		/// <summary></summary>
		public DFKey BackSpace { get; } = new DFKey(Key.BackSpace);

		/// <summary></summary>
		public DFKey Back { get; } = new DFKey(Key.Back);

		/// <summary></summary>
		public DFKey Insert { get; } = new DFKey(Key.Insert);

		/// <summary></summary>
		public DFKey Delete { get; } = new DFKey(Key.Delete);

		/// <summary></summary>
		public DFKey PageUp { get; } = new DFKey(Key.PageUp);

		/// <summary></summary>
		public DFKey PageDown { get; } = new DFKey(Key.PageDown);

		/// <summary></summary>
		public DFKey Home { get; } = new DFKey(Key.Home);

		/// <summary></summary>
		public DFKey End { get; } = new DFKey(Key.End);

		/// <summary></summary>
		public DFKey CapsLock { get; } = new DFKey(Key.CapsLock);

		/// <summary></summary>
		public DFKey ScrollLock { get; } = new DFKey(Key.ScrollLock);

		/// <summary></summary>
		public DFKey PrintScreen { get; } = new DFKey(Key.PrintScreen);

		/// <summary></summary>
		public DFKey Pause { get; } = new DFKey(Key.Pause);

		/// <summary></summary>
		public DFKey NumLock { get; } = new DFKey(Key.NumLock);

		/// <summary></summary>
		public DFKey Clear { get; } = new DFKey(Key.Clear);

		/// <summary></summary>
		public DFKey Sleep { get; } = new DFKey(Key.Sleep);

		/// <summary></summary>
		public DFKey Keypad0 { get; } = new DFKey(Key.Keypad0);

		/// <summary></summary>
		public DFKey Keypad1 { get; } = new DFKey(Key.Keypad1);

		/// <summary></summary>
		public DFKey Keypad2 { get; } = new DFKey(Key.Keypad2);

		/// <summary></summary>
		public DFKey Keypad3 { get; } = new DFKey(Key.Keypad3);

		/// <summary></summary>
		public DFKey Keypad4 { get; } = new DFKey(Key.Keypad4);

		/// <summary></summary>
		public DFKey Keypad5 { get; } = new DFKey(Key.Keypad5);

		/// <summary></summary>
		public DFKey Keypad6 { get; } = new DFKey(Key.Keypad6);

		/// <summary></summary>
		public DFKey Keypad7 { get; } = new DFKey(Key.Keypad7);

		/// <summary></summary>
		public DFKey Keypad8 { get; } = new DFKey(Key.Keypad8);

		/// <summary></summary>
		public DFKey Keypad9 { get; } = new DFKey(Key.Keypad9);

		/// <summary></summary>
		public DFKey KeypadDivide { get; } = new DFKey(Key.KeypadDivide);

		/// <summary></summary>
		public DFKey KeypadMultiply { get; } = new DFKey(Key.KeypadMultiply);

		/// <summary></summary>
		public DFKey KeypadSubtract { get; } = new DFKey(Key.KeypadSubtract);

		/// <summary></summary>
		public DFKey KeypadMinus { get; } = new DFKey(Key.KeypadMinus);

		/// <summary></summary>
		public DFKey KeypadAdd { get; } = new DFKey(Key.KeypadAdd);

		/// <summary></summary>
		public DFKey KeypadPlus { get; } = new DFKey(Key.KeypadPlus);

		/// <summary></summary>
		public DFKey KeypadDecimal { get; } = new DFKey(Key.KeypadDecimal);

		/// <summary></summary>
		public DFKey KeypadPeriod { get; } = new DFKey(Key.KeypadPeriod);

		/// <summary></summary>
		public DFKey KeypadEnter { get; } = new DFKey(Key.KeypadEnter);

		/// <summary></summary>
		public DFKey A { get; } = new DFKey(Key.A);

		/// <summary></summary>
		public DFKey B { get; } = new DFKey(Key.B);

		/// <summary></summary>
		public DFKey C { get; } = new DFKey(Key.C);

		/// <summary></summary>
		public DFKey D { get; } = new DFKey(Key.D);

		/// <summary></summary>
		public DFKey E { get; } = new DFKey(Key.E);

		/// <summary></summary>
		public DFKey F { get; } = new DFKey(Key.F);

		/// <summary></summary>
		public DFKey G { get; } = new DFKey(Key.G);

		/// <summary></summary>
		public DFKey H { get; } = new DFKey(Key.H);

		/// <summary></summary>
		public DFKey I { get; } = new DFKey(Key.I);

		/// <summary></summary>
		public DFKey J { get; } = new DFKey(Key.J);

		/// <summary></summary>
		public DFKey K { get; } = new DFKey(Key.K);

		/// <summary></summary>
		public DFKey L { get; } = new DFKey(Key.L);

		/// <summary></summary>
		public DFKey M { get; } = new DFKey(Key.M);

		/// <summary></summary>
		public DFKey N { get; } = new DFKey(Key.N);

		/// <summary></summary>
		public DFKey O { get; } = new DFKey(Key.O);

		/// <summary></summary>
		public DFKey P { get; } = new DFKey(Key.P);

		/// <summary></summary>
		public DFKey Q { get; } = new DFKey(Key.Q);

		/// <summary></summary>
		public DFKey R { get; } = new DFKey(Key.R);

		/// <summary></summary>
		public DFKey S { get; } = new DFKey(Key.S);

		/// <summary></summary>
		public DFKey T { get; } = new DFKey(Key.T);

		/// <summary></summary>
		public DFKey U { get; } = new DFKey(Key.U);

		/// <summary></summary>
		public DFKey V { get; } = new DFKey(Key.V);

		/// <summary></summary>
		public DFKey W { get; } = new DFKey(Key.W);

		/// <summary></summary>
		public DFKey X { get; } = new DFKey(Key.X);

		/// <summary></summary>
		public DFKey Y { get; } = new DFKey(Key.Y);

		/// <summary></summary>
		public DFKey Z { get; } = new DFKey(Key.Z);

		/// <summary></summary>
		public DFKey Number0 { get; } = new DFKey(Key.Number0);

		/// <summary></summary>
		public DFKey Number1 { get; } = new DFKey(Key.Number1);

		/// <summary></summary>
		public DFKey Number2 { get; } = new DFKey(Key.Number2);

		/// <summary></summary>
		public DFKey Number3 { get; } = new DFKey(Key.Number3);

		/// <summary></summary>
		public DFKey Number4 { get; } = new DFKey(Key.Number4);

		/// <summary></summary>
		public DFKey Number5 { get; } = new DFKey(Key.Number5);

		/// <summary></summary>
		public DFKey Number6 { get; } = new DFKey(Key.Number6);

		/// <summary></summary>
		public DFKey Number7 { get; } = new DFKey(Key.Number7);

		/// <summary></summary>
		public DFKey Number8 { get; } = new DFKey(Key.Number8);

		/// <summary></summary>
		public DFKey Number9 { get; } = new DFKey(Key.Number9);

		/// <summary></summary>
		public DFKey Tilde { get; } = new DFKey(Key.Tilde);

		/// <summary></summary>
		public DFKey Grave { get; } = new DFKey(Key.Grave);

		/// <summary></summary>
		public DFKey Minus { get; } = new DFKey(Key.Minus);

		/// <summary></summary>
		public DFKey Plus { get; } = new DFKey(Key.Plus);

		/// <summary></summary>
		public DFKey BracketLeft { get; } = new DFKey(Key.BracketLeft);

		/// <summary></summary>
		public DFKey LBracket { get; } = new DFKey(Key.LBracket);

		/// <summary></summary>
		public DFKey BracketRight { get; } = new DFKey(Key.BracketRight);

		/// <summary></summary>
		public DFKey RBracket { get; } = new DFKey(Key.RBracket);

		/// <summary></summary>
		public DFKey Semicolon { get; } = new DFKey(Key.Semicolon);

		/// <summary></summary>
		public DFKey Quote { get; } = new DFKey(Key.Quote);

		/// <summary></summary>
		public DFKey Comma { get; } = new DFKey(Key.Comma);

		/// <summary></summary>
		public DFKey Period { get; } = new DFKey(Key.Period);

		/// <summary></summary>
		public DFKey Slash { get; } = new DFKey(Key.Slash);

		/// <summary></summary>
		public DFKey BackSlash { get; } = new DFKey(Key.BackSlash);

		/// <summary></summary>
		public DFKey NonUSBackSlash { get; } = new DFKey(Key.NonUSBackSlash);

		/// <summary></summary>
		public DFKey LastKey { get; } = new DFKey(Key.LastKey);

	}

}
