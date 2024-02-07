using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "New Gun Setting", order = 3)]
public class GunSettings : ScriptableObject
{
    [Header("Gun General Settings")]
    [SerializeField] int GunID;
    [SerializeField] float FireRate;
    [SerializeField] float Damage;
    [SerializeField] GameObject BulletPrefab;

    public int GetGunID() { return GunID; }
    public float GetFireRate() { return FireRate; }
    public float GetDamage() { return Damage; }
    public GameObject GetBulletPrefab() { return BulletPrefab; }

}
