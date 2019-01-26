using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float mousePosition = Input.mousePosition.y / Screen.height;

        if(mousePosition < 0.02f)
            transform.Translate(0, -speed * Time.deltaTime, 0);
        else if(mousePosition > 0.98f)
            transform.Translate(0, speed * Time.deltaTime, 0);


    }
}
