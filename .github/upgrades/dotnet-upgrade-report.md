# .NET 8 Upgrade Report

## Project target framework modifications

| Project name                                   | Old Target Framework    | New Target Framework         | Commits                   |
|:-----------------------------------------------|:-----------------------:|:----------------------------:|:--------------------------|
| Pokedex.Services\Pokedex.Services.csproj       | net6.0                  | net8.0                       | baffddf5                  |
| Pokédex.Model\Pokedex.Model.csproj             | net6.0                  | net8.0                       | 5c9b6d03                  |

## NuGet Packages

| Package Name                        | Old Version | New Version | Commit Id                                 |
|:------------------------------------|:-----------:|:-----------:|:------------------------------------------|
| Newtonsoft.Json                     |   13.0.1    |  13.0.4     | e7988884                                  |

## All commits

| Commit ID              | Description                                          |
|:-----------------------|:-----------------------------------------------------|
| 09b94253               | Commit upgrade plan                                  |
| baffddf5               | Update target framework to net8.0 in Pokedex.Services.csproj |
| 5c9b6d03               | Update target framework to net8.0 in Pokedex.Model.csproj    |
| e7988884               | Update Newtonsoft.Json to 13.0.4 in Pokedex.Model.csproj     |

## Test results

| Test Project                                          | Passed | Failed | Skipped |
|:------------------------------------------------------|:------:|:------:|:-------:|
| Pokedex.Services.Tests\Pokedex.Services.Tests.csproj  | 11     | 0      | 0       |

## Next steps

- The `Pokédex` Blazor WebAssembly app and `Pokedex.Services.Tests` already targeted net8.0 and required no changes.
- Consider upgrading to .NET 9.0 (STS) or evaluating .NET 10.0 in the future, depending on your support window preferences.
- Optionally migrate `Newtonsoft.Json` usage in `Pokedex.Model` to `System.Text.Json` for better performance and native trimming support in WebAssembly.
