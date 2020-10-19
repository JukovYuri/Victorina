using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class HoverBtn : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Color32 HoverColor = new Color32(5, 47, 67, 255);
    Color32 NormalColor;
    Button btn;


    void Start()
    {
        btn = GetComponent<Button>();
        NormalColor = btn.image.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (btn.interactable)
        { 
            btn.image.color = HoverColor;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            btn.image.color = NormalColor;
        }
    }
}
