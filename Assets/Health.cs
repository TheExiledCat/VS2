using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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
        if (health > 0)
        {
            hearts[health].SetActive(false);
            b.a.anim.SetTrigger("hurt");
            b.canAttack = false;
            b.timer = b.hitstun;
            t.text = health.ToString();
            b.invis = b.hitstun * 3;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
