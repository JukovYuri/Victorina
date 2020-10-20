using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{

    public Text textResult;
    public Victorina victorina;


    // Start is called before the first frame update
    void Start()
    {
        victorina = FindObjectOfType<Victorina>();

        if (victorina.gameResult)
        {
            int min = Mathf.FloorToInt(victorina.timerForResultForGameEnd / 60);
            int sec = Mathf.RoundToInt(victorina.timerForResultForGameEnd % 60);
            textResult.text = $"Отлично, вы прошли викторину!\n Время, потраченное на размышление: \n{min}<color=white> : </color>{sec.ToString("00")}";
        }

        else
        {
            textResult.text = "У вас 3 ошибки, учитесь)...";
        }

        Destroy(victorina.gameObject);

    }

}
