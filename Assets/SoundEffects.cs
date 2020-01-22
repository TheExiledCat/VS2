using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{

   public  AudioClip[] punches;
    // Start is called before the first frame update
  

   public void play()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(punches[Random.Range(0, 2)]);
    }
    public void miss()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(punches[(int)Random.Range(4, 6)]);
    }
}
