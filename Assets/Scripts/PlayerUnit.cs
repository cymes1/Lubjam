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

    public Animator animator;
    //public GameObject shootAfterDead,shootAfterDead2;
    public GameMaster gameMaster;
    int rand;

    public float speed = 1;
    public float health = 5f;
    public float attack = 1f;
    public string localTag;
    public float antStoperan = 5f;
    public bool isPlayerAnt = false;
    public int unityPlayerType;

    private float speedPom;
    public States state;
    public PlayerUnit enemyUnit;

    private void Start()
    {
       // animator = GetComponent<Animator>();
        speedPom = speed;
        state = States.Going;
        rand = Random.Range(0, 1000);
    }
    public void Init(GameMaster master)
    {
        gameMaster = master;
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
        //animator.Play("Walk");

        if (transform.position.x >= antStoperan && isPlayerAnt)
        {
            state = States.Waiting;
            //animator.Play("Orc_idle");
            animator.SetBool("IsWalk", false);
            animator.SetBool("IsIdle", true);
            
        }
    }
    void Fight()
    {
        //animator.Play("Attack");
        animator.SetBool("IsAttack", true);
        enemyUnit.TakeDamage(attack*Time.deltaTime);
    }
    void Wait()
    {
        
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsIdle", true);
        animator.SetBool("IsAttack", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stop")
        {
            state = States.Waiting;
        }
        else if (other.tag == "Destroy")
        {
            Loting();
            Destroy(this.gameObject,0.5f);
            
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
            
            if (rand % 2 == 1)
            {
                animator.SetBool("IsDead", true);
            }
            else
            {
                animator.SetBool("IsDead2", true);
            }
            if(isPlayerAnt && unityPlayerType == 1)
            {
                gameMaster.WorkerCount--;
                enemyUnit.state = States.Going;
                Destroy(this.gameObject);
            }
            else if(isPlayerAnt && unityPlayerType == 2)
            {
                gameMaster.WarriorCount--;
                enemyUnit.state = States.Going;
                Destroy(this.gameObject);
            }
            else if (isPlayerAnt && unityPlayerType == 3)
            {
                gameMaster.KnightCount--;
                enemyUnit.state = States.Going;
                Destroy(this.gameObject);
            }
            enemyUnit.state = States.Going;
            Destroy(this.gameObject);
            
            //Instantiate(shootAfterDead, this.gameObject.transform.position, this.gameObject.transform.rotation);
            //Instantiate(shootAfterDead2, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        else
        {
            health -= damage;
        }
    }

    public void Loting()
    {
        Debug.Log("Pladruje"+ " " + gameMaster.WorkerCount + " " + gameMaster.Resource + " " + gameMaster.Food);
        float random = Random.Range(3, 15);
        gameMaster.WorkerCount = (int)(gameMaster.WorkerCount - (gameMaster.WorkerCount*(random/100)));
        random = Random.Range(3, 15);
        gameMaster.Resource = (int)(gameMaster.Resource - (gameMaster.Resource * (random / 100)));
        random = Random.Range(3, 15);
        gameMaster.Food = (int)(gameMaster.Food - (gameMaster.Food * (random / 100)));
        Debug.Log("Uciekam" + " " + gameMaster.WorkerCount + " " + gameMaster.Resource + " " + gameMaster.Food);
    }

}
