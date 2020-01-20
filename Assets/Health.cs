using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    // Start is called before the first frame update

    public GameObject[] hearts;
    void Start()
    {
         
    }

    public void TakeDamage()
    {
        health--;
        hearts[health].SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
