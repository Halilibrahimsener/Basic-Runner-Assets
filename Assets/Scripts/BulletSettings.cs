using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Setting", menuName = "New Bullet Setting", order = 4)]
public class BulletSettings : ScriptableObject
{
    [SerializeField] float _fireRange;

    public float GetFireRange() { return _fireRange; }
}
