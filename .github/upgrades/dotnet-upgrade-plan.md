# .NET 8.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 8.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 8.0 upgrade.
3. Upgrade Pokedex.Services\Pokedex.Services.csproj
4. Upgrade Pokédex.Model\Pokedex.Model.csproj
5. Run unit tests to validate upgrade in the projects listed below:
   - Pokedex.Services.Tests\Pokedex.Services.Tests.csproj

## Settings

This section contains settings and data used by execution steps.

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name                                          | Description                                  |
|:------------------------------------------------------|:--------------------------------------------:|
| Pokédex\Pokédex.csproj                                | Already targets net8.0, no changes needed    |
| Pokedex.Services.Tests\Pokedex.Services.Tests.csproj  | Already targets net8.0, runs as test project |

### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name      | Current Version | New Version | Description                    |
|:------------------|:---------------:|:-----------:|:-------------------------------|
| Newtonsoft.Json   | 13.0.1          | 13.0.4      | Recommended for .NET 8.0       |

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### Pokedex.Services\Pokedex.Services.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net8.0`

#### Pokédex.Model\Pokedex.Model.csproj modifications

Project properties changes:
  - Target framework should be changed from `net6.0` to `net8.0`

NuGet packages changes:
  - Newtonsoft.Json should be updated from `13.0.1` to `13.0.4` (*recommended for .NET 8.0*)
