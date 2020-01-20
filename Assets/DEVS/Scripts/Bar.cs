using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
   public  bool right;
    public Sprite blue;
    public Sprite red;
    void Update()
    {
        if (right) GetComponent<SpriteRenderer>().sprite = red;
        else GetComponent<SpriteRenderer>().sprite = blue;
    }

}
