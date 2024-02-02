using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Door Setting", menuName = "New Door Setting", order = 2)]
public class DoorSettings : ScriptableObject
{
    [Header("Door Material Colors")]
    [SerializeField] Color NegativeValueColor;
    [SerializeField] Color PositiveValueColor;

    [Header("Door Settings")]
    [SerializeField] float ClosingSpeed;



    public Color32 GetNegativeValueColors()
    {
        return NegativeValueColor;
    }
    public Color32 GetPositiveValueColors()
    {
        return PositiveValueColor;
    }

    public float GetClosingSpeed()
    {
        return ClosingSpeed;
    }
}
