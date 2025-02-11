#nullable enable
using System;

namespace PolyhydraGames.Core.Models;

public record EnumDescription<T>(T value, string Title, string Description) where T : struct, Enum;