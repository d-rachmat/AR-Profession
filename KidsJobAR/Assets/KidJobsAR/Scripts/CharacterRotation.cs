using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    float rotSpeed = 1000;

    void OnMouseDrag()
    {
        float rotY = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(0, -rotY, 0, Space.Self);
        float rotX = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;
        transform.Rotate(-rotX, 0, 0, Space.Self);
    }
}
