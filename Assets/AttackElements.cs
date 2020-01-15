using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackElements : MonoBehaviour
{
    Battle b;
[SerializeField]
    Sprite greyBarLeft,greyBarRight,blueBar,redBar;
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
        if (b.left.Length > 0) left.GetComponent<SpriteRenderer>().sprite = blueBar;
        else left.GetComponent<SpriteRenderer>().sprite = greyBarLeft;
        if (b.right.Length > 0) right.GetComponent<SpriteRenderer>().sprite = redBar;
        else right.GetComponent<SpriteRenderer>().sprite = greyBarRight;



    }
}
