using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Door Setting", menuName = "New Door Setting", order = 2)]
public class DoorSettings : ScriptableObject
{
    [Header("Door Material Colors")]
    [SerializeField] Material NegativeValueMaterial;
    [SerializeField] Material PositiveValueMaterial;

    [Header("Door Settings")]
    [SerializeField] float ClosingSpeed;


    public Material GetNegativeValueMaterials()
    {
        return NegativeValueMaterial;
    }
    public Material GetPositiveValueMaterials()
    {
        return PositiveValueMaterial;
    }

    public float GetClosingSpeed()
    {
        return ClosingSpeed;
    }
}
