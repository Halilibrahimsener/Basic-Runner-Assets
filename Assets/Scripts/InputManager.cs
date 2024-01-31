using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    public static InputManager CurrentInputManager;
    private void Awake()
    {
        if (CurrentInputManager == null)
        {
            CurrentInputManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton




    private float _lastMousePositionX;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x - _lastMousePositionX != 0)
            {
                float _xDifference = Input.mousePosition.x - _lastMousePositionX;
                EventManager.current.OnInputEventInvoke(_xDifference);
                _lastMousePositionX = Input.mousePosition.x;

            }
        }
    }
}

