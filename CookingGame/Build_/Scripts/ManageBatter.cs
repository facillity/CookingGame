using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageBatter : MonoBehaviour
{
    public static bool done, stir;
    public float endTimer=0f;
    public static bool flour, cornstarch, salt, egg, water;
    public GameObject mix;
    public Text text;
    private bool cheated = false;
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
        if (ProgressScript.cheats && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)){
            Debug.Log("SKIPPED");
            cheated = true;
        }
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
        if (MixBatter.doneMixing || cheated)
        {
            text.text = "This batter looks great!";
            endTimer += Time.deltaTime;
            if (endTimer > 5f){
                GameObject.Find("Progress").GetComponent<ProgressScript>().stage++;
                cheated = false;
                SceneManager.LoadScene("ShrimpRecipe");
            }
        }
    }
}
