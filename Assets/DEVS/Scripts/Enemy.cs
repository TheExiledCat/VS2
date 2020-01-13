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
  

   

    protected void hit()
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
   virtual protected void Update()
    {
        if (!isAttacked)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y), 0.1f);
            print("walking");
        }
        print(isAttacked);
        if (isAttacked)
        {
            
            if (timer > 0) { timer--; print(timer); }
            else
            {
                timer = hitstun;
                isAttacked = false;
            }
        }
        
        

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
}
