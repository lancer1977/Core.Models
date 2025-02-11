#nullable enable
using System;

namespace PolyhydraGames.Core.Models;

public interface IEnumDescription
{
    /// <summary>
    /// Name or Title
    /// </summary>
    string Title { get;   }
    /// <summary>
    /// Friendly description
    /// </summary>
    string Description { get;  }
}
public record EnumDescription<T>(T Value, string Title, string Description) : IEnumDescription
    where T : struct, Enum  ;