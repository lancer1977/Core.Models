# Core.Models

**Location:** `~/code/Core.Models`

**Purpose:** Core shared models and utilities — common DTOs, helpers used across the ecosystem.

**Assembly:** `PolyhydraGames.Core.Models`

**NuGet Dependencies:**
- `PolyhydraGames.Core.Interfaces`
- `PolyhydraGames.Extensions`
- `System.Reactive`

**Target Frameworks:** net8.0 (implied)

## Key Types

| Type | Purpose |
|------|---------|
| `Cache<T>` | Simple in-memory cache with expiration |
| `CacheHelper` | Cache utilities |
| `CSVExtensions` | CSV parsing/generation |
| `JsonHelper` | JSON serialization helpers |
| `ObservableExtensions` | Reactive extensions |
| `ObservableFileMonitor` | File system watcher wrapper |
| `OneTimeUseBool` | Bool that flips from true to false once |
| `ToggleBoolean` | State toggle helper |
| `TimeStamp` | Timestamp wrapper |
| `EnumDescription` | Enum metadata + display helpers |
| `InjectableSave` | Save mechanism for injectable services |

## Dependencies From

- OAuth.Core
- All API projects
- Spotabot
- Channel Cheevos

## Status

✅ **Working** — Stable utility library.
