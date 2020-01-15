using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    Sprite[] hpNumbers;
    private Animator animator;
    [SerializeField]
    private int health;
    [SerializeField]
    int hitstun;
    int timer = 0;
    private bool isAttacked = false;
    private float range = 100;
    Vector3 startscale;
    private bool canAttack=true;
    public GameObject hpBox;
   void Start()
    {
        startscale = transform.localScale;
    }

    protected void hit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Battle>().TakeDamage();
        Debug.Log("start ani");
        //animator.Play("");
    }

    public void takeDamage()
    {
        health--;
        timer = hitstun;
        isAttacked = true;
        hpBox.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hpNumbers[health - 1];
    }

    // Update is called once per frame
   virtual protected void Update()
    {
        
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(startscale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else{
            transform.localScale = startscale;
        }
        if (!isAttacked && Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 3&&canAttack) 
        {

            transform.position = Vector2.MoveTowards(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y), 0.1f);
            print("walking");
        }else
        {
            hit();
            timer = hitstun;
        }
        print(isAttacked);
        if (isAttacked)
        {
            
            if (timer > 0) { timer--; print(timer); canAttack = false; }
            else
            {
                canAttack = true;
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
