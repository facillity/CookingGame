using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Text>().color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Text>().color = Color.black;
    }
}
