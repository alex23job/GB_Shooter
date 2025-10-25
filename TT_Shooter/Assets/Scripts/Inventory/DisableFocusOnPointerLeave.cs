using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisableFocusOnPointerLeave : MonoBehaviour, IPointerExitHandler
{
    public void OnPointerExit(PointerEventData eventData)
    {
        // ������ ������ ��� ������ ��������� ���� �� ������� ������
        EventSystem.current.SetSelectedGameObject(null);
    }
}