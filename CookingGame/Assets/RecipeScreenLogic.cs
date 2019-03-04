using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecipeScreenLogic : MonoBehaviour
{
    float timer = 0;
    public GameObject cm1;
    public GameObject cm2;
    public GameObject cm3;
    public GameObject cm4;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
            // dont load any checkmarks
        } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
            cm1.SetActive(true);
        } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
            cm1.SetActive(true);
            cm2.SetActive(true);
        } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 3){
            cm1.SetActive(true);
            cm2.SetActive(true);
            cm3.SetActive(true);
        } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 4){
            cm1.SetActive(true);
            cm2.SetActive(true);
            cm3.SetActive(true);
            cm4.SetActive(true);
        }
        timer += Time.deltaTime;
        //Debug.Log(timer);

        if (timer > 1.5f){
            text.text = "Loading..";
        }
        if (timer > 2.5f){
            text.text = "Loading...";
        }
        if (timer > 3.5f){
            text.text = "Loading.";
        }
        if (timer > 4.5f){
            text.text = "Loading..";
        }

        if (timer > 5f){
            if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 0){
                //MiniGameDirectionsLogic.loadGameSalmonNigiri1();
                SceneManager.LoadScene("MiniGameDirections");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 1){
                SceneManager.LoadScene("MiniGameDirections");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 2){
                SceneManager.LoadScene("MiniGameDirections");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 3){
                SceneManager.LoadScene("_MainMenu");
            } else if (GameObject.Find("Progress").GetComponent<ProgressScript>().stage == 4){
                SceneManager.LoadScene("minigame1");
            }
            
        }
    }
}
