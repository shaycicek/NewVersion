using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
   
    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        base.HandleInput(magnitude, normalised, radius, cam);
        if(Direction.magnitude<=0)
        {
            background.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            background.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, Direction));
        }
    }
}