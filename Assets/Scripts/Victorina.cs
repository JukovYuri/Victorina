using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Victorina : MonoBehaviour
{
    public float timer;
    public int life;
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

    int numberQuestion;
    int numberOfQuestions;
    float newTimer;


    void Start()
    {
        newTimer = timer;
        numberOfQuestions = arrayQuestions.Length;
        SetInfoLife(life);
        SetInfoQuestionsAnswers();
        GetQuestions(ref numberQuestion);


    }

    void Update()
    {
        SetInfoTimer();
        AllConditions();
    }

    void GetQuestions(ref int number) {

        currentQuestion = arrayQuestions[number++];
        int numberOfAnswers = currentQuestion.contentPossibleAnswers.Length;

        contentQuestion.text = currentQuestion.contentQuestion;
        image.sprite = currentQuestion.sprite;


        for (int numberAnswer = 0; numberAnswer < numberOfAnswers; numberAnswer++)
        {
            txtAnswers[numberAnswer].text = currentQuestion.contentPossibleAnswers[numberAnswer];
        }
    }

    void CheckAnswer()
    {

    }

    void SetInfoTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.FloorToInt(timer % 60 );
            infoTimer.text = $"{min}<color=white> : </color>{sec.ToString("00")}";
        }
       

    }

    void SetInfoLife(int l)
    {
        infoLife.text = $"<color=white>x</color> {l}";
    }

    void SetInfoQuestionsAnswers()
    {
        infoQuestionsAnswers.text = $"{numberQuestion + 1}<color=white> / </color>{numberOfQuestions}";       
    }

    void AllConditions()
    {

            if (Mathf.FloorToInt(timer) == 0)
            {
                SetInfoLife(--life);
                SetInfoQuestionsAnswers();
                GetQuestions(ref numberQuestion);
                SetNewTimer();
            //раскрасить

        }


        if (life <= 0)
            {
                SceneManager.LoadScene(2); //fail
            }

        if (numberOfQuestions == numberQuestion)
            {
                SceneManager.LoadScene(2); //win
            }

    }

    void SetNewTimer() 
    {
        timer = newTimer;
    }

    public void OnButtonClick(Button btn) 
    {
        int index = System.Array.IndexOf(btnAnswers, btn);

        if (index + 1 == currentQuestion.numberTrueAnswer)
        {
            SetInfoQuestionsAnswers();
            GetQuestions(ref numberQuestion);
            SetNewTimer();
            //раскрасить да
        }
        else
        {
            SetInfoLife(--life);
            SetInfoQuestionsAnswers();
            GetQuestions(ref numberQuestion);
            SetNewTimer();
            //раскрасить нет
        }
    }

    public void OnButtonFiftyfiftyClick() 
    {
        int index1;
        int index2;
        index1 = GetRandom(0, btnAnswers.Length);
        index2 = GetRandom(0, btnAnswers.Length);
        while (index1 != currentQuestion.numberTrueAnswer && index2 != currentQuestion.numberTrueAnswer)
        {
            index1 = GetRandom(0, btnAnswers.Length);
            index2 = GetRandom(0, btnAnswers.Length);
        }
        btnAnswers[index1].image.color = Color.grey;
        btnAnswers[index1].interactable = false;

        btnAnswers[index1].image.color = Color.grey;
        btnAnswers[index2].interactable = false;

        fiftyfifty.interactable = false;

        SetButtonColor(fiftyfifty, Color.grey);

    }

    public void OnButtonPlus20Click()
    {
        timer += newTimer;
    }

    public void OnButtonHelpClick()
    {

    }

    int GetRandom(int min, int max)
    {
        return (int) Random.Range(min, max+1);
    }

    void SetButtonColor(Button btn, Color color)
    {
        btn.image.color = color;
        if (btn.transform.childCount > 0)
        {

        }


            }
}
