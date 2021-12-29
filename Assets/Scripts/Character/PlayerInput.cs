using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<Vector2> OnMousePosChanged;
    public UnityEvent<Enums.InputState> OnMovementChanged;

    private Vector2 MousePos;

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 NewMousePos = new Vector2(worldPosition.x, worldPosition.y);
        
        if (MousePos == null || NewMousePos != MousePos)
        {
            MousePos = NewMousePos;
            OnMousePosChanged.Invoke(MousePos);
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnMovementChanged.Invoke(Enums.InputState.Down);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnMovementChanged.Invoke(Enums.InputState.Up);
        }

    }
}
