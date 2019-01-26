using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public enum States
    {
        Going,
        Fighting,
        Waiting
    }

    public float speed = 1;
    public float health = 5f;
    public float attack = 1f;
    public string localTag;
    public float antStoperan = 5f;
    public bool isPlayerAnt = false;

    private float speedPom;
    public States state;
    public PlayerUnit enemyUnit;

    private void Start()
    {
        speedPom = speed;
        state = States.Going;
    }

    private void Update()
    {
        switch (state)
        {
            case States.Going:
                Move();
                break;
            case States.Fighting:
                Fight();
                break;
            case States.Waiting:
                Wait();
                break;
        }
        
    }
    void Move()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= antStoperan && isPlayerAnt)
        {
            speed = 0f;
        }
    }
    void Fight()
    {
        enemyUnit.TakeDamage(attack*Time.deltaTime);
    }
    void Wait()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stop")
        {
            state = States.Waiting;
        }
        else if (other.tag != localTag)
        {
            state = States.Fighting;
            enemyUnit = other.transform.parent.GetComponent<PlayerUnit>();
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Stop")
        {
            state = States.Going;
        } else if (other.tag != localTag)
        {
            state = States.Going;
        }
    }

    public void TakeDamage(float damage)
    {
        if(health-damage <= 0)
        {
            enemyUnit.state = States.Going;
            Destroy(this.gameObject);
        }
        else
        {
            health -= damage;
        }
    }

}
