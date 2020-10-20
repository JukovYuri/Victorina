using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{

    public Text textResult;
    public GameResult gameResult;


    // Start is called before the first frame update
    void Start()
    {
        gameResult = FindObjectOfType<GameResult>();

        if (gameResult.result)
        {
            int min = Mathf.FloorToInt(gameResult.spentTime / 60);
            int sec = Mathf.RoundToInt(gameResult.spentTime % 60);
            textResult.text = $"Отлично, вы прошли викторину!\n Время, потраченное на размышление: {min}<color=white> : </color>{sec.ToString("00")}";
        }

        else
        {
            textResult.text = "У вас больше 3 ошибок. Изучайте материал)";
        }

        Destroy(gameResult.gameObject);

    }

}
