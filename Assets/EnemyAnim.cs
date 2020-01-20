using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator anim;
    int index;
    public bool walking;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
    public void Punch()
    {
       
        anim.SetTrigger("attack");
        anim.SetInteger("index", index);
        index++;
        if (index > 3) index = 0;
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walking", walking);
    }
}
