﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackElements : MonoBehaviour
{
    Battle b;
    [SerializeField]
    Sprite greyBarLeft, greyBarRight, blueBar, redBar, blueBox, redBox;
    public GameObject left;
    public GameObject right;

    public GameObject armleft;
    public GameObject armright;
    public float dist;
    public GameObject mouse;
    Vector3 start;
    // Start is called before the first frame update

    void Start()
    {
        start = armleft.transform.localPosition;
        b = GetComponent<Battle>();
    }
    // Update is called once per frame
    void Update()
    {
        moveHands();
        if (b.dashLeft)
        {
            armleft.SetActive(true);
            mouse.SetActive(true);
            left.GetComponent<SpriteRenderer>().sprite = blueBar;
            for (int i = 0; i < b.left.Length; i++)
            {
                if(b.left[i])
                b.left[i].GetComponent<Enemy>().hpBox.GetComponent<SpriteRenderer>().sprite = blueBox;
            }
        }
        else 
        {
            armleft.SetActive(false);
            mouse.SetActive(false);
            left.GetComponent<SpriteRenderer>().sprite = greyBarLeft;
            
        }
        if (b.dashRight)
        {
            mouse.SetActive(true);
            armright.SetActive(true);
            right.GetComponent<SpriteRenderer>().sprite = redBar;
            for (int i = 0; i < b.right.Length; i++)
            {
                if(b.right[i])
                b.right[i].GetComponent<Enemy>().hpBox.GetComponent<SpriteRenderer>().sprite = redBox;
            }
        }
        else
        {
            mouse.SetActive(false);
            armright.SetActive(false);
            right.GetComponent<SpriteRenderer>().sprite = greyBarRight;
        }

        

    }
    void moveHands()
    {
        
        armleft.transform.position -=Vector3.right* 0.05f;
        if (Vector3.Distance(transform.position, armleft.transform.position) >= dist) armleft.transform.localPosition = start;
        armright.transform.position += Vector3.right * 0.05f;
        if (Vector3.Distance(transform.position, armright.transform.position) >= dist) armright.transform.localPosition = new Vector3(start.x+4,start.y,start.z);


    }
}
