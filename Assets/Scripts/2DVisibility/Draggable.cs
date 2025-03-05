using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 dragPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        this.transform.position = new Vector3(dragPosition.x, dragPosition.y, this.transform.position.z);
    }
}
