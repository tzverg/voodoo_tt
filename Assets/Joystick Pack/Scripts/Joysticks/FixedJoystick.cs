using UnityEngine;
using UnityEngine.EventSystems;

public class FixedJoystick : Joystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        PlayerController.mouseButtonDown = true;
        //Debug.Log("mouseButtonDown: " + PlayerController.mouseButtonDown);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);

        PlayerController.mouseButtonDown = false;
        //Debug.Log("mouseButtonDown: " + PlayerController.mouseButtonDown);
    }
}