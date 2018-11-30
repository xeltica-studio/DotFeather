using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using SDBitmap = System.Drawing.Bitmap;
using SDRect = System.Drawing.Rectangle;
using SDPixelFormat = System.Drawing.Imaging.PixelFormat;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	/// <summary>
	/// DotFeather のメインループおよび、各種メソッドを揃えている、ゲームエントリーポイントの基底クラスです。
	/// </summary>
	public abstract class GameBase : IDisposable
	{
		/// <summary>
		/// このウィンドウの幅を取得または設定します。
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get => window.Size.Width;
			set => window.Size = new Size(value, window.Size.Height);
		}

		/// <summary>
		/// このウィンドウの高さを取得または設定します。
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get => window.Size.Height;
			set => window.Size = new Size(window.Size.Width, value);
		}

		/// <summary>
		/// このウィンドウのリフレッシュレートを取得または設定します。
		/// </summary>
		/// <value>The refresh rate.</value>
		public int RefreshRate { get; }

		/// <summary>
		/// このウィンドウのタイトルを取得または設定します。
		/// </summary>
		/// <value>ウィンドウタイトル。</value>
		public string Title
		{
			get => window?.Title;
			set => window.Title = value;
		}

		/// <summary>
		/// このゲームの現在のレイヤー一覧を取得します。
		/// </summary>
		public List<ILayer> Layers { get; } = new List<ILayer>();


		/// <summary>
		/// 画像ファイルを読み込みます。
		/// </summary>
		/// <returns>読み込んだ画像のデータ。</returns>
		/// <param name="path">ファイルパス。</param>
		public Texture2D LoadImage(string path)
		{
			using (var file = new SDBitmap(path))
			{
				return RegisterTexture(file.LockBits(new SDRect(0, 0, file.Width, file.Height), ImageLockMode.ReadOnly, SDPixelFormat.Format32bppArgb));
			}
		}

		/// <summary>
		/// 画像ファイルを読み込み、指定したサイズで左上から順番に切り取ります。
		/// </summary>
		/// <returns>切り取られた全ての画像データ。</returns>
		/// <param name="path">画像のファイルパス。</param>
		/// <param name="horizonalCount">横方向の画像の枚数。</param>
		/// <param name="verticalCount">盾向の画像の枚数。</param>
		/// <param name="sizeOfCroppedImage">画像1枚分のサイズ。</param>
		public Texture2D[] LoadDividedImage(string path, int horizonalCount, int verticalCount, Size sizeOfCroppedImage)
		{
			using (var file = new SDBitmap(path))
			{
				var datas = new List<Texture2D>();

				for (int y = 0; y < verticalCount; y++)
				{
					for (int x = 0; x < horizonalCount; x++)
					{
						(var px, var py) = (x * sizeOfCroppedImage.Width, y * sizeOfCroppedImage.Height);
						if (px + sizeOfCroppedImage.Width >= file.Width)
						{
							throw new ArgumentException(nameof(horizonalCount));
						}
						if (py + sizeOfCroppedImage.Height >= file.Height)
						{
							throw new ArgumentException(nameof(horizonalCount));
						}

						datas.Add(RegisterTexture(file.LockBits(new SDRect(px, py, sizeOfCroppedImage.Width, sizeOfCroppedImage.Height), ImageLockMode.ReadOnly, SDPixelFormat.Format32bppArgb)));
					}
				}
				return datas.ToArray();
			}
		}

		/// <summary>
		/// 乱数を指定したシード値で初期化します。
		/// </summary>
		/// <param name="seed">シード値。<c>null</c> であれば、 <see cref="System.Random"/> の標準のコンストラクターを呼びます。</param>
		public void Randomize(int? seed = null)
		{
			Random = seed is int s ? new Random(s) : new Random();
		}

		/// <summary>
		/// ゲームを実行します。
		/// </summary>
		/// <returns>返り値。</returns>
		public int Run()
		{
			window.Run(RefreshRate);
			return statusCode ?? 0;
		}

		/// <summary>
		/// ゲームを終了します。
		/// </summary>
		/// <param name="status">返り値。</param>
		public void Exit(int status = 0)
		{
			statusCode = status;
			window.Close();
		}

		/// <summary>
		/// Releases all resource used by the <see cref="T:DotFeather.GameBase"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:DotFeather.GameBase"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:DotFeather.GameBase"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="T:DotFeather.GameBase"/> so the garbage
		/// collector can reclaim the memory that the <see cref="T:DotFeather.GameBase"/> was occupying.</remarks>
		public void Dispose()
		{
			window.Dispose();
		}

		/// <summary>
		/// 指定したパラメーターで、 GameBase インスタンスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="width">幅.</param>
		/// <param name="height">高さ.</param>
		/// <param name="title">タイトル.</param>
		/// <param name="refreshRate">リフレッシュレート.</param>
		protected GameBase(int width, int height, string title = null, int refreshRate = 60)
		{
			RefreshRate = refreshRate;

			window = new GameWindow(width, height, GraphicsMode.Default, title ?? "DotFeather Window", GameWindowFlags.FixedWindow);
			window.UpdateFrame += (object sender, FrameEventArgs e) => OnUpdate(sender, new DFEventArgs
			{
				DeltaTime = e.Time,
			});

			window.RenderFrame += (object sender, FrameEventArgs e) =>
			{
				GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
				Layers.ForEach(l => l.Draw(this));
				window.SwapBuffers();
			};

			window.Load += (object sender, EventArgs e) =>
			{
				GL.ClearColor(Color.Black);
				GL.LineWidth(1);
				window.VSync = VSyncMode.On;

				GL.Enable(EnableCap.DepthTest);
				window.WindowBorder = WindowBorder.Resizable;

				OnLoad(sender, e);
			};

			window.Resize += (object sender, EventArgs e) =>
			{
				GL.Viewport(window.ClientRectangle);
				OnResize(sender, e);
			};

			window.Unload += (object sender, EventArgs e) =>
			{
				// テクスチャを全て解放する
				textures?.ForEach(t => GL.DeleteTexture(t.Handle));
				OnUnload(sender, e);
			};
		}

		/// <summary>
		/// ゲームのフレーム更新時に呼び出されます。このメソッドをオーバーライドして、ゲームのメインループを記述してください。
		/// </summary>
		protected virtual void OnUpdate(object sender, DFEventArgs e) { }

		/// <summary>
		/// ウィンドウが開かれたときに一度だけ呼び出されます。
		/// </summary>
		protected virtual void OnLoad(object sender, EventArgs e) { }
		/// <summary>
		/// ウィンドウが閉じられるときに一度だけ呼び出されます。
		/// </summary>
		protected virtual void OnUnload(object sender, EventArgs e) { }
		/// <summary>
		/// ウィンドウがリサイズされたときに呼び出されます。
		/// </summary>
		protected virtual void OnResize(object sender, EventArgs e) { }

		/// <summary>
		/// テクスチャを登録し、ハンドルを返します。
		/// </summary>
		protected Texture2D RegisterTexture(BitmapData bmp)
		{
			var texture = GL.GenTexture();
			GL.BindTexture(TextureTarget.Texture2D, texture);

			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
			GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

			GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmp.Scan0);
			return new Texture2D(texture, new System.Drawing.Size(bmp.Width, bmp.Height));
		}

		private int? statusCode;
		private readonly GameWindow window;
		protected Random Random { get; private set; } = new Random();
		protected readonly List<Texture2D> textures = new List<Texture2D>();
	}
}
