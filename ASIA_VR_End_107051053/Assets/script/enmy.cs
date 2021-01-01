﻿using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class enmy : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent nav;
    public Animator ani;
    public float cd = 2f;
    private float timer;

    [Header("speed"), Range(0f, 50f)]
    public float spd = 3;
    [Header("distance"), Range(0f, 50f)]
    public float spdstop = 1;
    [Header("die sc"), Range(0f, 5f)]
    public float sc = 0.2f;
    [Header("txet")]
    public Text text;
    [Header("hp")]
    public int hp = 50;
    [Header("hit")]
    public int hit = 10;



    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        //player = GameObject.Find("Player").transform;
        nav.speed = spd;
        nav.stoppingDistance = spdstop;
    }

    public void Update()
    {
        StartCoroutine(diee());
        track();
        attack();
    }

    public void attack()
    {
        if(hp > 0)
        {
 if(nav.remainingDistance < spdstop)
        {
            timer += Time.deltaTime;

            Vector3 pos = player.position;
            pos.y = player.position.y;
            transform.LookAt(pos);

            if (timer >= cd)
            {
            ani.SetTrigger("atk");
                timer = 0;
            }
        }
        }
       
    }

    public void track()
    {
        nav.SetDestination(player.position);
        ani.SetBool("walk" ,nav.remainingDistance> spdstop);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(hp>0)
        {
        if (other.tag == "atk")
        {
            addi();
        }
        }

    }

    private void addi()
    {
        hp -= hit;
        text.text = ""+hp;
    }

    private IEnumerator diee()
    {
        if(hp <= 0 )
        {
            ani.SetBool("die" , true);

            yield return new WaitForSeconds(sc);
            gameObject.SetActive(false);
        }
    }
}
