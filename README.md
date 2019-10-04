# <img src="docs/logo.svg"/>
[![Build status](https://img.shields.io/appveyor/ci/xeltica/dotfeather.svg?style=for-the-badge)][ci]
[![GitHub Releases](https://img.shields.io/github/release/xeltica/DotFeather.svg?style=for-the-badge)][releases]
[![Nuget](https://img.shields.io/nuget/v/DotFeather.svg?style=for-the-badge)](https://www.nuget.org/packages/DotFeather/)
[![Discord](https://img.shields.io/discord/572071627991416851?label=discord&style=for-the-badge)](https://discord.gg/e2TCF4m)

DotFeather is a lightweight cross-platform generic 2D game engine for C#/.NET Standard 2.0.

[日本語](README-ja.md) ・ English

## Supported Platform

- Windows
- macOS

## Supported Rendering Backend

- OpenGL 1.0 (Using OpenTK)

### In Planning

- GNU/Linux Support (I have to fix bug to run DotFeahter on Linux.)
	- for iOS / Android
- OpenGL ES 2.0 (Using OpenTK)
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
	- Container - An object which can contain other drawables
	- Text - An object which can draw text
	- 9-slice Sprite - A special sprite to split into 9 sheets to resize smoothly
- A Function to Take Screenshot
- A Feature to capture screen as a serial-numbered pictures
- Keyboard Input
- Mouse Input
- Playing music
- Playing SFX
- High Extensibility
	- Add original rendering method
	- Add original audio processor

----

<p id="f1">1: It depends on your computer's power.</p>

## FAQ

### An error that libgdiplus cannot be found on macOS

Install homebrew and run the following command:

```
brew install mono-libgdiplus
```

### An error that libgdiplus cannot be found on GNU/Linux

Install libgdiplus from your package manager or build it from source-code.

## Documents

[Documents](https://xeltica.github.io/DotFeather/docs)

## Contributing

Please see [Contribution Guide](CONTRIBUTING.md).

[![GitHub issues](https://img.shields.io/github/issues/xeltica/dotfeather.svg?style=for-the-badge)][issues]
[![GitHub pull requests](https://img.shields.io/github/issues-pr/xeltica/dotfeather.svg?style=for-the-badge)][pulls]

## Donate

You want to donate for me? Thank you very much! Please see [this page](//xeltica.work/en/donation.html) how to pay me.

...or let's become my patron!

[![become_a_patron](https://c5.patreon.com/external/logo/become_a_patron_button@2x.png)](https://patreon.com/xeltica)

## LICENSE

[![License](https://img.shields.io/github/license/xeltica/dotfeather.svg?style=for-the-badge)](LICENSE)


[ci]: https://ci.appveyor.com/project/Xeltica/dotfeather
[issues]: //github.com/xeltica/dotfeather/issues
[pulls]: //github.com/xeltica/dotfeather/pulls
[releases]: //github.com/xeltica/dotfeather/releases
