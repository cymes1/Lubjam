using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed;
    public float highestCamMove = 50f;
    public float lowestCamMove = -20f;

    private float speedPom;
    private float startPosY;

    private void Start()
    {
        speedPom = speed;
        startPosY = transform.position.y;
    }

    void Update()
    {
       // Debug.Log(this.gameObject.transform.position.y);
        float mousePosition = Input.mousePosition.y / Screen.height;

        if (mousePosition < 0.02f) 
        {           
                transform.Translate(0, -speed * Time.deltaTime, 0);            
        }
        else if (mousePosition > 0.98f) 
        {
            
                transform.Translate(0, speed * Time.deltaTime, 0);
        }


    }
}
