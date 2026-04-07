# SunamoCollectionsChangeContent

Provides methods for modifying collections of strings by applying custom transformation functions to every element.

## Features

- Apply a `Func<string?, string?>` to each element with `ChangeContent0`
- Pass one or two additional arguments to the transformation via `ChangeContent1<TArg>` and `ChangeContent2<TArg1, TArg2>`
- Transform only elements matching a predicate with `ChangeContentWithCondition`
- Switch parameter order of the transformation function with `ChangeContentSwitch12<TArg>`
- Automatically remove null or empty strings from results via `ChangeContentArgs`

## Usage

```csharp
using SunamoCollectionsChangeContent;
using SunamoCollectionsChangeContent._public.SunamoArgs;

var list = new List<string?> { "hello", "world", null, "" };
var args = new ChangeContentArgs { ShouldRemoveNull = true, ShouldRemoveEmpty = true };

var result = CAChangeContent.ChangeContent0(args, list, text => text?.ToUpper());
// result: ["HELLO", "WORLD"]
```

## Target Frameworks

`net10.0`, `net9.0`, `net8.0`

## Links

- [NuGet](https://www.nuget.org/profiles/sunamo)
- [GitHub](https://github.com/sunamo/PlatformIndependentNuGetPackages)
- [Developer site](https://sunamo.cz)

## License

MIT
