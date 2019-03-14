using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class cheats : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "CHEATS: ";
        if (ProgressScript.cheats){
            text.text = text.text + "ON";
        } else {
            text.text = text.text + "OFF";
        }
    }

    public void toggleCheats(){
        ProgressScript.cheats = !ProgressScript.cheats;
        if (ProgressScript.cheats){
            Debug.Log("Cheats activated.");
        } else {
            Debug.Log("Cheats deactivated.");
        }
    }
}
