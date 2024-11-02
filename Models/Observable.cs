#nullable enable
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PolyhydraGames.Core.Models;

 

public class Observable<T> : IObservable<T>, IDisposable 
{
    private T _value = default!; // Initialize with default value

    public T Value => _value;

    private readonly Subject<T> _subject = new();
    public IObservable<T> AsObservable()
    {
        return _subject.AsObservable();
    }

    public bool SetValue(T value)
    {
        if (EqualityComparer<T>.Default.Equals(_value, value))
            return false;

        lock (_subject) // Use a lock for thread safety
        {
            _value = value;
            _subject.OnNext(value);
            return true;
        }
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        return _subject.Subscribe(observer);
    }

    public void Dispose()
    {
        _subject.Dispose();
    }
}

 