#nullable enable
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PolyhydraGames.Core.Models;

public class Observable<T> : IObservable<T>
{
    private T _value;

    public T Value
    {
        get => _value;
  
    }

    public bool SetValue(T value)
    {
        
            if (EqualityComparer<T>.Default.Equals(_value, value)) return false;
            _value = value;
            _subject.OnNext(value);
            return true;
    }
    private readonly Subject<T> _subject = new();
    private readonly IObservable<T> _observable;
    public Observable()
    {
        _observable = _subject.AsObservable();
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        return _observable.Subscribe(observer);
    }


}