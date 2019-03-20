using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SausageCuttingSoundScript : MonoBehaviour
{

    public AudioClip successSound, errorSound;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySoundEffect(string status)
    {
        switch(status)
        {
            case "success":
                audioSrc.PlayOneShot(successSound);
                break;
            case "error":
                audioSrc.PlayOneShot(errorSound);
                break;
        }
    }
}
