using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public int stage = 0;

    void Start(){
        stage = 0;
    }

    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("progress");
        if (objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
