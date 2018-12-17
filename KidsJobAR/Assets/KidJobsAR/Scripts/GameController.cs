using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button[] MainMenuBtn;
    public AudioController AC;

    private void OnEnable()
    {
        AC = FindObjectOfType<AudioController>();
        MainMenuBtn[0].onClick.AddListener(() => AC.PlaySfx(0));
        MainMenuBtn[1].onClick.AddListener(() => AC.PlaySfx(0)); 
    }

    private void OnDisable()
    {
        MainMenuBtn[0].onClick.RemoveAllListeners();
        MainMenuBtn[1].onClick.RemoveAllListeners();

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
