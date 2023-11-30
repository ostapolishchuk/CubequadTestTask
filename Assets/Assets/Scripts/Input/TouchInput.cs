using UnityEngine;
using UnityEngine.EventSystems;

public class TouchInput : InputEvents, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private float _sensivity = 0.1f;

    private Vector2 _startPosition;
    private Vector2 _currentPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        _startPosition = _currentPosition = eventData.position;
        TapInvoke(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TapInvoke(false);
    }

    public new void OnDrag(PointerEventData eventData)
    {
        _currentPosition = eventData.position;
        Vector2 drag = (_currentPosition - _startPosition) * _sensivity;
        DragInvoke(drag);
    }
}