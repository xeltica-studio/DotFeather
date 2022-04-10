# Contribution guide

[日本語](CONTRIBUTING-ja.md)

Thanks for contributing! Before that, please read this guide.

## To Conrtibutors

Please agree that the source code you provided for this project will be licensed as described in the LICENSE file as same as other code.

## Issue

If you want me to add new features or find bugs, please post it to [GitHub Issues](https://github.com/Xeltica/DotFeather/Issues). Before making Issue, to avoid duplication, please make sure there are no same issues. If exists, upvote it by using reactions or comments.

## Documentation

- Japanese document: `/docs/ja`
- English document:  `/docs/`

## Continuous Integration

DotFeather uses AppVeyor to automatic deployment. Its configuration is in `/appveyor.yml`.

## Coding Style

Basically I compliant [C# Coding Conventions (Official)](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions). Moreover, follow the rules below:

+ Use 4-character tabs for indentation
+ DON'T make fields `public`
+ Define members of classes and structs the following orders:
	+ Properties
	+ Constructor(s)
		+ If have many ones, arrange in ascending order of arguments.
	+ Methods
	+ Overridden Methods
	+ Fields
	+ Nested classes, structs and interfaces
	+ Delegates
+ If you overload methods, locate them adjacently.
+ Define an entrypoint method in a dedicated `static` class.
+ Make string-variables non-null, and initialize them with empty string.

## Design Guideline

### DO NOT make public API dependent on external libraries such as Silk.NET

DotFeather API is designed to be backend (such as Silk.NET) independent.

Do not use the type in the backend for arguments or return value of the newly added API.

However, it is allowed to be used internally or for private or internal members.

## To deploy

This project is always deployed by @Xeltica, a main developer. So this note is for forked projects' maintainers.

1. Make sure latest changes can be built and there is no wrong behaviors in sample code.
1. Commit latest to master
1. Rewrite version number at DotFeather/DotFeather.nuspec
1. Rewrite version number at appveyor.yml
1. Commit changes of 3. and 4.
1. Add a tag named as version number to the commit.
1. Push it
1. :pray:
