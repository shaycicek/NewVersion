using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackButton : MonoBehaviour , IUpdateSelectedHandler, IDeselectHandler , IPointerDownHandler , IPointerUpHandler
{
    bool isPressed;
    public void OnUpdateSelected(BaseEventData eventData)
    {
        if(isPressed)
        {
            GameManager.instance.player.GetComponent<PlayerController>().Aim();
        }
        
    }

    public void OnDeselect(BaseEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
    }
}
