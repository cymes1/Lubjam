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

    Animator animator;
    int rand;

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
        animator = GetComponent<Animator>();
        speedPom = speed;
        state = States.Going;
        rand = Random.Range(0, 1000);
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
        animator.SetBool("isAttack", false);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsWalk", true);
        transform.Translate(0, 0, speed * Time.deltaTime);
        
        if (transform.position.x >= antStoperan && isPlayerAnt)
        {
            speed = 0f;
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", true);
        }
    }
    void Fight()
    {
        speed = 0f;

        animator.SetBool("IsAttack", true);
        enemyUnit.TakeDamage(attack*Time.deltaTime);
    }
    void Wait()
    {
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsIdle", true);
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
            if (rand % 2 == 1)
            {
                animator.SetBool("IsDead", true);
            }
            else
            {
                animator.SetBool("IsDead2", true);
            }
            Destroy(this.gameObject);
        }
        else
        {
            health -= damage;
        }
    }

}
