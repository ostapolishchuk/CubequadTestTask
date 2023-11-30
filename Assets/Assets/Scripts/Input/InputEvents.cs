using System;
using UnityEngine;

public abstract class InputEvents : MonoBehaviour
{
    public static event Action<bool> OnTap;
    public static event Action<Vector2> OnDrag;

    protected void TapInvoke(bool isTap) => OnTap?.Invoke(isTap);

    protected void DragInvoke(Vector2 drag) =>  OnDrag?.Invoke(drag);
}