using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public GameObject enemy;
    public int kills;
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
        StartCoroutine("intro");
        SpawnEnemy((int)Random.Range(1,3));
    }
    IEnumerator intro()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Battle>().canAttack = false;
        yield return new WaitForSeconds(4);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Battle>().canAttack = true;
        yield return null;
    }
    void SpawnEnemy(int hp)
    {
        GameObject e;
        if ((int)Random.Range(0, 2) == 0)
        {
            e = Instantiate(enemy, new Vector3(-20, 0, 0), Quaternion.identity);
            e.GetComponent<Enemy>().health = hp;
        }
        else
        {
            e = Instantiate(enemy, new Vector3(20, 0, 0), Quaternion.identity);
            e.GetComponent<Enemy>().health = hp;
        }

        //SpawnEnemy((int)Random.Range(1, 3));
    }
    void Update()
    {
        
    }
    }
