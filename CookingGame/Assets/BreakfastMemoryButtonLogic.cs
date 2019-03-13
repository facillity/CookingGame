using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakfastMemoryButtonLogic : MonoBehaviour
{
    public void addSausage()
    {
        BreakfastMemoryGameLogic.addLeft();
    }

    public void addEgg()
    {
        BreakfastMemoryGameLogic.addRight();
    }
}
