# IUpdatable

**Note: この項目は DotFeather およびプログラミング上級者を対象としています。**

`IDrawable` インターフェイスはレンダラーがオブジェクトを描画する為のイベントを提供しますが、ゲームロジックを処理する為のイベントは提供していません。 `Draw()` メソッド内に描画以外の処理を記述することは想定されるユースケースではなく、危険です。カスタム Drawable が、例えばユーザーの入力を受け取って何か処理をするといった場合、これでは都合が悪いです。 `IUpdatable` インターフェイスはそれを解決します。

`IUpdatable` インターフェイスの詳しい定義は、[API ドキュメント](https://dotfeather.netlify.com/api/dotfeather.iupdatable) をご参照ください。

`IUpdatable.OnUpdate(GameBase game);` イベントは、フレームアップデート毎に発火します。次に、スプライトがクリックされたときにゲームの背景色を赤色にするサンプルを示します。

```cs
public class ClickableSprite : Sprite, IUpdatable
{
	public ClickableSprite(Texture2D texture) : base(texture) { }

	public void OnUpdate(GameBase game)
	{
		var (x, y) = (Input.Mouse.Position.X, Input.Mouse.Position.Y);
		var (lx, ly) = Location;

		if (lx < x && ly < y && x < lx + Width && y < ly + Height && Input.Mouse.IsLeftUp)
		{
			game.BackgroundColor = Color.Red;
		}
	}
}
```
