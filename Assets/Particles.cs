using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField]
    GameObject punch, ring, spark, wave, blood;

    void Start()
    {
        wave= (GameObject)Resources.Load("particles/Wave");
        punch = (GameObject)Resources.Load("particles/punch");
        spark = (GameObject)Resources.Load("particles/Spark");
        ring = (GameObject)Resources.Load("particles/ring");
        blood= (GameObject)Resources.Load("particles/Blood");
    }
    public void hit(Vector3 pos,bool right,int hp)
    {
        if (hp == 1)
        {
            ParticleSystem.ShapeModule s;

            GameObject p = Instantiate(blood, pos,blood.transform.rotation);
            s = p.GetComponent<ParticleSystem>().shape;

            if (right)
            {
                s.rotation += Vector3.up * 90;
             

            }
            Destroy(p, 2);
        }
        if (GameManager.GM.kills %10==0&&hp==1) Destroy(Instantiate(spark, pos, Quaternion.identity), 2);
        if (GameManager.GM.kills % 30 == 0 && hp == 1) Destroy(Instantiate(wave, new Vector3(Camera.main.transform.position.x,3.9f,0), Quaternion.identity), 1);
        GameObject part = Instantiate(punch, pos, Quaternion.identity);
        Destroy(Instantiate(ring, pos, Quaternion.identity),0.2f);
        if (!right)
            part.transform.localScale = new Vector3(-part.transform.localScale.x, part.transform.localScale.y, transform.localScale.z);

        Destroy(part, 2f);
    }
}
