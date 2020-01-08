using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int timer;
    int invisTime;
    [SerializeField]
    Enemy dashLeft,dashRight;
    [SerializeField]
    int invis,hitstun;
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
        if (target.transform.position.x < transform.position.x) transform.position = target.transform.position + Vector3.right;
        else transform.position = target.transform.position - Vector3.right;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        left = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - range / 2, transform.position.y), new Vector2(range, 1),0,enemies);
        right = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + range / 2, transform.position.y), new Vector2(range , 1), 0, enemies);
        if (left.Length > 0) dashLeft = left[0].GetComponent<Enemy>();
        if (right.Length > 0) dashRight = right[0].GetComponent<Enemy>();

        if (Input.GetMouseButtonDown(0)&&canAttack) Attack(false);
        if (Input.GetMouseButtonDown(1) && canAttack) Attack(true);
        if (timer>0&&canAttack==false)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
            timer--;
        }else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            timer = hitstun;
            canAttack = true;
        }
        
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x - range / 2, transform.position.y), new Vector3(range, 1));
        Gizmos.DrawWireCube(new Vector3(transform.position.x+range / 2, transform.position.y), new Vector3(range , 1));
    }
}
