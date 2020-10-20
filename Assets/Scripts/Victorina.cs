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
    public float timerForResultForGameEnd;
    public int life;
    [Space(15)]
    public Text infoQuestionsAnswers;
    public Text infoTimer;
    public Text infoLife;
    [Space(15)]
    public Image image;
    public Text contentQuestion;
    public Text comment;
    public Text[] txtAnswers;
    public Button[] btnAnswers;
    [Space(15)]
    public Button fiftyfifty;
    public Button plus20;
    public Button help;
    public int chance;
    [Space(15)]
    public Question[] arrayQuestions;
    [Space(15)]
    public Question currentQuestion;
    List<int> listOfRandomNumbers = new List<int>();

    int numberQuestion = 1;
    [SerializeField]
    int numberOfQuestions;
    int numberTrueAnswerButton;
 
    [SerializeField]
    bool startTimer;
    [SerializeField]
    bool checkTimeout;
    bool isGameEnd;
    public bool gameResult;



    void Start()
    {
        timer = timerFromInspector;
        startTimer = true;
        checkTimeout = false;
        isGameEnd = false;
        numberOfQuestions = arrayQuestions.Length;
        SetCommentInMainImage(false, "");
        CheckConditions();
        SetInfoQuestionsAnswers();

        if (!isGameEnd)
        {
            UpdateButtonsToStart();
            SetInfoLife(life);

            GetElementsOfQuestion(GetNextRandomNumberOfQuestion());
            ++numberQuestion;
        }


    }

    void Update()
    {
        if (startTimer)
        {
            SetInfoTimer();
            CheckTimeOut();
        }
    }

    void GetElementsOfQuestion(int number) {
        --number;
        currentQuestion = arrayQuestions[number];
        numberTrueAnswerButton = currentQuestion.numberTrueAnswer;
        int numberOfAnswers = currentQuestion.contentPossibleAnswers.Length;

        contentQuestion.text = currentQuestion.contentQuestion;
        image.sprite = currentQuestion.sprite;

        for (int numbAnswer = 0; numbAnswer < numberOfAnswers; numbAnswer++)
        {
            txtAnswers[numbAnswer].text = currentQuestion.contentPossibleAnswers[numbAnswer];
        }
        
    }

    int GetNextRandomNumberOfQuestion()
    {
        bool isSameNumber = false;
        int number = GetRandom(1, numberOfQuestions);

        do
        {

            foreach (int item in listOfRandomNumbers)
            {
                if (number == item)
                {
                    number = GetRandom(1, numberOfQuestions);
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
        return number;
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
        infoQuestionsAnswers.text = $"{numberQuestion}<color=white> / </color>{numberOfQuestions}";       
    }

    void CheckTimeOut()
    {

        if (Mathf.RoundToInt(timer) == 0)
            {
                checkTimeout = true;
                SetResult(false, numberTrueAnswerButton - 1, "Время для ответа закончилось!");
            }
    }

    void CheckConditions() 
    {
        if (life == 0)
        {
            startTimer = false;
            isGameEnd = true;
            gameResult = false;
            SceneManager.LoadScene(2);
        }

        if ( (numberQuestion > numberOfQuestions) && (life == 0) )
        {
            startTimer = false;
            isGameEnd = true;
            gameResult = false;
            SceneManager.LoadScene(2);
        }


        if (numberQuestion > numberOfQuestions)
        {
            startTimer = false;
            isGameEnd = true;
            gameResult = true;
            SceneManager.LoadScene(2);
        }
    }




    public void OnButtonClick(Button btn) 
    {

        int index = System.Array.IndexOf(btnAnswers, btn);

        if (index == numberTrueAnswerButton - 1)
        {
            SetResult(true, index, "Да, вы правы!");
        }
        else
        {
            SetResult(false, index, "Нет, не верно!");
        }
    }

    void SetResult(bool result, int number, string comment)
    {
        startTimer = false;
        
        timerForResultForGameEnd += timerFromInspector - timer;
        AnswerButtonsOff();
        SetCommentInMainImage(true, comment);
        Button btn = btnAnswers[number];
        if (result)
        {          
            SetButtonColor(btn, Color.green);
            Invoke("Start", 2F);
        }
        else
        {
            
            if (checkTimeout)
            {
                foreach (Button btns in btnAnswers)
                {
                    SetButtonColor(btns, Color.red);
                    if (btns == btnAnswers[numberTrueAnswerButton - 1])
                    {
                        SetButtonColor(btns, Color.green);
                    }
                }
            }
            else
            {
                SetButtonColor(btnAnswers[numberTrueAnswerButton-1], Color.green);
                SetButtonColor(btn, Color.red);
            }

            SetInfoLife(--life);
            Invoke("Start", 2F);
        }
    }

    public void OnButtonFiftyfiftyClick() 
    {
        int index1;
        int index2;

        do
        {
            index1 = GetRandom(0, btnAnswers.Length-1);
            index2 = GetRandom(0, btnAnswers.Length-1);
        } 
        while (index1 == numberTrueAnswerButton-1 || index2 == numberTrueAnswerButton-1 || index1 == index2);

        SetButtonColor(btnAnswers[index1], Color.gray);
        SetButtonColor(btnAnswers[index2], Color.gray);
        SetButtonColor(fiftyfifty, Color.gray);
    }

    public void OnButtonPlus20Click()
    {
        timer += 20F;
        SetButtonColor(plus20, Color.gray);
    }

    public void OnButtonHelpClick()
    {
        SetButtonColor(help, Color.gray);
        AnswerButtonsOff(); 
        if (GetRandom(0, 100) <= chance)
        {
            SetResult(true, numberTrueAnswerButton - 1, "Да, ваш друг прав!");
        }
        else
        {
            int index;
            do
            { 
                index = GetRandom(0, btnAnswers.Length - 1);                
            } 
            while (index == numberTrueAnswerButton - 1);

                SetResult(false, index, "Нет, ваш друг ошибся!");
        }
    }

    int GetRandom(int min, int max)
    {
        return Mathf.RoundToInt(UnityEngine.Random.Range(min, max + 1));
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
            btn.image.color = new Color32(0, 25, 50, 255);
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

    void SetCommentInMainImage(bool isActive, string text)
    {
        comment.enabled = isActive;
        comment.text = text;
    }

}
