using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] btnAnswers;
    //float timer = 50F;

    public void BtnClick(Button btn) 
    {

            int index1;
            int index2;
            int numb = 0;

            do
            {
                index1 = GetRandom(0, 3);
                index2 = GetRandom(0, 3);
                ++numb;
            print($"Зашли в цикл {numb} раз, и получили {index1}_____{index2}");
            }
            while (index1 == 3 || index2 == 3 || index1 == index2);
            print ($"выбрали это: {index1}_____{index2}");
    }



    int GetRandom(int min, int max)
    {
        return Mathf.RoundToInt(UnityEngine.Random.Range(min, max + 1));
    }

}
