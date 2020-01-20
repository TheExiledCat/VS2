using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField]
    GameObject punch, ring, spark, wave, blood;

    void Start()
    {
        punch = (GameObject)Resources.Load("particles/punch");
        spark = (GameObject)Resources.Load("particles/Spark");
    }
    public void hit(Vector3 pos,bool right)
    {
        GameObject part = Instantiate(punch, pos, Quaternion.identity);

        if (!right)
            part.transform.localScale = new Vector3(-part.transform.localScale.x, part.transform.localScale.y, transform.localScale.z);

        Destroy(part, 2f);
    }
}
