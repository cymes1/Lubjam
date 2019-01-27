using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAfterDeadPlayer : MonoBehaviour
{
    public float speed1 = 0f;
    public float speed2 = 0f;
    public float speed3 = 2.5f;
    void Update()
    {
        transform.Translate(speed1 * Time.deltaTime, speed2 * Time.deltaTime, speed3 * Time.deltaTime);
        
    }
    private void OnTriggerExit(Collider other)
    {
        
            Destroy(this.gameObject,1f);
    }
}
