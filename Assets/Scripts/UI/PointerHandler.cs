using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerHandler : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{

    public event Action<PointerEventData> Enter;
    public event Action<PointerEventData> Exit;
    public event Action<PointerEventData> Click;

    public void OnPointerClick(PointerEventData eventData)
    {
        Click?.Invoke(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Enter?.Invoke(eventData );
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Exit?.Invoke(eventData );
    }
}
