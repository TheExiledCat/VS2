using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;

    public int kills;
    void Awake()
    {

        if (GM == null)


            GM = this;


        else if (GM != this)

            
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
    }
    }
