using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
    public GameObject kitchen;
    public GameObject settings;
    public Button cheats;
    public Text text;
    // Start is called before the first frame update
    public void onBack(){
        kitchen.SetActive(true);
        settings.SetActive(false);
        this.gameObject.SetActive(false);
        cheats.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

}
