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
    public Enemy dashLeft, dashRight;


    public int invis,hitstun;
    public Animations a;
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
            StartCoroutine(miss(Right));
            print("miss");
            canAttack = false;
            timer = hitstun;

        }
        
    }
    IEnumerator miss(bool right)
    {
        StartCoroutine( GameManager.GM.miss());
        int xOff=1;
        
        GetComponent<SoundEffects>().miss();
        a.anim.SetTrigger("attack");
        a.index++;
       
        if (!right)
        {
            xOff *= -1;
        }
        
        transform.GetChild(0).localScale = new Vector3(scale.x * xOff, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
        for (int i = 0; i < 5; i++)
        {
            transform.position = new Vector3(transform.position.x + (range* xOff) / 5, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }
    IEnumerator dash(Enemy target)
    {
        GameManager.GM.combo();
        int xOff=1 ;
        int frames = 5;
        invis = hitstun;
        GetComponent<SoundEffects>().play();
        a.anim.SetTrigger("attack");
        a.index++;
        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (target.transform.position.x < transform.position.x)
        {
            if (target)
            {
                GetComponent<Particles>().hit(target.head.transform.position, false, target.health);
                dashLeft.GetComponent<Enemy>().takeDamage();
            }
            transform.GetChild(0).localScale = new Vector3(-scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            xOff = -xOff;
            
          
            
            
           
          
           

        }
        else
        {
            if (target)
            {
                GetComponent<Particles>().hit(target.head.transform.position, true,target.health);
                dashRight.GetComponent<Enemy>().takeDamage();
            }
            transform.GetChild(0).localScale = new Vector3(scale.x, transform.GetChild(0).localScale.y, transform.GetChild(0).localScale.z);
            
           


            
           
        }
        for (int i = 0; i < frames; i++)
        {
            transform.position = new Vector3(transform.position.x + ((dist-2)*xOff) / frames, transform.position.y);
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        a = transform.GetChild(0).GetComponent<Animations>();
        scale = transform.GetChild(0).localScale;

    }
    Enemy GetClosestOfArray(Collider2D[] c, Vector3 pos)
    {
        Enemy e ;
        e = c[0].GetComponent<Enemy>();
        for (int i = 0; i < c.Length; i++)
        {
            if (Vector3.Distance(c[i].gameObject.transform.position, pos) < Vector2.Distance(e.transform.position, pos))
            e = c[i].GetComponent<Enemy>();
        }
        return e;
    }
    // Update is called once per frame
    void Update()
    {
        
        left = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - range / 2, 0), new Vector2(range, 1),0,enemies);
        right = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + range / 2, 0), new Vector2(range , 1), 0, enemies);
        
      
        if (invis > 0)
        {
            invis--;
        }
        if (left.Length > 0)
        {
            dashLeft = GetClosestOfArray(left, transform.position);
        }
        if (right.Length > 0) 
        {
            dashRight=GetClosestOfArray(right, transform.position);
        }

        if (Input.GetMouseButtonDown(0)&&canAttack) Attack(false);
        if (Input.GetMouseButtonDown(1) && canAttack) Attack(true);
        if (timer>0&&canAttack==false)
        {
            idle = false;
            timer--;
        }else
        {
            idle = true;
            timer = hitstun;
            canAttack = true;
            
        }
        
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x - range / 2,0)+Vector3.left*0.5f, new Vector3(range, 1));
        Gizmos.DrawWireCube(new Vector3(transform.position.x+range / 2,0) + Vector3.right * 0.5f, new Vector3(range ,1));
    }
}
