using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EventManager : MonoBehaviour
{
    #region Singleton
    public static EventManager current;
    private void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
    }
    #endregion Singleton




    public event Action<float> OnInputEvent;

    public void OnInputEventInvoke(float xDifference)
    {
        OnInputEvent?.Invoke(xDifference);
    }

    public event Action<Vector3> OnFireEvent;
    public void OnFireEventInvoke(Vector3 PlayerPosition)
    {
        OnFireEvent?.Invoke(PlayerPosition);
    }
}

