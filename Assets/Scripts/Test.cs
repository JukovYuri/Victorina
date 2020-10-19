using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] btnAnswers;
    //float timer = 50F;
    List<int> listOfRandomNumbers = new List<int>();
    public void BtnClick(Button btn) 
    {
        //GetRandomNextQuestions();
        int rnd = GetRandom(0,2);
        print(rnd);
    }



    void GetRandomNextQuestions()
    {
        bool isSameNumber = false;
        int number = GetRandom(0, 3);
        do
        {

            foreach (int item in listOfRandomNumbers)
            {
                if (number == item)
                {
                    number = GetRandom(0, 3);
                    isSameNumber = true;
                    break;
                }

                else
                {
                    isSameNumber = false;
                }
            }
        }
        while (isSameNumber);

        listOfRandomNumbers.Add(number);

        foreach (int item in listOfRandomNumbers)
        {
            print(item);
        }
    }







    int GetRandom(int min, int max)
    {
        return Mathf.RoundToInt(UnityEngine.Random.Range(min, max + 1));
    }

}
