using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LINQExample : MonoBehaviour
{
    private void Awake()
    {
        //Data Source
        var names = new[] {"Bill", "Steve", "James", "Juno"};
        
        //Query Syntax
        var namesWithQuery = from name in names
            where name.Contains('a')
            select name;
        //Method syntax
        var namesWithAMethod = names.Where(n => n.Contains('a'));
        foreach (var name in namesWithQuery )
        {
            Debug.Log(name);
        }

        foreach (var name in namesWithAMethod)
        {
            Debug.Log(name);
        }
    }
}
