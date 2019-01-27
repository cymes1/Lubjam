using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expedition : MonoBehaviour
{
    public enum LootType
    {
        Food, Resource
    }
    private enum States
    {
        GoingOnExpedition, OnExpedition, ReturningFromExpedition
    }

    public float speed;

    private LootType lootType;
    private States state;
    private int antCount;
    private float timeToStop;
    private int lootAmount;
    private GameMaster gameMaster;

    public void Init(LootType lootType, int antCount, float timeToStop, GameMaster gameMaster)
    {
        this.lootType = lootType;
        this.antCount = antCount;
        this.timeToStop = timeToStop;
        this.gameMaster = gameMaster;

        lootAmount = antCount * Random.Range(1, 4);
    }

    void Update()
    {
        switch(state)
        {
            case States.GoingOnExpedition:
            GoOnExpedition();
            break;

            case States.OnExpedition:
            LookForResources();
            break;

            case States.ReturningFromExpedition:
            ReturnFromExpedition();
            break;
        }       
    }

    private void GoOnExpedition()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void LookForResources()
    {
        timeToStop -= Time.deltaTime;

        if(timeToStop < 0)
            state = States.ReturningFromExpedition;
    }

    private void ReturnFromExpedition()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ExpeditionTarget" && state == States.GoingOnExpedition)  
            state = States.OnExpedition;
        else if(other.tag == "HouseEntrance" && state == States.ReturningFromExpedition)
            ReturnLoot();
    }

    private void ReturnLoot()
    {
        if(lootType == LootType.Food)
            gameMaster.Food += lootAmount;
        else
            gameMaster.Resource += lootAmount;
        Destroy(gameObject);
    }

    public float TimeToStop { get { return timeToStop; } }
}
