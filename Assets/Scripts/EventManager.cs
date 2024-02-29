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
    public event Action<Vector3> OnGunPositioningEvent;
    public void OnGunPositioningEventInvoke(Vector3 PlayerPosition)
    {
        OnGunPositioningEvent?.Invoke(PlayerPosition);
    }

    public event Action<DoorType, float> OnUpdateFireRangeOrRate;
    public void OnUpdateFireRangeOrRateInvoke(DoorType doorType, float doorValue)
    {
        OnUpdateFireRangeOrRate?.Invoke(doorType, doorValue);
    }

    public event Action<int> OnChangeMoneyCounterText;
    public void OnChangeMoneyCounterTextInvoke(int totalMoney)
    {
        OnChangeMoneyCounterText?.Invoke(totalMoney);
    }

    public event Action<int> OnChangeLevelCounterText;
    public void OnChangeLevelCounterTextInvoke(int levelNo)
    {
        OnChangeLevelCounterText?.Invoke(levelNo);
    }
}

