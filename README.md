# <img src="docs/logo.svg"/>
[![Build status](https://img.shields.io/appveyor/ci/xeltica/dotfeather.svg?style=for-the-badge)][ci]
[![GitHub Releases](https://img.shields.io/github/release/xeltica/DotFeather.svg?style=for-the-badge)][releases]
[![Nuget](https://img.shields.io/nuget/v/DotFeather.svg?style=for-the-badge)](https://www.nuget.org/packages/DotFeather/)
[![Discord](https://img.shields.io/discord/572071627991416851?label=discord&style=for-the-badge)](https://discord.gg/e2TCF4m)

DotFeather is a lightweight cross-platform generic 2D game engine for C#/.NET Standard 2.1.

[日本語でもご覧いただけます。](README-ja.md)

## Supported Platform

- Windows
- macOS
  - Currently not usable on latest version of macOS. We are still investigating the cause.
- GNU/Linux

## To Build

```
git clone https://github.com/xeltica/DotFeather.git
cd DotFeather
nuget restore
dotnet build
```

## Features

- Lightweight processing
- 2D-specified Graphics System
	- Sprite - Display textures on the screen
	- Tilemap - Map textures on the grid
	- Graphic - Draw lines, rectangles etc
	- Container - An object which can contain other drawables
	- Text - An object which can draw text
	- 9-slice Sprite - A special sprite to split into 9 sheets to resize smoothly
- A Function to Take Screenshot
- A Feature to capture screen as a serial-numbered pictures
- Scene Management
- Keyboard Input
- Mouse Input
- Playing music
- Playing SFX
- High Extensibility
	- Add original rendering method
	- Add original audio processor

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

DotFeather depends on several third-party software. See these licenses: [THIRD_PARTIES.md](THIRD_PARTIES.md)

[ci]: https://ci.appveyor.com/project/Xeltica/dotfeather
[issues]: //github.com/xeltica/dotfeather/issues
[pulls]: //github.com/xeltica/dotfeather/pulls
[releases]: //github.com/xeltica/dotfeather/releases
