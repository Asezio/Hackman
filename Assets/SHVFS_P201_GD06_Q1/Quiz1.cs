using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Quiz1 : MonoBehaviour
{
    private int num1;
    public int Jesson;

    public int AddTogether(int num1, int num2)
    {
        return (num1 + num2);
    }

    private string[] StudentNames = new string[] {"Lyon", "Nan", "Nico", "Jesson", "Jeff"};

    private void Start()
    {
        num1 = 5;
        for (int i = 0; i < StudentNames.Length; i++)
        {
            Debug.Log(StudentNames[i]);
        }
    }
}
