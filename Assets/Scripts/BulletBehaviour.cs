using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Vector3 _startPosition;
    [SerializeField] GunSettings _gunSetting;

    float _fireRange;

    void Start()
    {
        _startPosition = transform.position;
        _fireRange = _gunSetting.GetFireRange();
    }

    void FixedUpdate()
    {
        if (transform.position.z - _startPosition.z < _fireRange)
        {
            transform.Translate(0, 0, 0.5f);
        }
        else { Destroy(gameObject); }
    }

    public float GetBulletDamage()
    {
        return _gunSetting.GetDamage();
    }

}
