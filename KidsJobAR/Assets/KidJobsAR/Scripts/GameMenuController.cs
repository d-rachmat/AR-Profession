using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct JobComponent
{
    public string Name;
    public string TextInfo;
}

public class GameMenuController : MonoBehaviour
{
    public GameObject InfoCanvas;
    public GameObject JobSelectCanvas;
    public GameObject InfoBtn;
    public AudioSource JobInfo;

    public JobComponent[] JobComponents;
    private int _jobIndex;

    public int JobIndex 
    {
        get { return _jobIndex; }
        set { _jobIndex = value; SetInfoText(value); OnChanged.Invoke(value); }
    }
    public Button CaptureBtn;
    public Button SelectJobBtn;

    public Text InfoText;

    public void ShowInfoCanvas()
    {
        if (JobInfo!=null)
        {
            JobInfo.Stop();
            JobInfo.Play();
        }        
    }
    public void ShowJobSelectCanvas()
    {
        bool isActive = (JobSelectCanvas.activeSelf) ? false : true;
        JobSelectCanvas.SetActive(isActive);
        CaptureBtn.enabled = !isActive;
        if (InfoCanvas.activeSelf)
        {
            InfoCanvas.SetActive(false);
        }
    }
    public void SetInfoText(int jobIndex)
    {
        InfoText.text = JobComponents[JobIndex].TextInfo;
    }
    public void SelectInfo(AudioSource thisAudio)
    {
        if (JobInfo!=null)
        {
            JobInfo.Stop();
        }
        
        JobInfo = thisAudio;
    }

    private void Start()
    {
        SetInfoText(JobIndex);
    }

    private void OnEnable()
    {
        //UDTEventHandler.OnSuccess += ActivateInfoBtn;
    }

    private void OnDisable()
    {
        //UDTEventHandler.OnSuccess -= ActivateInfoBtn;
    }
    
    public delegate void ChangeActiveChara(int index);
    public static event ChangeActiveChara OnChanged;

    public void ChangeScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

    public void PlayButtonSfx()
    {
        if(AudioController.Instance!= null)
            AudioController.Instance.PlaySfx(0);
    }

    //public void ActivateInfoBtn()
    //{
    //    InfoBtn.SetActive(true);
    //}
}
