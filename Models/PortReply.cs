using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Core.Models.Serialization;

namespace PolyhydraGames.Core.Models;

public static class JsonHelper
{
    public static ISerializationProvider Provider { get; } = new SystemTextJsonHelper();

    public static object FromJson(this string data, Type type, bool continueOnError = true)
    {
        try
        {
            return string.IsNullOrEmpty(data)
                ? Activator.CreateInstance(type)
                : Provider.DeserializeObject(data, type, continueOnError);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Activator.CreateInstance(type);
        }
    }
    public static T FromJson<T>(this string value, bool continueOnError = true)
    {
        if (Provider == null) throw new NullReferenceException("ISerialization provider was not set. Please initialize this before use");
        return string.IsNullOrEmpty(value) ? default : Provider.DeserializeObject<T>(value, continueOnError);
    }
    public static string ToJson(this object value)
    {
        if (Provider == null) throw new NullReferenceException("ISerialization provider was not set. Please initialize this before use");
        return Provider.SerializeObject(value);
    }
}

public static class CSVExtensions
{
    public static ISerializationProvider Provider { get; set; }
    public static object FromCSV(this string data, Type type, bool continueOnError = true)
    {
        try
        {
            return string.IsNullOrEmpty(data)
                ? Activator.CreateInstance(type)
                : Provider.DeserializeObject(data, type, continueOnError);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Activator.CreateInstance(type);
        }
    }
    public static T FromCSV<T>(this string value, bool continueOnError = true)
    {
        if (Provider == null) throw new NullReferenceException("ISerialization provider was not set. Please initialize this before use");
        return string.IsNullOrEmpty(value) ? default : Provider.DeserializeObject<T>(value, continueOnError);
    }
    public static string ToCSV(this object value)
    {
        if (Provider == null) throw new NullReferenceException("ISerialization provider was not set. Please initialize this before use");
        return Provider.SerializeObject(value);
    }
}
public class PortReply : PortReply<string>
{

}

public class PortReply<T>
{
    public string Method { get; set; }
    public Dictionary<string, string> Headers { get; set; }
    public Dictionary<string, string> Query { get; set; }
    public T? Content { get; set; }
    public override string ToString()
    {
        return $"Method: {Method} \nHeaders: {Headers.Select(x => x.Key + ":" + x.Value).Aggregate((x, y) => x + ", " + y)} \nQuery: {Query.Select(x => x.Key + ":" + x.Value).Aggregate((x, y) => x + ", " + y)} ";
    }
    public T? Data { get; set; }


}