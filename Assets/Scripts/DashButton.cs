using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DashButton : MonoBehaviour , IUpdateSelectedHandler, IDeselectHandler, IPointerDownHandler, IPointerUpHandler 
{
    public FixedJoystick dashAim;
    float timer = 0;
    bool isPressed;
    PointerEventData pointerDownData;
    PointerEventData pointerUpData;
    public void OnUpdateSelected(BaseEventData eventData)
    {        
        if (isPressed)
        {
            timer += Time.deltaTime;
            if(timer>0.15f)
            {
                dashAim.gameObject.SetActive(true);
                if(timer>0.20f)
                {
                    dashAim.OnPointerDown(pointerDownData);
                }                                
            }
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        dashAim.OnPointerUp(pointerUpData);
    }

    public void OnPointerDown(PointerEventData data)
    {
        isPressed = true;
        pointerDownData = data;
    }
    public void OnPointerUp(PointerEventData data)
    {
        isPressed = false;
        dashAim.gameObject.SetActive(false);
        timer = 0;
    }
}
