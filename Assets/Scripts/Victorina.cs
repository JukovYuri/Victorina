using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class Victorina : MonoBehaviour
{
    public float timerFromInspector;
    float timer;
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

    [SerializeField]
    int numberQuestion = 0;
    [SerializeField]
    int numberOfQuestions;
 
    [SerializeField]
    bool startTimer;



    void Start()
    {
        numberOfQuestions = arrayQuestions.Length;
        timer = timerFromInspector;
        startTimer = true;
        CheckConditions();
        UpdateButtonsToStart();
        SetInfoLife(life);
        SetInfoQuestionsAnswers();
        GetNextQuestions(numberQuestion);       
        ++numberQuestion;
    }

    void Update()
    {
        if (startTimer)
        {
            SetInfoTimer();
        }

        CheckTimeOut();
    }

    void GetNextQuestions(int number) {
        currentQuestion = arrayQuestions[number];
        int numberOfAnswers = currentQuestion.contentPossibleAnswers.Length;

        contentQuestion.text = currentQuestion.contentQuestion;
        image.sprite = currentQuestion.sprite;


        for (int numbAnswer = 0; numbAnswer < numberOfAnswers; numbAnswer++)
        {
            txtAnswers[numbAnswer].text = currentQuestion.contentPossibleAnswers[numbAnswer];
        }
    }

    void SetInfoTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.RoundToInt(timer % 60);
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

    void CheckTimeOut()
    {

        if (Mathf.RoundToInt(timer) == 0)
            {
                SetResult();
            }
    }



    void CheckConditions() {
        if (life == 0)
        {
            startTimer = false;
            //SceneManager.LoadScene(2); //fail
            print("жизни закогчмлмсь");
        }

        if (numberQuestion + 1 > numberOfQuestions)
        {
            startTimer = false;
            //SceneManager.LoadScene(2); //win
            print("вопросы закогчмлмсь");
        }
    }




    public void OnButtonClick(Button btn) 
    {
        startTimer = false;
        AnswerButtonsOff();
        int index = System.Array.IndexOf(btnAnswers, btn);

        if (index == currentQuestion.numberTrueAnswer-1)
        {
            SetResult(true, index);
        }
        else
        {
            SetResult(false, index);
        }
    }

    void SetResult(bool result, int number)
    {
        Button btn = btnAnswers[number];
        if (result)
        {
            SetButtonColor(btn, Color.green);
            Invoke("Start", 2F);
        }
        else
        {
            SetButtonColor(btnAnswers[currentQuestion.numberTrueAnswer-1], Color.green);
            SetButtonColor(btn, Color.red);
            SetInfoLife(--life);
            Invoke("Start", 2F);
        }
    }

    void SetResult()
    {
        startTimer = false;
        foreach (Button btn in btnAnswers)
        {
            SetButtonColor(btn, Color.red);
            if (btn == btnAnswers[currentQuestion.numberTrueAnswer - 1])
            {
                SetButtonColor(btn, Color.green);
            } 
        }
        SetInfoLife(--life);
        Invoke("Start", 2F);
    }




    public void OnButtonFiftyfiftyClick() 
    {
        int index1;
        int index2;
        index1 = GetRandom(0, btnAnswers.Length-1);
        index2 = GetRandom(0, btnAnswers.Length-1);
        while (index1 != currentQuestion.numberTrueAnswer && index2 != currentQuestion.numberTrueAnswer)
        {
            index1 = GetRandom(0, btnAnswers.Length-1);
            index2 = GetRandom(0, btnAnswers.Length-1);
        }
        SetButtonColor(btnAnswers[index1], Color.gray);
        SetButtonColor(btnAnswers[index2], Color.gray);
        SetButtonColor(fiftyfifty, Color.gray);

    }

    public void OnButtonPlus20Click()
    {
        timer += 20F;
    }

    public void OnButtonHelpClick()
    {

    }

    int GetRandom(int min, int max)
    {
        return (int) UnityEngine.Random.Range(min, max+1);
    }

    void SetButtonColor(Button btn, Color color)
    {
        btn.image.color = color;
        btn.GetComponent<Outline>().effectColor = color * 1.5F;

        if (btn.transform.GetChild(0).GetComponent<Image>())
        {
            btn.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        if (color == Color.gray)
        {
            btn.interactable = false;
            Text[] text = btn.GetComponentsInChildren<Text>();
            foreach (Text item in text)
            {
                item.color = new Color (1,1,1,0.5F);
            }
        }
     }

    void UpdateButtonsToStart()
    {
        foreach (Button btn in btnAnswers)
        {      
            btn.interactable = true;
            btn.image.color = new Color32(0, 32, 64, 255);
            btn.GetComponent<Outline>().effectColor = new Color32(102, 255, 204, 255);

            if (btn.transform.GetChild(0).GetComponent<Image>())
            {
                btn.transform.GetChild(0).GetComponent<Image>().enabled =true;
            }
          
                Text[] text = btn.GetComponentsInChildren<Text>();
                foreach (Text item in text)
                {
                    item.color = Color.white;
                }

            if (btn.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>())
            {
                btn.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 32, 64, 255);
            }
        }
    }

    void AnswerButtonsOff() 
    {

        foreach (Button btn in btnAnswers)
        {
            btn.interactable = false;
            SetButtonColor(btn, Color.gray);
        }
    }

}
