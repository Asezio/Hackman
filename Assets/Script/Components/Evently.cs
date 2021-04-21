
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Evently
{
    private static Evently eventlyManagerInstance;
    public static Evently Instance => eventlyManagerInstance ?? (eventlyManagerInstance = new Evently());

    private readonly Dictionary<Type, Delegate> _delegates = new Dictionary<Type, Delegate>();
    //This system will have three methods

    //Subscribe
    //Be something like this...+= D:D:

    //Unsubscribe
    //Be something like this...-= D:D:

    //Publish
    //Gonna have something todo with Invoke...  D:D:

    public void Subscribe<T>(Action<T> observer)
    {
        
        if (_delegates.ContainsKey(typeof(T)))
        {
            _delegates[typeof(T)] = Delegate.Combine(_delegates[typeof(T)], observer);
        }
        else
        {
            _delegates[typeof(T)] = observer;
        }
    }

    public void UnSubscribe<T>(Action<T> observer)
    {
        if(!_delegates.ContainsKey(typeof(T))) return;
        
        var currentDel = Delegate.Remove(_delegates[typeof(T)], observer);

        if (currentDel == null)
            _delegates.Remove(typeof(T));
        else
            _delegates[typeof(T)] = currentDel;

    }

    public void Publish<T>(T observer)
    {
        if (observer == null)
        {
            Debug.Log($"Invalid event argument");
            return;
        }

        if (_delegates.ContainsKey(observer.GetType()))
            _delegates[typeof(T)].DynamicInvoke(observer);
    }
}