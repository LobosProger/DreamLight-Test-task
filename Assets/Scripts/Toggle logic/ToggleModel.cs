using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleModel : MonoBehaviour
{
    public Action<bool> OnSwitchedToDescendingOrder;

    private bool isSelectedDescendingOrder = false;

    public void SwitchStateOfDescendingOrder(bool state)
    {
        if (isSelectedDescendingOrder != state)
        {
            OnSwitchedToDescendingOrder?.Invoke(state);
		}

        isSelectedDescendingOrder = state;
    }

    public bool IsSelectedDescendingOrder()
    {
        return isSelectedDescendingOrder;
    }
}
