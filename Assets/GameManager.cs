using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public GameObject enemy;
    public int kills;
     GameObject bg;
    GameObject bg1;
    public GameObject pref;
    GameObject p;
    void Awake()
    {

        if (GM == null)


            GM = this;


        else if (GM != this)

            
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        bg = pref;
        bg1 = bg;
        p = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("intro");
        SpawnEnemy((int)Random.Range(1,3));
    }
    IEnumerator intro()
    {
        p.GetComponent<Battle>().canAttack = false;
        yield return new WaitForSeconds(4);
        p.GetComponent<Battle>().canAttack = true;
        yield return null;
    }
    void SpawnEnemy(int hp)
    {
        int xOff = ((int)Random.Range(0, 2) == 0 ? -1 : 1);
        GameObject e = Instantiate(enemy, new Vector3(20 * xOff, 0, 0), Quaternion.identity);
        e.GetComponent<Enemy>().health = hp;
        //SpawnEnemy((int)Random.Range(1, 3));
    }
    void Update()
    {
        if (p.transform.position.x < bg.transform.position.x-3)
        {
          bg=  Instantiate(pref, new Vector3(bg.transform.position.x-40, bg.transform.position.y, 0),Quaternion.identity);
        }
        if (p.transform.position.x > bg1.transform.position.x + 3)
        {
            bg1 = Instantiate(pref, new Vector3(bg1.transform.position.x + 40, bg1.transform.position.y, 0), Quaternion.identity);
        }
    }
    }
