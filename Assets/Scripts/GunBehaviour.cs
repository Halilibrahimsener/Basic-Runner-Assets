using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] GunSettings _gunSetting;
    GameObject _bulletPrefab;
    [SerializeField] float _distanceBetweenGuns = 0.15f;
    float _timer = 0;
    float _fireRate;
    float _fireRange;

    void Start()
    {
        _fireRate = _gunSetting.GetFireRate();
        _bulletPrefab = _gunSetting.GetBulletPrefab();

        _gunSetting.SetFireRange(_gunSetting.GetStartingFireRange());
        _fireRange = _gunSetting.GetFireRange();


        EventManager.current.OnFireEvent += InstantiateBullet;
        EventManager.current.OnUpdateFireRangeOrRate += UpdateFireRangeOrRate;
    }

    void Update()
    {

    }

    private void InstantiateBullet(Vector3 PlayerPosition)
    {
        Vector3 gunPosition = GunPositioning(PlayerPosition);
        float fireDuration = 1f / (5 * _fireRate * Time.deltaTime);
        if (_timer > fireDuration)
        {
            _timer = 0;
            Instantiate(_bulletPrefab, gunPosition, Quaternion.identity);
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private Vector3 GunPositioning(Vector3 PlayerPosition)
    {
        int gunID = _gunSetting.GetGunID(); //1,2,3,4,...
        float xPosition = gunID * _distanceBetweenGuns;
        Vector3 gunPosition;
        if (gunID % 2 == 0)
        {
            xPosition -= _distanceBetweenGuns;
            gunPosition = Vector3.right * xPosition + PlayerPosition;
        }
        else
        {
            gunPosition = Vector3.left * xPosition + PlayerPosition;
        }

        transform.position = gunPosition;

        return gunPosition;
    }

    private void UpdateFireRangeOrRate(DoorType doorType, float doorValue)
    {
        if (doorType == DoorType.FireRange)
        {
            _fireRange += doorValue;
            _gunSetting.SetFireRange(_fireRange);
        }
        else { _fireRate += doorValue; }
    }
}

