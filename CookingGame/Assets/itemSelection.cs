using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class itemSelection : MonoBehaviour
{
    public int sceneNum;
    public Sprite locked;

    public Sprite reload;
    void OnMouseDown(){
        if (sceneNum == -1){
            gameObject.GetComponent<SpriteRenderer>().sprite = locked;
            return;
        }
        if (sceneNum == 4){
            GameObject.Find("Progress").GetComponent<ProgressScript>().dish = 0;
            GameObject.Find("Progress").GetComponent<ProgressScript>().stage = 0;
        } else if (sceneNum == 8){
            GameObject.Find("Progress").GetComponent<ProgressScript>().dish = 2;
            GameObject.Find("Progress").GetComponent<ProgressScript>().stage = 1;
        } else if (sceneNum == 12){
            GameObject.Find("Progress").GetComponent<ProgressScript>().dish = 1;
            GameObject.Find("Progress").GetComponent<ProgressScript>().stage = 2;
        }
        //GameObject.Find("Progress").GetComponent<ProgressScript>().stage = 0;
        SceneManager.LoadScene(sceneNum);
    }

    void OnMouseExit(){
        if (sceneNum == -1){
            gameObject.GetComponent<SpriteRenderer>().sprite = reload;
        }
    }
}
