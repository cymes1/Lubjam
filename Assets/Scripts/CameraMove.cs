using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Speed")]
    public float scrollSpeed = 15;
    public float zoomSpeed = 25;
    public float scrollKeyboardSpeed = 15;
    [Header("Limits")]
    public float minZoom = 40;
    public float maxZoom = 20;
    public Vector2 minPosition = new Vector2(0, 0);
    public Vector2 maxPosition = new Vector2(400, 400);

    private GameObject contener;
    private float scrollSpeedUp = 0;

    void Start()
    {
        contener = gameObject.transform.parent.gameObject;
    }

    private void Update()
    {
        // Przesuwanie kamery myszka i klawiatura
        if ((Input.mousePosition.y >= Screen.height * 0.95 || Input.GetKey(KeyCode.UpArrow)) && contener.transform.position.y < maxPosition.y)
        {
            contener.transform.Translate(Vector3.forward * Time.deltaTime * (scrollSpeed + scrollSpeedUp));
        }

        if ((Input.mousePosition.y <= Screen.height * 0.05 || Input.GetKey(KeyCode.DownArrow)) && contener.transform.position.y > minPosition.y)
        {
            contener.transform.Translate(Vector3.back * Time.deltaTime * (scrollSpeed + scrollSpeedUp));
        }

        if ((Input.mousePosition.y <= Screen.width * 0.05 || Input.GetKey(KeyCode.LeftArrow)) && contener.transform.position.y > minPosition.y)
        {
            contener.transform.Translate(Vector3.left * Time.deltaTime * (scrollSpeed + scrollSpeedUp));
        }

        if ((Input.mousePosition.y >= Screen.width * 0.95 || Input.GetKey(KeyCode.RightArrow)) && contener.transform.position.y < maxPosition.y)
        {
            contener.transform.Translate(Vector3.right * Time.deltaTime * (scrollSpeed + scrollSpeedUp));
        }
    }

}
