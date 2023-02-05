using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventCenter
{
    public static event Action<Color> pickerClickedAction;
    public static void PickerClickedAction(Color color) => pickerClickedAction?.Invoke(color);
}
