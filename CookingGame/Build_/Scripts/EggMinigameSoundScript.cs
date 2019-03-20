using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMinigameSoundScript : MonoBehaviour
{

    public AudioClip crackSound, openSound, errorSound;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(string sound)
    {
        switch (sound)
        {
            case "crack":
                audioSrc.PlayOneShot(crackSound);
                break;
            case "open":
                audioSrc.PlayOneShot(openSound);
                break;
            case "error":
                audioSrc.PlayOneShot(errorSound);
                break;
        }
    }
}
