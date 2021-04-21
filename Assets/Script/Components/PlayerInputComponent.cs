using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputComponent : MovementComponent
{
    public static int health;
    public event Action CollectionEvent;

    
    private void OnEnable()
    {
        Evently.Instance.Subscribe<DamageEvent>(OnHurt);
        
    }

    private void OnDisable()
    {
        //Always unsubscribe inOnDisable
        Evently.Instance.Subscribe<DamageEvent>(OnHurt);
    }
    protected override void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentInputDirection = new IntVector2(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentInputDirection = new IntVector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentInputDirection = new IntVector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentInputDirection = new IntVector2(1, 0);
        }
        base.Update();
    }

    private void OnHurt(DamageEvent dvt)
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("You Lose");
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pill>())
        {
            //The publisher PUBLISHES -- or Fires
            Evently.Instance.Publish(new CollectionEvent());
            Destroy(other.gameObject);
        }
    }
}

