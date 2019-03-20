using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen_Logic : MonoBehaviour
{
    public SpriteRenderer ob1;
    public Sprite s0;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Text Congrats;
    public Button btn;
    public float timer;
    public int count;
    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;
    public GameObject L5;
    public GameObject L6;


    // Update is called once per frame
    void Update()
    {
        if (count % 15 == 0){
            List<int> arr = new List<int>();
            for (int idx = 0; idx < 6; idx++){
                arr.Add(Random.Range(0, 2));
            }
            for (int idx = 0; idx < 6; idx++){
                if (arr[idx] == 0){
                    if (idx == 0){
                        L1.SetActive(true);
                    }
                    if (idx == 1){
                        L2.SetActive(true);
                    }
                    if (idx == 2){
                        L3.SetActive(true);
                    }
                    if (idx == 3){
                        L4.SetActive(true);
                    }
                    if (idx == 4){
                        L5.SetActive(true);
                    }
                    if (idx == 5){
                        L6.SetActive(true);
                    }
                } else {
                    if (idx == 0){
                        L1.SetActive(false);
                    }
                    if (idx == 1){
                        L2.SetActive(false);
                    }
                    if (idx == 2){
                        L3.SetActive(false);
                    }
                    if (idx == 3){
                        L4.SetActive(false);
                    }
                    if (idx == 4){
                        L5.SetActive(false);
                    }
                    if (idx == 5){
                        L6.SetActive(false);
                    } 
                }
            }
        }
        timer += Time.deltaTime;
        count ++;

        if (GameObject.Find("Progress").GetComponent<ProgressScript>().dish == 0){
            ob1.sprite = s0;
        }
        else if (GameObject.Find("Progress").GetComponent<ProgressScript>().dish == 1){
            ob1.sprite = s1;
        }
        else if (GameObject.Find("Progress").GetComponent<ProgressScript>().dish == 2){
            ob1.sprite = s2;
        }
        else if (GameObject.Find("Progress").GetComponent<ProgressScript>().dish == 3){
            ob1.sprite = s3;
        }

        if (timer > 3){
            btn.gameObject.SetActive(true);
            Congrats.text = "Congratulations! You finished!";
        }
        
    }

    public void ResetToMain(){
        // mark that we completed this dish.
        GameObject.Find("Progress").GetComponent<ProgressScript>().stage = -1;
        GameObject.Find("Progress").GetComponent<ProgressScript>().dish = -1;
        SceneManager.LoadScene("_MainMenu");
    }
}
