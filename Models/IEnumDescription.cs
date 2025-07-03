using System;

namespace PolyhydraGames.Core.Models;
public interface IEnumDescription
{
    /// <summary>
    /// Name or Title
    /// </summary>
    string Title { get; }
    /// <summary>
    /// Friendly description
    /// </summary>
    string Description { get; }
}

public static class CacheHelper
{
    public static Cache<T> CreateCache<T>(T? value, TimeSpan? expirationLength = default)
    {
        if (expirationLength == default)
        {
            expirationLength = new TimeSpan(0, 5, 0); // Default to 5 minutes
        }

        return new Cache<T>(value, expirationLength);
    }
}