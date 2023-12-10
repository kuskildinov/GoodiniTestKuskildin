using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPanel : MonoBehaviour
{
    private Vector2 _touchStartPosition;
    private Vector2 _touchEndPosition;

    private bool _panelTouched;
    public float TouchDelta { get; set; }
  
    public void OnPointerDown()
    {
        GetStartTouchPosition();
    }

    public void OnPointerDrag()
    {
        GetDeltaTouchPosition();        
    }

    public void OnPointeUp()
    {
        GetEndTouchPosition();
    }

    private void GetStartTouchPosition()
    {
        _panelTouched = true;
        _touchStartPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
    private void GetDeltaTouchPosition()
    {
        Vector2 currentTouchPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        TouchDelta = Vector2.Distance(_touchStartPosition, currentTouchPosition);
        if (_touchStartPosition.x > currentTouchPosition.x)
        {
            TouchDelta *= -1;
        }
        else
            TouchDelta *= 1;
        
    }
    private void GetEndTouchPosition()
    {
        _panelTouched = false;
        TouchDelta = 0;
        _touchEndPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
}
