using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    private int health;
    private void OnEnable()
    {
        health = PlayerInputComponent.health;
        Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
        
    }

    private void OnDisable()
    {
        //Always unsubscribe inOnDisable
        Evently.Instance.Subscribe<DamageEvent>(OnDamaged);
    }

    private void OnDamaged(DamageEvent evt)
    {
        health = PlayerInputComponent.health;
        Debug.Log("Health: " + health.ToString()); 
    }


}

public class DamageEvent
{
    
}
