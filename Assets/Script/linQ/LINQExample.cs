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
        //n goes to...=> This is called a lambda expression
        //Method 
        var namesWithAMethod = names.Where(n => n.Contains('a'));
        foreach (var name in namesWithQuery )
        {
            //Debug.Log(name);
        }

        foreach (var name in namesWithAMethod)
        {
            //Debug.Log(name);
        }
        
        
        var students = new List<Student>()
        {
            new Student() {Name = "Chris", Age = 22, IQ = 218, Courses = new List<string>(){"Programming","Being Cool","Eating Eggs"}},
            new Student() {Name = "Arno", Age = 20, IQ =80, Courses = new List<string>(){"Design","Arts","Eating Eggs"}},
            new Student() {Name = "Jeff", Age = 22, IQ =101, Courses = new List<string>(){"Programming","Design","Cooking"}},
            new Student() {Name = "Lyon", Age = 24, IQ =108, Courses = new List<string>(){"Programming","Project Management","Eating Eggs"}},
            new Student() {Name = "Jesson", Age = 21, IQ = 518, Courses = new List<string>(){"Programming","Sleeping","Gaming"}},
            new Student() {Name = "Nat", Age = 40, IQ = 98, Courses = new List<string>(){"Design","Running","Eating"}},
            new Student() {Name = "Nan", Age = 21, IQ = 106, Courses = new List<string>(){"Programming","Wang Zhe Rong Yao","Drinking Bubble Tea"}},

        };
        var studentsWhoAreSmart = students
            //.OrderByDescending(s => s.IQ > 100);
            //.TakeWhile(s => s.IQ > 100);
            .Where(s => s.IQ > 100);
            ;
        foreach (var student in studentsWhoAreSmart)
        {
            //Debug.Log(student.Name);
        }

        var youngStudents = students.Where(s => s.Age <= 22).Select(s => s.Name);
        // foreach (var student in youngStudents)
        // {
        //     Debug.Log(student);
        // }

        var FirstDumbStudent = students.FirstOrDefault(s => s.IQ < -100);
        //Debug.Log(FirstDumbStudent.Name);

        var distinctStudents = students.Select(s=>s.Name).Distinct();
        // foreach (var distinctStudent in distinctStudents )
        // {
        //     Debug.Log(distinctStudent);//消除重复数据
        // }

        var skipStudent = students.SkipWhile(s => s.Age < 60).Take(1);
        foreach (var distinctStudent in distinctStudents )
        {
            Debug.Log(distinctStudent);//消除重复数据
        }
    }
}

public class Enemy
{
    public string Name;
    public int HP;
}

public class Student
{
    public string Name;
    public int Age;
    public int IQ;
    public List<string> Courses;
}
