using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victorina : MonoBehaviour
{
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

        


    }

    void Update()
    {
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
