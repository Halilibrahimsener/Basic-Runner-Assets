using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunButtonSetting", menuName = "New GunButton Setting", order = 6)]
public class GunButtonSettings : ScriptableObject
{
    [SerializeField] Material _gunButtonMaterial;
    [SerializeField] float _gunButtonClosingSpeed;
    [SerializeField] GunBehaviour[] _gunPrefabArray;    //must be sorted according to _gunType enum


    public Material GetGunButtonMaterial() { return _gunButtonMaterial; }
    public float GetGunButtonClosingSpeed() { return _gunButtonClosingSpeed; }
    public GunBehaviour[] GetGunPrefabArray() { return _gunPrefabArray; }

}
