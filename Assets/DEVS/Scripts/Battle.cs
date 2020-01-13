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
    bool canAttack=true;
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
    void TakeDamage()
    {

    }

    void Attack(bool Right)
    {
        if (!Right&&dashLeft)
        {
         
            dashLeft.GetComponent<Enemy>().takeDamage();
            dash(dashLeft);
        }
        else if(Right&&dashRight)
        {
            dash(dashRight);
            
            dashRight.GetComponent<Enemy>().takeDamage();
        }
        else {
            print("miss");
            canAttack = false;
            timer = hitstun;

        }
    }

    void dash(Enemy target)
    {
        a.anim.SetTrigger("attack");
        a.index++;

        if (target.transform.position.x < transform.position.x)
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y) + Vector3.right;
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.position = new Vector3(target.transform.position.x, transform.position.y) - Vector3.right;
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }


    


    }

    void PickupSword()
    {

    }
    void StartDuel(Duel duel, Duelist e,Player p)
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        a = transform.GetChild(0).GetComponent<Animations>();

    }

    // Update is called once per frame
    void Update()
    {
        
        left = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - range / 2, 0), new Vector2(range, 1),0,enemies);
        right = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + range / 2, 0), new Vector2(range , 1), 0, enemies);

       
        if (left.Length > 0) dashLeft = left[0].GetComponent<Enemy>();
        if (right.Length > 0) dashRight = right[0].GetComponent<Enemy>();

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
