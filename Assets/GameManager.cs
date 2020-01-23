using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager GM = null;
    public GameObject enemy;
    public int kills;
     GameObject bg;
    GameObject bg1;
    public GameObject pref;
    GameObject p;
    public AudioClip start;
    float chance=3;
    int timer;
    public GameObject missE;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t;
    int hits;
    void Awake()
    {

        if (GM == null)


            GM = this;


        else if (GM != this)

            
            Destroy(gameObject);


        DontDestroyOnLoad(gameObject);
    }
    public void combo()
    {
        hits++;
        t1.text = hits.ToString("000");
    }
    void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(start);
        
        bg = pref;
        bg1 = bg;
        p = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine("intro");
     
    }
    public IEnumerator miss()
    {
        int frames=20;
        missE.SetActive(true);
        missE.transform.localScale = Vector3.zero;
        for (int i = 0; i < frames; i++)
        {
            missE.transform.localScale += new Vector3(1, 1, 1) / frames;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.75f);
        missE.SetActive(false);
        yield return null;
    }
    IEnumerator intro()
    {
        p.GetComponent<Battle>().enabled = false;
        yield return new WaitForSeconds(4);
        p.GetComponent<Battle>().enabled = true;
        Camera.main.GetComponent<AudioSource>().Play();
        StartCoroutine(SpawnEnemy((int)Random.Range(1,4)));
        
        yield return null;
    }
    IEnumerator SpawnEnemy(int hp)
    {
        Color c=Color.green;
        int xOff = ((int)Random.Range(0, 2) == 0 ? -1 : 1);
        GameObject e = Instantiate(enemy, new Vector3(p.transform.position.x+20 * xOff, 0, 0), Quaternion.identity);
        e.GetComponent<Enemy>().health = hp;
        switch (hp)
        {
            case 1: 
                    c = Color.grey;
                    break;
            case 2:
                c = Color.red;
                break;
            case 3:
                c = Color.green;
                break;
                        
        }
        for (int i = 0; i < 11; i++)
        {
            if (e.transform.GetChild(0).GetChild(i).GetComponent<SpriteRenderer>())
                e.transform.GetChild(0).GetChild(i).GetComponent<SpriteRenderer>().color = c;
        }
        yield return new WaitForSeconds(Random.Range(chance, 3));
        StartCoroutine(SpawnEnemy((int)Random.Range(1, 4)));
        yield return null;
    }
    void Update()
    {
        t.text = kills.ToString();
        if (p.transform.position.x < bg.transform.position.x-3)
        {
          bg=  Instantiate(pref, new Vector3(bg.transform.position.x-40, bg.transform.position.y, 0),Quaternion.identity);
        }
        if (p.transform.position.x > bg1.transform.position.x + 3)
        {
            bg1 = Instantiate(pref, new Vector3(bg1.transform.position.x + 40, bg1.transform.position.y, 0), Quaternion.identity);
        }
        if (timer > 0&&timer>1f)
        {
            timer--;
        }
        else
        {
            timer = 60 * 6;
            
            chance-=0.5f;
        }
    }

}
