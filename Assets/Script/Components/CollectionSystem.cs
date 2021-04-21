using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The collection system is our Subscriber or listener
public class CollectionSystem : MonoBehaviour
{
    private void OnEnable()
    {
        Evently.Instance.Subscribe<CollectionEvent>(OnPillCollected);
    }

    private void OnDisable()
    {
        //Always unsubscribe inOnDisable
        Evently.Instance.Subscribe<CollectionEvent>(OnPillCollected);
    }

    private void OnPillCollected(CollectionEvent evt)
    {
        Debug.Log("collect a pill");
    }
}

public class CollectionEvent
{
    
}
