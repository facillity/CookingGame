using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageBatter : MonoBehaviour
{
    public static bool done, stir;
    public static bool flour, cornstarch, salt, egg, water;
    public GameObject mix;
    public Text text;
    private float time;
    private bool displayText;
    // Start is called before the first frame update
    void Start()
    {
        flour = false;
        cornstarch = false;
        salt = false;
        egg = false;
        stir = false;
        water = false;
        time = 0;
        displayText = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText)
        {
            time += Time.deltaTime;
        }
        if (time > 4)
        {
            time = 0;
            displayText = false;
            text.text = "";
        }
        if (flour && cornstarch && salt && egg && water)
        {
          
            done = true;
            text.text = "Whisk!";
            displayText = true;
            
        }
        if (MixBatter.doneMixing)
        {
            text.text = "This batter looks great!";
            // move on to next game
        }
    }
}
