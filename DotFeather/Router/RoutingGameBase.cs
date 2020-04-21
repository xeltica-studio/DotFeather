using System;

namespace DotFeather
{
	public class RoutingGameBase<T> : GameBase where T : Scene
	{
		public RoutingGameBase(int width, int height, string title = "", int refreshRate = 60, bool isCaptureMode = false, bool followsDpi = false) : base(width, height, title, refreshRate, isCaptureMode, followsDpi)
		{
			router = new Router(this);
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			// 初期シーンをここで読み込む
			router.ChangeScene<T>();
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			Update?.Invoke(sender, e);
			// ルーターにアップデートさせる
			router.Update(e);
		}

		public event EventHandler<DFEventArgs>? Update;

		private readonly Router router;
	}
}
