using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableFocusOnPointerLeave : MonoBehaviour, IPointerExitHandler
{
    public void OnPointerExit(PointerEventData eventData)
    {
        // Отмена фокуса при выходе указателя мыши за пределы кнопки
        EventSystem.current.SetSelectedGameObject(null);
    }
}