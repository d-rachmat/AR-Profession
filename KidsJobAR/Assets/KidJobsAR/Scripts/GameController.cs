using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button[] MainMenuBtn;
    public GameObject ExitDialog;
    public AudioController AC;

    private void OnEnable()
    {
        AC = FindObjectOfType<AudioController>();
        MainMenuBtn[0].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[1].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[2].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[3].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[4].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[5].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[6].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[7].onClick.AddListener(() => AC.PlaySfx(0));
    }

    private void OnDisable()
    {
        MainMenuBtn[0].onClick.RemoveAllListeners();
        MainMenuBtn[1].onClick.RemoveAllListeners();
        MainMenuBtn[2].onClick.RemoveAllListeners();
        MainMenuBtn[3].onClick.RemoveAllListeners();
        MainMenuBtn[4].onClick.RemoveAllListeners();
        MainMenuBtn[5].onClick.RemoveAllListeners();
        MainMenuBtn[6].onClick.RemoveAllListeners();
        MainMenuBtn[7].onClick.RemoveAllListeners();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitDialog.SetActive(true);
        }
    }
}
