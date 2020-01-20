using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Bar[] bars;
    [SerializeField]
    Sprite[] hpNumbers;
    private Animator animator;
    
    public int health;
    [SerializeField]
    int hitstun;
    int timer = 0;
    private bool isAttacked = false;
    private float range = 100;
    Vector3 startscale;
    private bool canAttack=true;
    public GameObject hpBox;
    Sprite greysprite;
    Vector3 boxscale;
    [SerializeField]
    float speed;
    bool hasBar;
    EnemyAnim anim;
   public  GameObject head;
    
   void Start()
    {
        anim = GetComponent<EnemyAnim>();
        head = transform.GetChild(0).GetChild(2).gameObject;
        boxscale = hpBox.transform.localScale;
        greysprite = hpBox.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
        hpBox.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hpNumbers[health-1];
        startscale = transform.localScale;
 
    }

    protected void hit()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().TakeDamage();
        Debug.Log("start ani");
        anim.Punch();
    }

    public void takeDamage()
    {
        health--;
        if (health > 0)
        {
            timer = hitstun;
            canAttack = false;
            isAttacked = true;
            hpBox.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = hpNumbers[health-1];
        }
        else 
        {
            Destroy(gameObject);
        }

    }
    
    // Update is called once per frame
   virtual protected void Update()
    {
        
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(startscale.x * -1, transform.localScale.y, transform.localScale.z);
            hpBox.transform.localScale = new Vector3(-boxscale.x, boxscale.y, boxscale.y);
        }
        else{
            transform.localScale = startscale;
            hpBox.transform.localScale = boxscale;
        }
        if ( Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) > 3) 
        {
            
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, transform.position.y), speed/100);//movement
            anim.walking = true;
        }
        else if(canAttack) {
            hit();
            timer = hitstun;
            canAttack = false;
            anim.walking = false;
        }
        
       
        if (!canAttack)
        {
            
            if (timer > 0) { timer--; print(timer); }
            else
            {
                canAttack = true;
                timer = hitstun;
                isAttacked = false;
            }
        }
        
        

        
    }
}
