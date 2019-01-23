using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct QuizComponent
{
    public string Name;
    public string[] QuestionsText;
}

public class QuizController : MonoBehaviour
{    
    public QuizComponent[] Questions;
    public int QuestionIndex = 0;
    public GameObject[] JobModels;
    public Button[] AnswerBtn;
    public Text[] QuestionTexts;
    public Text ResultText;
    public AudioSource Benar, Salah;

    public int Score = 0;
    private int QuestionCount;

    public GameObject WinCanvas;
    private void OnEnable()
    {
        RegisterButton();
    }

    private void OnDisable()
    {
        UnregisterButton();
    }

    private void Start()
    {
        QuestionCount = Questions.Length;
        AssignQuestion(QuestionIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeScene("Main");
        }
    }

    private void NextQuestion()
    {
        StartCoroutine(NextQuestionCoroutine());
    }


    private IEnumerator NextQuestionCoroutine()
    {
        if (JobModels[QuestionIndex] != null)
        {
            JobModels[QuestionIndex].SetActive(false);
        }
        //adding index
        NextIndex();
       
        yield return null;
    }


    public void AssignQuestion(int questionIndex)
    {
        JobModels[questionIndex].SetActive(true);
        var currentQuizComp = Questions[questionIndex];

        #region Setup Button and Text Question
        AnswerBtn[0].name = currentQuizComp.QuestionsText[0];
        QuestionTexts[0].text = currentQuizComp.QuestionsText[0];
        AnswerBtn[1].name = currentQuizComp.QuestionsText[1];
        QuestionTexts[1].text = currentQuizComp.QuestionsText[1];
        AnswerBtn[2].name = currentQuizComp.QuestionsText[2];
        QuestionTexts[2].text = currentQuizComp.QuestionsText[2];
        #endregion
    }

    private void NextIndex()
    {
        if (QuestionIndex < QuestionCount-1)
        {
            QuestionIndex++;
            AssignQuestion(QuestionIndex);
        }
        else
        {
            Text[] winText = WinCanvas.GetComponentsInChildren<Text>();
            winText[0].text = "Selamat, kamu hebat!";
            winText[2].text = Score.ToString();
            if (AudioController.Instance != null)
                AudioController.Instance.PlaySfx(3);
            WinCanvas.SetActive(true);
        }
    }

    public void CheckAnswer(string btnName)
    {
        Debug.Log(btnName);
        //benar
        if (btnName == Questions[QuestionIndex].Name)
        {
            Score += 100;           
            ResultText.text = "Benar!";
            Benar.Play();
            //continue
            NextQuestion();
        }

        //salah
        else
        {
            ResultText.text = "Kurang Tepat!";
            //gameover
            Text[] winText = WinCanvas.GetComponentsInChildren<Text>();
            winText[0].text = "Kamu Kurang Tepat";
            winText[2].text = Score.ToString();
            WinCanvas.SetActive(true);
            Salah.Play();
        }
        StartCoroutine(ShowResult());
        Debug.Log(Score);
    }

    private IEnumerator ShowResult()
    {
        ResultText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        ResultText.gameObject.SetActive(false);
    }

    #region Event-Button
    public void RegisterButton()
    {       
        AnswerBtn[0].onClick.AddListener(() =>
        {
            CheckAnswer(AnswerBtn[0].name);
        });
        AnswerBtn[1].onClick.AddListener(() =>
        {
            CheckAnswer(AnswerBtn[1].name);
        });
        AnswerBtn[2].onClick.AddListener(() =>
        {
            CheckAnswer(AnswerBtn[2].name);
        });

    }

    public void UnregisterButton()
    {
        AnswerBtn[0].onClick.RemoveAllListeners();
        AnswerBtn[1].onClick.RemoveAllListeners();
        AnswerBtn[2].onClick.RemoveAllListeners();
    }

    #endregion

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySfxBtn()
    {
        if (AudioController.Instance != null)
            AudioController.Instance.PlaySfx(0);
    }
}
