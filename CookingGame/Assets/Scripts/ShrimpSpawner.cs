using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrimpSpawner : MonoBehaviour
{
    public Text ShrimpFinishedScore;
    public float SpawnMaxX;
    public float SpawnMaxY;
    public float SpawnMinX;
    public float SpawnMinY;
    public GameObject shrimp;
    int NumShrimpFinished;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShrimpFinishedScore.text = NumShrimpFinished.ToString();
    }


    void InstantiateShrimp()
    {
        float xPos = Random.Range(SpawnMinX, SpawnMaxX);
        float yPos = Random.Range(SpawnMinY, SpawnMaxY);
        Instantiate(shrimp, new Vector3(xPos, yPos, 0), Quaternion.identity);
    }
}
