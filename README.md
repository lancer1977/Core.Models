# Core.Models

A .NET utility library providing common models, helpers, and reactive extensions for the PolyhydraGames ecosystem.

## What This Library Provides

`PolyhydraGames.Core.Models` is a shared utility library containing common DTOs, caching, serialization helpers, and reactive extensions used across multiple projects. It eliminates duplication by centralizing frequently-needed model types and helpers.

### Key Types

| Category | Type | Purpose |
|----------|------|---------|
| **Caching** | `Cache<T>` | Simple in-memory cache with automatic expiration |
| | `CacheHelper` | Utility methods for cache management |
| **Data** | `CSVExtensions` | CSV parsing and generation extension methods |
| | `JsonHelper` | JSON serialization/deserialization helpers |
| **Reactive** | `ObservableExtensions` | Custom reactive extensions for System.Reactive |
| | `ObservableFileMonitor` | File system watcher wrapper using observables |
| | `SubjectObservable<T>` | Subject-based observable implementation |
| **Enums** | `EnumDescription` | Enum metadata and display name resolution |
| | `EnumDescriptionExtensions` | Extension methods for enum description lookup |
| **State** | `OneTimeUseBool` | Boolean that flips from `true` to `false` after first read |
| | `ToggleBoolean` | State toggle helper |
| | `InjectableSave` | Save mechanism for dependency-injectable services |
| **Network** | `PortReply` | Network port reply model |
| | `PortReplyExtensions` | Extension methods for port reply handling |
| **Utilities** | `TimeStamp` | Timestamp wrapper with formatting helpers |
| | `DelayTimer` | Timer utility for delayed operations |
| | `IPortListener` | Interface for port listening services |

## Common Use Cases

### 1. Caching Data
```csharp
var cache = new Cache<MyData>(TimeSpan.FromMinutes(5));
cache.Set("key", myData);
var result = cache.Get("key"); // null if expired
```

### 2. Watching Files Reactively
```csharp
var monitor = new ObservableFileMonitor("path/to/file.txt");
monitor.Changed.Subscribe(change => Console.WriteLine($"File changed: {change}"));
```

### 3. Enum Descriptions
```csharp
var description = EnumDescription.GetDescription(MyEnum.SomeValue);
// Returns the [Description] attribute value or the member name
```

### 4. CSV Parsing
```csharp
var records = csvContent.FromCsv<MyRecord>();
var output = records.ToCsv();
```

### 5. JSON Helpers
```csharp
var json = JsonHelper.Serialize(myObject);
var obj = JsonHelper.Deserialize<MyType>(json);
```

## Integration Instructions

### Install via NuGet (internal feed)
```xml
<PackageReference Include="PolyhydraGames.Core.Models" Version="*" />
```

### Target Frameworks
- **Main package:** `net8.0` and `net9.0` (multi-target)
- **Test project:** `net10.0`

### Prerequisites
- .NET 8.0 SDK or later
- The following NuGet packages are automatically resolved:
  - `PolyhydraGames.Core.Interfaces` (v2.0.0.43+)
  - `PolyhydraGames.Extensions` (v2.1.1.58+)
  - `System.Reactive` (v6.0.1+)

### Building
```bash
# Build the solution
dotnet build PolyhydraGames.Core.Models.sln

# Run tests
dotnet test Tests/PolyhydraGames.Core.Models.Test.csproj
```

### Typical Usage
```csharp
using PolyhydraGames.Core.Models;
using PolyhydraGames.Core.Models.CSV;
using PolyhydraGames.Core.Models.Json;
using PolyhydraGames.Core.Models.Cache;

// Now use any of the types listed above
```

## Projects That Use This Library

- OAuth.Core
- All API projects
- Spotabot
- Channel Cheevos


## 📖 Documentation
Detailed documentation can be found in the following sections:
- [Feature Index](./docs/features/README.md)
- [Core Capabilities](./docs/features/core-capabilities.md)
