#nullable enable
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace PolyhydraGames.Core.Models;

[Obsolete("Use ValueObservable<T> instead for thread saftey and better implementation")]
public class SubjectObservable<T> : IObservable<T>
{
    private readonly bool _checkEquality;
    private T _value;

    public T Value
    {
        get => _value;

    }

    public bool SetValue(T value)
    {
        if (_checkEquality && EqualityComparer<T>.Default.Equals(_value, value))
        {

            return false;
        }


        _value = value;
        _subject.OnNext(value);
        return true;
    }

    private readonly Subject<T> _subject = new();
    private readonly IObservable<T> _observable;
    /// <summary>
    /// Initializer
    /// </summary>
    /// <param name="checkEquality">This determines if we should update the object and notify every time a value is sent regardless of equality</param>
    public SubjectObservable(bool checkEquality = true)
    {
        _checkEquality = checkEquality;
        _observable = _subject.AsObservable();
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        return _observable.Subscribe(observer);
    }
        public void Dispose()
    {
        _subject.Dispose();
    }

}

public class ValueObservable<T> : IObservable<T>, IDisposable where T : class
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

 