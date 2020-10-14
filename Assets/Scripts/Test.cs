using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] btnAnswers;

    public void BtnClick(Button btn) 
    {
        int index = Array.IndexOf(btnAnswers, btn);
        print($"текущий индекс: {index}");
    }


}
