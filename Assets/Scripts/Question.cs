using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Victorina/Question", fileName ="Q_")]
public class Question : ScriptableObject
{
    public Sprite sprite;

    [Space(15)] [TextArea(15, 50)] public string contentQuestion;
    [Space(15)] public int numberTrueAnswer;
    [Space(15)] [TextArea(5, 10)] 
    public string [] contentPossibleAnswers = new string [4];
    


}
