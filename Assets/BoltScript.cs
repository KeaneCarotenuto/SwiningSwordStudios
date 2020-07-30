﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScript : MonoBehaviour
{
    //Used to control how the lightning splits off and branches.
    private float branchTime;
    private float timeBetweenBranch = 0.1f;     //how long to wait before splitting off
    private int itterationNum = 0;              //Keeps track of which itteration the current bolt is
    private int branchAmount = 0;               //Keeps track of how many bolts this bolt has spawned
    private float spawnTime;
    private float destroyTime = float.MaxValue;

    public int maxBranches = 2;                 //Max number of branches to spawn
    public int maxItterations = 2;              //Max number of itterations after this one
    public float maxBoltAliveTime = 10;           //Max time after spawning before bolt is destroyed
    public float afterHitAliveTime = 10f;          //How long after hitting something should the bolt stay alive

    public GameObject boltToSpawn;
    public SphereCollider mainCollider;

    private void Awake()
    {
        //Saves time when spawned, and how long till it can spawn another bolt
        spawnTime = Time.time;
        branchTime = Time.time + timeBetweenBranch;
    }

    private void Start()
    {
        //If the bolt is the origonal, change initial time to split to very soon (makes attack more like shotgun than sniper)
        if (gameObject.name == "OriginalBolt")
        {
            branchTime = Time.time + timeBetweenBranch / 100;
        }
    }

    //When bolt collides with something, make the bolt stick to the object, stop the bolt, 
    private void OnTriggerEnter(Collider other)
    {
        transform.parent = other.transform;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        destroyTime = Time.time + afterHitAliveTime;
        Debug.Log("Hit: " + Time.time + " Destroy at: " + destroyTime);
    }

    private void FixedUpdate()
    {
        if (Time.time - spawnTime > maxBoltAliveTime || Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }

        if (GetComponent<Rigidbody>().velocity.magnitude >= maxBoltAliveTime)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100), UnityEngine.Random.Range(-100, 100)));

            if (Time.time >= branchTime && itterationNum < maxItterations && branchAmount < maxBranches)
            {
                branchTime = Time.time + timeBetweenBranch;

                branchAmount += 1;

                Debug.Log("Spawn");

                GameObject tempBolt = Instantiate(boltToSpawn, transform.position, transform.rotation, GameObject.Find("BoltContainer").transform);
                tempBolt.GetComponent<Rigidbody>().AddForce(transform.forward * 6000);
                tempBolt.GetComponent<BoltScript>().itterationNum = itterationNum + 1;
                tempBolt.name = tempBolt.GetComponent<BoltScript>().itterationNum + "Bolt" + branchAmount;
            }
        }
    }

    public void SetBranch(int _branch)
    {
        itterationNum = _branch;
    }
}

