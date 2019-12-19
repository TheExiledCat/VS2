using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private int health = 100;
    private bool isAttacked = false;
    private float range = 100;
    void Start()
    {
        Debug.Log("cono");
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("IVE BEEN MAC FFALLINN");
        isAttacked = true;//animation
    }


    void hit()
    {
        Debug.Log("start ani");
        //animator.Play("");
    }

    public void takeDamage()
    {
        health--;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacked)
        {
            Debug.Log("isAttacked = false");
            isAttacked = false;
            hit();
        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
