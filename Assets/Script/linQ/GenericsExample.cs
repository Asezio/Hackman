using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GenericsExample : MonoBehaviour
{
     public void OnEnable()
     {
          // var t = GetComponent<Transform>();
          // var l = new List<String>();
          //
          // var pairIntInt = new PairIntInt(){First = 5,Second = 6};
          //var pairString = new PairString(){First = "Jacky",Second="Sue"};
          var pairString = new Pair<string,string>{First = "Jacky",Second="Sue"};
          var things = new List<int>() {5, 4, 5, 6};
          PrintTheThings(things);
     }

     public void PrintTheThing<T>(T thing)
     {
          Debug.Log(thing);
     }

     
     public void PrintTheThings<T>(List<T> things)
     {
          for (var i = 0; i < things.Count; i++)
          {
               Debug.Log(things[i]);
          }
     }
     //Constraints

     // public T Produce<T>() where T : new()
     // {
     //      
     // }
}
//This is not dry, our program is EXPLORING in complexity, and will become difficult to maintain over time
//Generics to the rescue
//Generic class
public class PairIntInt
{
     public int First;
     public int Second;
}

public class PairString
{
     public string First;
     public string Second;

}
public class PairIntFloat
{
     public int First;
     public float Second;
}

public class Pair<T, U>
{
     public T First;
     public U Second;
}

public class ClassOne
{
     
}