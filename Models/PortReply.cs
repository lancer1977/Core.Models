using System.Collections.Generic;
using System.Linq;

namespace PolyhydraGames.Core.Models;

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