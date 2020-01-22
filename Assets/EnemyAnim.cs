using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    bool alive=true;
    Animator anim;
    int index;
    public bool walking;
    SoundEffects s;
    Enemy e;

    // Start is called before the first frame update
    void Start()
    {
        e = GetComponent<Enemy>();
        s = GameObject.FindGameObjectWithTag("Player").GetComponent<SoundEffects>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    public void die()
    {
        alive = false;
        anim.SetTrigger("death");
        Destroy(gameObject, 0.5f);
       
    }
    public void hurt()
    {
        anim.SetTrigger("hurt");
    }
    public void Punch()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(s.punches[Random.Range(0, 2)]);
        anim.SetTrigger("attack");
        anim.SetInteger("index", index);
        index++;
        if (index > 3) index = 0;
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("canAttack",e.canAttack);
        anim.SetBool("alive",alive);
        anim.SetBool("walking", walking);
    }
}
