using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleModel : MonoBehaviour
{
    private bool isSelectedDescendingOrder = false;

    public void SwitchStateOfDescendingOrder(bool state)
    {
        isSelectedDescendingOrder = state;
    }

    public bool IsSelectedDescendingOrder()
    {
        return isSelectedDescendingOrder;
    }
}
