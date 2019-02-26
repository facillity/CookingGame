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

        SceneManager.LoadScene(sceneNum);
    }

    void OnMouseExit(){
        if (sceneNum == -1){
            gameObject.GetComponent<SpriteRenderer>().sprite = reload;
        }
    }
}
