using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonScript : MonoBehaviour
{
    public GameObject kitchen;
    public GameObject settings;
    // Start is called before the first frame update
    public void onBack(){
        kitchen.SetActive(true);
        settings.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
