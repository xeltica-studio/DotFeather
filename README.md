# <img src="docs/logo.svg"/> 
[![Build status](https://img.shields.io/appveyor/ci/xeltica/dotfeather.svg?style=for-the-badge)][ci]
[![GitHub issues](https://img.shields.io/github/issues/xeltica/dotfeather.svg?style=for-the-badge)][issues]
[![GitHub pull requests](https://img.shields.io/github/issues-pr/xeltica/dotfeather.svg?style=for-the-badge)][pulls]
[![GitHub Releases](https://img.shields.io/github/release-pre/xeltica/DotFeather.svg?style=for-the-badge)][releases]
[![License](https://img.shields.io/github/license/xeltica/dotfeather.svg?style=for-the-badge)](LICENSE)
[![Nuget](https://img.shields.io/nuget/vpre/DotFeather.svg?style=for-the-badge)](https://www.nuget.org/packages/DotFeather/)

[ci]: https://ci.appveyor.com/project/Xeltica/dotfeather
[issues]: //github.com/xeltica/dotfeather/issues
[pulls]: //github.com/xeltica/dotfeather/pulls
[releases]: //github.com/xeltica/dotfeather/releases

DotFeather is a lightweight cross-platform generic 2D game engine for C#/.NET Standard 2.0.

[日本語](README-ja.md) ・ English

## Supported Platform

- Windows
- macOS
- Linux

## Supported Graphics Driver

- OpenGL 1.0 (Using OpenTK)

### In Planning

- OpenGL ES 2.0 (Using OpenTK)
- DirectX 9.0 (Using DXLib)
  - It'll only works on Windows
- Metal2 (Using Xamarin.iOS and Xamarin.Mac)
  - It'll only works on iOS & macOS

## To Build

```
git clone https://github.com/xeltica/DotFeather.git
cd DotFeather
nuget restore
dotnet build
```

## Features

- Lightweight processing
    - It can display 10000 sprites at 60fps [<sup>*1</sup>](#f1)
- 2D-specified Graphics System
    - Sprite - Display textures on the screen
    - Tilemap - Map textures on the grid
    - Graphic - Draw lines, rectangles etc
- Keyboard Input
- Mouse Input
- Playing music
- Playing SFX
- High Extensibility
    - Add original rendering method
    - Add original audio processor

----

<p id="f1">1: It depends on your computer's spec.</p>


## Documents

[Documents](docs/index.md)

## Contributing

coming soon


## Donate

You want to donate for me? Thank you very much! Please see [this page](//xeltica.work/en/donation.html) how to pay me.

...or let's become my patron!

[![become_a_patron](https://c5.patreon.com/external/logo/become_a_patron_button@2x.png)](https://patreon.com/xeltica)

## LICENSE

[MIT](LICENSE)
