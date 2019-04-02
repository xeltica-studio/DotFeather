# DotFeather [![GitHub issues](https://img.shields.io/github/issues/badges/shields.svg?style=flat-square)][issues] [![GitHub pull requests](https://img.shields.io/github/issues-pr/cdnjs/cdnjs.svg?style=flat-square)][pulls] [![GitHub Releases](https://img.shields.io/github/release/xeltica/DotFeather.svg?style=flat-square)][releases] [![License](https://img.shields.io/github/license/xeltica/dotfeather.svg?style=flat-square)](LICENSE)


[issues]: /xeltica/dotfeather/issues
[pulls]: /xeltica/dotfeather/pulls
[releases]: /xeltica/dotfeather/releases

DotFeather is a lightweight generic 2D gameengine for C#/.NET Standard 2.0.

[日本語](README-ja.md) ・ English

## To Build

```
git clone https://github.com/xeltica/DotFeather.git
cd DotFeather
nuget restore
dotnet build
```

## Example

### Draw Shapes

```cs
// in class Game : GameBase
var g = new Graphic();
this.Children.Add(g);

g.Line(0, 0, 400, 400, Color.Red);
g.Line(0, 400, 0, 400, Color.Blue);
g.Circle(0, 0, 400, 400, Color.Green);
```

### Draw a sprite

```cs
// in class Game : GameBase
Texture2D[] textures = LoadDividedImage("./player.png", 4, 1, new System.Drawing.Size(16, 16);
var sprite = new Sprite(textures[0], 0, 0, 0, new Vector(16, 16));
this.Children.Add(sprite);
```

[Full Sample code](DotFeather.Test.NetCore)

## Contributing

coming soon

## Donate

You want to donate for me? Thank you very much! Please see [this page](//xeltica.work/en/donation.html) how to pay me.

## LICENSE

[MIT](LICENSE)
