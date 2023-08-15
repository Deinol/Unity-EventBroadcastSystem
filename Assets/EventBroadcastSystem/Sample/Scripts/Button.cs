using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventBroadcastSystem;

public class Button : MonoBehaviour
{
    public EventBroadcast OnButtonPressed;
    public Color color = Color.white;

    private void OnMouseDown()
    {
        OnButtonPressed.BroadcastEvent(this, color); //Just raise the event for the broadcast, sending this component as broadcaster and the color we want to broadcast
    }
}
