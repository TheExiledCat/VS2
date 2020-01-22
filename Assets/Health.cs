using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Health : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update
    Battle b;
    public GameObject[] hearts;
    public TextMeshProUGUI t;
    void Start()
    {
        b = GetComponent<Battle>();
    }

    public void TakeDamage()
    {
        health--;
        hearts[health].SetActive(false);
        b.a.anim.SetTrigger("hurt");
        b.canAttack = false;
        b.timer = b.hitstun;
        t.text = health.ToString();
        b.invis = b.hitstun*3;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
