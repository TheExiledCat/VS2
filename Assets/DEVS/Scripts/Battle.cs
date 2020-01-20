using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Battle : MonoBehaviour
{
    public Collider2D[] left;
    public Collider2D[] right;
    int animationIndex;
    bool sword;
    bool bow;
    public bool canAttack=true;
    public float range;
    public LayerMask enemies;
public int timer;
    int invisTime;
    [SerializeField]
    Enemy dashLeft,dashRight;
    [SerializeField]
    int invis,hitstun;
    Animations a;
    public bool idle;
    [SerializeField]
    GameObject elements;
    Vector3 scale;
    
   

    void Attack(bool Right)
    {

        if (!Right&&dashLeft)
        {

            StartCoroutine(dash(dashLeft));
           
        }
        else if(Right&&dashRight)
        {
            StartCoroutine(dash(dashRight));
            
            
        }
        else {
            miss(Right);
            print("miss");
            canAttack = false;
            timer = hitstun;

        }
        
    }
    void miss(bool right)
    {
        GetComponent<SoundEffects>().miss();
        a.anim.SetTrigger("attack");
        a.index++;
        if (right)
        {
            transform.GetChild(0).localScale = new Vector3(scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            transform.position += Vector3.right * range;
        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(-scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            transform.position += Vector3.left * range;
        }
    }
    IEnumerator dash(Enemy target)
    {
        int frames = 5;
        GetComponent<SoundEffects>().play();
        a.anim.SetTrigger("attack");
        a.index++;
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (target.transform.position.x < transform.position.x)
        {
            transform.GetChild(0).localScale = new Vector3(-scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            for (int i = 0; i < frames; i++)
            {
                transform.position = new Vector3(transform.position.x-dist/frames, transform.position.y);
                yield return new WaitForEndOfFrame();
            }
            
          
            
            
           
            if (target)
            {
                GetComponent<Particles>().hit(target.head.transform.position, false);
                dashLeft.GetComponent<Enemy>().takeDamage();
            }
           

        }
        else
        {
            transform.GetChild(0).localScale = new Vector3(scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            for (int i = 0; i < frames; i++)
            {
                transform.position = new Vector3(transform.position.x + dist / frames, transform.position.y);
                yield return new WaitForEndOfFrame();
            }


            if (target)
            {
                GetComponent<Particles>().hit(target.head.transform.position, true);
                dashRight.GetComponent<Enemy>().takeDamage();
            }
           
        }

        yield return null;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        a = transform.GetChild(0).GetComponent<Animations>();
        scale = transform.GetChild(0).localScale;

    }

    // Update is called once per frame
    void Update()
    {
        
        left = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - range / 2, 0), new Vector2(range, 1),0,enemies);
        right = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + range / 2, 0), new Vector2(range , 1), 0, enemies);


        if (left.Length > 0)
        {
            dashLeft = left[0].GetComponent<Enemy>();
        }
        if (right.Length > 0) 
        { 
            dashRight = right[0].GetComponent<Enemy>(); 
        }

        if (Input.GetMouseButtonDown(0)&&canAttack) Attack(false);
        if (Input.GetMouseButtonDown(1) && canAttack) Attack(true);
        if (timer>0&&canAttack==false)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                if(transform.GetChild(i).GetComponent<SpriteRenderer>())
                transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            idle = false;
            timer--;
        }else
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<SpriteRenderer>())
                    transform.GetChild(i).GetComponent<SpriteRenderer>().color = Color.white;
            }
            idle = true;
            timer = hitstun;
            canAttack = true;
        }
        
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x - range / 2,0), new Vector3(range, 1));
        Gizmos.DrawWireCube(new Vector3(transform.position.x+range / 2,0), new Vector3(range ,1));
    }
}
