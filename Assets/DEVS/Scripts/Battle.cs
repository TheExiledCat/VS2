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
    bool attack;
    public float range;
    public LayerMask enemies;
    
    void TakeDamage()
    {

    }

    void Attack(bool right)
    {

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
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(new Vector3(transform.position.x - range / 2, transform.position.y), new Vector3(range + transform.position.x, 1));
        Gizmos.DrawWireCube(new Vector3(transform.position.x+range / 2, transform.position.y), new Vector3(range-transform.position.x , 1));
    }
}
