using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Button[] btnAnswers;
    float timer = 50F;

    public void BtnClick(Button btn) 
    {
        int index = Array.IndexOf(btnAnswers, btn);
        print($"текущий индекс: {index}");

        Color32 color = new Color32(0, 32, 64, 255);
        Color color2 = color;

        int value = (int) UnityEngine.Random.Range(0F, 5F);
        print($"текущий Random: {color2}");

        Text[] text = btn.GetComponentsInChildren<Text>();
        foreach (Text item in text)
        {
            item.color = Color.blue;
        }

    }

    void Update()
    {
        timer -= Time.deltaTime;
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.RoundToInt(timer % 60);
        print($"{min} : {sec}");
    }


}
