using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSetting", menuName = "New Player Setting", order = 0)]
public class PlayerSettings : ScriptableObject
{
    [Header("Player Movement Speed Values")]
    [SerializeField] float LateralSpeed;
    [SerializeField] float ForwardSpeed;

    public float GetLateralSpeed()
    {
        return LateralSpeed;
    }

    public float GetForwardSpeed()
    {
        return ForwardSpeed;
    }
}

