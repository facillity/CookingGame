using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject kitchen;
    public GameObject settings;
    public Button btn_back;

    // Start is called before the first frame update
    void OnMouseDown(){
        this.GetComponent<GrowOnHover>().OnMouseExit();
        kitchen.SetActive(false);
        settings.SetActive(true);
        btn_back.gameObject.SetActive(true);
    }
}
