using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{

    public int speed = 1;
    public int time_ants_return=10;
    
    public GameObject arrow;
    public GameObject anticon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.RotateAround(arrow.transform.position, Vector3.back, speed * Time.deltaTime);

        if(time_ants_return>2) anticon.SetActive(false);
        else if(time_ants_return<=2) anticon.SetActive(true);
    }


}
