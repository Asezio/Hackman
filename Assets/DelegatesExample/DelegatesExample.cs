using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class DelegatesExample : MonoBehaviour
{
    //Delegates are converted to classes by the compiler
    //And since they're classes..we can create New objects
    private delegate void MeDelegate();
    private delegate void MeDelegateTakeIntReturnBool(int number);
    private delegate bool MeDelegateInt(int number);
    private delegate int MeDelegateReturnInt();

    private delegate T MeDelegateGeneric<T>();

    private event Action myAction;
    public static TrainSianal TrainSianal;
    public void OnEnable()
    {
        //We are not invoking Foo Here, we're just passing it...
        // MeDelegate meDelegate = new MeDelegate(Foo);
        // //This is a reference to a class, but it is also treated like a Method
        // meDelegate.Invoke();
        //
        // MeDelegate meDelegate2 = Goo;
        //If we write this, the compiler will replace this with an INVOKE call
        //This is shorthand/syntactic sugar

        //meDelegate();
        
        //When this is compiled, we'll get a new MeDelegate, and it is invoke method will be called 
        //With delegates, we are able to treat methods like first class objects
        //InvokeTheDelegate(Foo);
        //??InvokeTheDelegateTakeIntReturnBool(FooTakeIntReturnBool(int number));
        
        //Debug.Log($"Target:{meDelegate.Target},Method:{meDelegate.Method}");
        //Debug.Log($"Target:{meDelegate2.Target},Method:{meDelegate2.Method}");

        //MeDelegateTakeIntReturnBool meDel = FooTakeIntReturnBool;
        //meDel(5);
        
        //meDel.Invoke(5);
        
        //Debug.Log(Square(3));
        //The same reason we parameterize this, is why we paramemterize codemor references to code (methods/function)

        //Before, the difference was just the number.. now we've changed the EXPRESSION. We have changed what the code needs to do
        
        // var result = GetAllTheNumbersLessThanFive(new List<int> {1, 25, 3, 6, 2, 7, 19, 3, 2});
        //
        // foreach (var number in result)
        // {
        //     Debug.Log(number);
        // }
        // var result2 = GetAllTheNumbersLessThanAny(new List<int> {1, 25, 3, 6, 2, 7, 19, 3, 2}, 10);

        // var numbers = new List<int>() {1, 25, 3, 6, 2, 7, 19, 3, 2};
        // var numbersLessThanFive = RunNumbersThroughTheGauntlet(numbers, LessThanFive);
        // var numbersLessThanTen = RunNumbersThroughTheGauntlet(numbers, LessThanTen);
        //
        // var numbersGreaterThanThirteen = RunNumbersThroughTheGauntlet(numbers, GreaterThanThirteen);
        //
        // MeDelegateInt mini = LessThanFive;
        // var isItLessThanFive = mini(33);
        
        //This is Great, but we still have to deal with making methods (LessThanFive...)
        //There's a LOT of extra JUNK
        
        //What if we could just paste the method directly?
        //Let's talk more about =>

        //This is some of the sugar that C# & Microsoft give us
        
        //var resultLessThanFive = RunNumbersThroughTheGauntlet(numbers, n => n < 5);
        //var resultLessThanFive = numbers.Where(n => n < 5);
        
        //Delegate Chaining
        //Adding and removing delegates

        // MeDelegate meDelegate = Moo;
        // meDelegate = (MeDelegate)Delegate.Combine(meDelegate, (MeDelegate)Boo);
        // meDelegate += Sue;
        // meDelegate += Moo;
        // meDelegate -= Moo;
        //
        // meDelegate.Invoke();
        //
        // //There was no target for Moo and Sue, since they are static methods, and static methods, are called on the class ITSELF
        // foreach (var del in meDelegate.GetInvocationList())
        // {
        //     Debug.Log($"Target:{del.Target}, Method:{del.Method}");
        // }

        // MeDelegateReturnInt meDelegateReturnInt = ReturnFive;
        // meDelegateReturnInt += ReturnTen;
        // var value = meDelegateReturnInt();
        //
        // foreach (var del in meDelegateReturnInt.GetInvocationList())
        // {
        //     Debug.Log(del.DynamicInvoke());
        // }

        // MeDelegateGeneric<string> meDelegateString = ReturnChris;
        // //Usually, just like with generics, we don't have to create our own delegates, because we have Actions and Funcs
        // //Funcs have a return
        // Func<int> meFunc = ReturnFive;
        // Func<int, float, int, bool, string> meFunc2 = MyFunc2; 
        // meFunc += ReturnTen;
        // // foreach (var f in meFunc.GetInvocationList())
        // // {
        // //     Debug.Log((f.DynamicInvoke()));
        // // }
        //
        // //Actions return void
        // Action<int> meAct = TakeAnIntReturnVoid;
        // meAct(15);
        //
        // Action doNothingSpecial = DoNothingSpecial;
        // doNothingSpecial();
        // Action<int, int, float> meAct2 = MyAct2;

        #region  Events
        //An event is a delegate, with TWO restrictions : you can't assign them directly, and you can't invoke them directly
        myAction = DoNothingSpecial;
        myAction.Invoke();
        TrainSianal.TrainsCOMING += ATrainComing;

        #endregion


    }

    private void MyAct2(int arg1, int arg2, float arg3)
    {
        throw new NotImplementedException();
    }

    private string MyFunc2(int arg1, float arg2, int arg3, bool arg4)
    {
        return "SSS";
    }


    private void DoNothingSpecial()
    {
        Debug.Log("Not doing anything special");
    }

    private void TakeAnIntReturnVoid(int number)
    {
        Debug.Log(number);
    }


    private string ReturnChris()
    {
        return "Chris";
    }
    private int ReturnFive()
    {
        return 5;
    }
    private int ReturnTen()
    {
    return 10;
    }
    private static void Sue()
    {
        Debug.Log("fgjl;");
    }
    private void Boo()
    {
        Debug.Log("Boooooooo");
    }
    private void Moo()
    {
        Debug.Log("Moooooooo");
    }

    private List<int> RunNumbersThroughTheGauntlet(List<int> numbers, MeDelegateInt gaunlet)
    {
        var gauntletSurvivors = new List<int>();
        
        foreach (var num in numbers)
        {
            if (gaunlet(num))
                gauntletSurvivors.Add(num);
        }

        return gauntletSurvivors;
        //return numbers.Where(num => gaunlet(num)).ToList();
    }

    // private bool LessThanFive(int n) {return n < 5;}
    // private bool LessThanTen(int n) {return n < 10;}
    //
    // private bool GreaterThanThirteen(int n) { return n > 13;}

    // private List<int> GetAllTheNumbersLessThanFive(List<int> ints)
    // {
    //     var numbers = new List<int>();
    //     foreach (var num in ints)
    //     {
    //         if (num < 5)
    //             numbers.Add(num);
    //     }
    //
    //     return numbers;
    //
    //     //Or use LINQ
    //     //return ints.Where(i => i < 5).ToList();
    // }
    //
    // private List<int> GetAllTheNumbersLessThanAny(List<int> ints, int i)
    // {
    //     var numbers = new List<int>(); 
    //     foreach (var num in ints)
    //     {
    //         if (num < i)
    //             numbers.Add(num);
    //     }
    //
    //     return numbers;
    //     
    //     //Or use LINQ
    //     //return ints.Where(i => i < 10).ToList();
    // }
    
    private float Square(float i)
    {
        return i * i;
    }
    
    private void Foo()
    {
        Debug.Log("Foo!");
    }

    private void FooReturnInt(int number)
    {
        Debug.Log("Foo take int");
        //return 0;
    }

    private bool FooTakeIntReturnBool(int number)
    {
        Debug.Log("Foo take int return bool");
        return false;
    }
    
    
    private static void Goo()
    {
        Debug.Log("Goo!");
    }

    private static void InvokeTheDelegate(MeDelegate del)
    {
        del();
    }

    private void ATrainComing()
    {
        Debug.Log("Streeeeeeeeeech!");
    }
    
    // private static void InvokeTheDelegateTakeIntReturnBool(MeDelegateTakeIntReturnBool del)
    // {
    //     del();
    // }
    
    
}
public class TrainSianal
{
    public event Action TrainsCOMING;

    public void HereComesTrain()
    {
        if (TrainsCOMING != null)
            TrainsCOMING.Invoke();
    }
}

public class NaughtyBoy : MonoBehaviour
{
    public TrainSianal TrainSianal = DelegatesExample.TrainSianal;

    private void OnEnable()
    {
        var trainsSignal = DelegatesExample.TrainSianal;
        trainsSignal = null;
    }
}