using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenScript : MonoBehaviour
{
    public GameObject kitchen_cat;
    public GameObject kitchen_cereal1;
    public GameObject kitchen_cereal2;
    public GameObject kitchen_egg;
    public GameObject kitchen_hi;
    public GameObject kitchen_pepper;
    public GameObject kitchen_pie;
    public GameObject kitchen_postcard;
    public GameObject kitchen_pot;
    public GameObject kitchen_ramen;
    public GameObject kitchen_salt;
    public GameObject kitchen_towel;
    public GameObject[] kitchen_objects = new GameObject[12];
    

    // Start is called before the first frame update
    void Start()
    {
        kitchen_objects[0] = kitchen_cat;
        kitchen_objects[1] = kitchen_cereal1;
        kitchen_objects[2] = kitchen_cereal2;
        kitchen_objects[3] = kitchen_egg;
        kitchen_objects[4] = kitchen_hi;
        kitchen_objects[5] = kitchen_pepper;
        kitchen_objects[6] = kitchen_pie;
        kitchen_objects[7] = kitchen_postcard;
        kitchen_objects[8] = kitchen_pot;
        kitchen_objects[9] = kitchen_ramen;
        kitchen_objects[10] = kitchen_salt;
        kitchen_objects[11] = kitchen_towel;

        randomizeObjects();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomizeObjects(){
        for (int i = 0; i < kitchen_objects.Length; i++){
            int x = Random.Range(0, 2);
            if (x > 0){
                kitchen_objects[i].SetActive(true);
            } else {
                kitchen_objects[i].SetActive(false);
            }
        }

    }
}
