﻿using System.Collections;
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
    public GameObject antPrefab;

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
        Animator animator = antPrefab.GetComponent<Animator>();
        animator.SetBool("IsWalk", true);
        animator.SetBool("IsIdle", false);
        animator.SetBool("IsAttack", false);
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
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void LookForResources()
    {
        ReturnLoot();
    }

    private void ReturnFromExpedition()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
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
        if (lootType == LootType.Food)
        {
            Debug.Log("food: " + gameMaster.Food);
            gameMaster.Food += lootAmount;
            Debug.Log("food: " + gameMaster.Food);
        }
        else
        {
            Debug.Log("resource: " + gameMaster.Resource);
            gameMaster.Resource += lootAmount;
            Debug.Log("resource: " + gameMaster.Resource);
        }
            
        gameMaster.WorkerCount += antCount;
        Destroy(gameObject);
    }

    public float TimeToStop { get { return timeToStop; } }
}
