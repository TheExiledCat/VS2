using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private int health;
    [SerializeField]
    int hitstun;
    int timer = 0;
    private bool isAttacked = false;
    private float range = 100;
    void Start()
    {
        Debug.Log("cono");
        animator = GetComponent<Animator>();
    }

   

    void hit()
    {
        Debug.Log("start ani");
        //animator.Play("");
    }

    public void takeDamage()
    {
        health--;
        timer = hitstun;
        isAttacked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacked)
        {
            GetComponent<SpriteRenderer>().color = Color.blue;
            if (timer > 0) timer--;
            else
            {
                timer = hitstun;
                isAttacked = false;
            }
        }
        else GetComponent<SpriteRenderer>().color = Color.red;
        

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
