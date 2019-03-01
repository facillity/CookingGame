using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartSounds : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //aud.PlayOneShot(clip);
    }
}
