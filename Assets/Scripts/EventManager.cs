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
    }
    #endregion Singleton




    public event Action<float> OnInputEvent;

    public void OnInputEventInvoke(float _xDifference)
    {
        OnInputEvent?.Invoke(_xDifference);
    }
}

