using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{

    public static UnityEvent OnTouchDetect = new UnityEvent();
    public static UnityEvent OnDragLeftDetect = new UnityEvent();
    public static UnityEvent OnDragRightDetect = new UnityEvent();

    private Vector2 touchStart;

    private float deadZone = 50f;

    void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.touchCount > 0)
        {
            Touch Touch0 = Input.GetTouch(0);
            if (Touch0.phase == TouchPhase.Began)
                touchStart = Touch0.position;
            if (Touch0.phase == TouchPhase.Ended)
            {
                Vector2 TouchVector = Touch0.position - touchStart;
                if (TouchVector.magnitude < deadZone)
                    OnTouchDetect?.Invoke();
                else
                {
                    if (TouchVector.x > 0)
                        OnDragRightDetect?.Invoke();
                    else OnDragLeftDetect?.Invoke();
                }
            }
        }
    }
}
