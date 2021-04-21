using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Serialization : MonoBehaviour
{
    public JSONEnemy enemy1;

    private void OnEnable()
    {
        var enemy = JSONGeneric.Load<JSONEnemy>("Enemy111111");
        JSONGeneric.Save(enemy1,"Enemy1");
    }

    
}
