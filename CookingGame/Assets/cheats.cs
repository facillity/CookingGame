using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class cheats : MonoBehaviour
{
    public Text text;
    public Text desc;
    public bool timerOn;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn){
            timer += Time.deltaTime;
        }
        
        text.text = "CHEATS: ";
        if (ProgressScript.cheats){
            text.text = text.text + "ON";
        } else {
            text.text = text.text + "OFF";
        }
        if (timer >= 3.5){
            desc.gameObject.SetActive(false);
            timerOn = false;
            timer = 0;
        }
    }

    public void toggleCheats(){
        ProgressScript.cheats = !ProgressScript.cheats;
        if (ProgressScript.cheats){
            Debug.Log("Cheats activated.");
            desc.gameObject.SetActive(true);
            timerOn = true;
        } else {
            Debug.Log("Cheats deactivated.");
            desc.gameObject.SetActive(false);
            timerOn = false;
            timer = 0;
        }
        
        
    }
}
