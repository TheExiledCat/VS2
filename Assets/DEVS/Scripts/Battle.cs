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
    
    void TakeDamage()
    {

    }

    void Attack(bool Right)
    {
        if (!Right&&left.Length>0)
        {
            print("hit " + left[0].name);
            left[0].GetComponent<Enemy>().takeDamage();
        }
        else if(Right&&right.Length>0)
        {
            print("hit " + right[0].name);
            left[0].GetComponent<Enemy>().takeDamage();
        }
        else {
            print("miss");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        left = Physics2D.OverlapBoxAll(new Vector2(transform.position.x - range / 2, transform.position.y), new Vector2(range + transform.position.x, 1),0,enemies);
        right = Physics2D.OverlapBoxAll(new Vector2(transform.position.x + range / 2, transform.position.y), new Vector2(range - transform.position.x, 1), 0, enemies);


        if (Input.GetMouseButtonDown(0)&&canAttack) Attack(false);
        if (Input.GetMouseButtonDown(1) && canAttack) Attack(true);
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x - range / 2, transform.position.y), new Vector3(range + transform.position.x, 1));
        Gizmos.DrawWireCube(new Vector3(transform.position.x+range / 2, transform.position.y), new Vector3(range-transform.position.x , 1));
    }
}
