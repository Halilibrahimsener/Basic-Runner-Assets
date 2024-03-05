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
    public static int GunNumber = 0;
    [SerializeField] float _fireRate;
    [SerializeField] float _startingFireRange = 10;
    private float _fireRange;
    [SerializeField] float _damage;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Material _gunMaterial;

    public int GetGunNumber() { return GunNumber; }
    public float GetFireRate() { return _fireRate; }
    public float GetStartingFireRange() { return _startingFireRange; }
    public float GetFireRange() { return _fireRange; }
    public void SetFireRange(float newFireRange) { _fireRange = newFireRange; }
    public float GetDamage() { return _damage; }
    public GameObject GetBulletPrefab() { return _bulletPrefab; }
    public Material GetGunMaterial() { return _gunMaterial; }

}
