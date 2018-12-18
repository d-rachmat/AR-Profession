using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelQuizController : MonoBehaviour {

    void OnMouseDown()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
