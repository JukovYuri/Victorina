using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victorina : MonoBehaviour
{
    public float timer;
    [Space(15)]
    public Text infoQuestionsAnswers;
    public Text infoTimer;
    public Text infoLife;
    [Space(15)]
    public Image image;
    public Text contentQuestion;
    public Text[] txtAnswers;
    public Button[] btnAnswers;
    [Space(15)]
    public Button fiftyfifty;
    public Button plus20;
    public Button help;
    [Space(15)]
    public Question[] arrayQuestions;
    [Space(15)]
    public Question currentQuestion;

    void Start()
    {

        //запуск таймера


        //пересортировать массив


        currentQuestion = arrayQuestions[0];

    }

    void Update()
    {
        timer -= Time.deltaTime;
        int min = Mathf.FloorToInt(timer / 60);
        int sec = Mathf.FloorToInt(timer % 60);
        infoTimer.text = $"{min}<color=white> : </color>{sec.ToString("00")}";
        if (min == 0 && sec == 0)
        {
            SceneManager.LoadScene(2);
        }
        


        //проверка на правильность
        //изменение инфо игры
    }

    void GetQuestions (int i) {

        currentQuestion = arrayQuestions[i];

        contentQuestion.text = currentQuestion.contentQuestion;
        image.sprite = currentQuestion.sprite;


        for (int j = 0; j < currentQuestion.contentPossibleAnswers[j].Length; j++)
        {
            txtAnswers[j].text = currentQuestion.contentPossibleAnswers[j];
        }
    }

    void CheckAnswer()
    {

    }
}
