using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinegarGameLogicButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void addVinegar(){
        VinegarGameLogic.addLeft();
    }

    public void addRice(){
        VinegarGameLogic.addRight();
    }
}
