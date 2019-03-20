﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressScript : MonoBehaviour
{
    public int stage;
    public int dish;
    public static bool cheats;

    void Start(){
        cheats = false;
        //stage = 0;
    }

    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("progress");
        if (objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}