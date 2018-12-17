using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    public GameObject[] JobModels;
    public GameMenuController GameMenuCtrl;

    private void OnEnable()
    {
        GameMenuController.OnChanged += SetActiveChara; 
    }

    private void OnDisable()
    {
        GameMenuController.OnChanged -= SetActiveChara;
    }

    private void Start()
    {
        GameMenuCtrl = FindObjectOfType<GameMenuController>();
        SetActiveChara(JobIndex);
    }

    public int JobIndex 
    {
        get { return GameMenuCtrl.JobIndex;}
    }

    public void SetActiveChara(int index)
    {
        CloseOtherChara();
        JobModels[index].SetActive(true);
    }

    public void CloseOtherChara()
    {
        for (int i = 0; i < JobModels.Length; i++)
        {
            JobModels[i].SetActive(false);
        }
    }
}
