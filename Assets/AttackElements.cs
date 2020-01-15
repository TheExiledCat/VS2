using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackElements : MonoBehaviour
{
    Battle b;
[SerializeField]
    Sprite greyBarLeft,greyBarRight,blueBar,redBar,blueBox,redBox,greyBox;
    public GameObject left;
    public GameObject right;
    
    // Start is called before the first frame update
   
        void Start()
    {
        b = GetComponent<Battle>();
    }
    // Update is called once per frame
    void Update()
    {
        if (b.left.Length > 0)
        {
            left.GetComponent<SpriteRenderer>().sprite = blueBar;
            for (int i = 0; i < b.left.Length; i++)
            {
                if(b.left[i])
                b.left[i].GetComponent<Enemy>().hpBox.GetComponent<SpriteRenderer>().sprite = blueBox;
            }
        }
        else 
        {
            left.GetComponent<SpriteRenderer>().sprite = greyBarLeft;
            
        }
        if (b.right.Length > 0)
        {
            right.GetComponent<SpriteRenderer>().sprite = redBar;
            for (int i = 0; i < b.right.Length; i++)
            {
                if(b.right[i])
                b.right[i].GetComponent<Enemy>().hpBox.GetComponent<SpriteRenderer>().sprite = redBox;
            }
        }
        else
        {
            
            right.GetComponent<SpriteRenderer>().sprite = greyBarRight;
        }



    }
}
