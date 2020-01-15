using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [HideInInspector]
    public int index;
    [HideInInspector]
    public Animator anim;
    bool idle;
    Battle b;
    // Start is called before the first frame update
    void Start()
    {
        b = transform.parent.GetComponent<Battle>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == 7) index = 0;
        idle = b.idle;
        anim.SetBool("idle", idle);
        anim.SetInteger("index",index);
    }
}
