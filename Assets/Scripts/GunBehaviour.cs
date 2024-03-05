using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GunType
{
    Gun1,   //0
    Gun2,   //1
    Gun3    //2
};

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] GunSettings _gunSetting;
    GameObject _bulletPrefab;
    [SerializeField] float _distanceBetweenGuns = 0.15f;
    float _timer = 0;
    float _fireRate;
    float _fireRange;
    int gunID;

    void Start()
    {
        _fireRate = _gunSetting.GetFireRate() + Registry.AdditionalFireRate;
        _bulletPrefab = _gunSetting.GetBulletPrefab();

        _gunSetting.SetFireRange(_gunSetting.GetStartingFireRange());
        _fireRange = _gunSetting.GetFireRange();
        EventManager.current.OnUpdateFireRangeOrRate += UpdateFireRangeOrRate;

        GunSettings.GunNumber++;
        gunID = GunSettings.GunNumber;
        EventManager.current.OnGunPositioningEvent += GunPositioning;

    }
    private void Update()
    {
        if (TryToFire())
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }

    private bool TryToFire()
    {
        float fireDuration = 1f / (5 * _fireRate * Time.deltaTime);
        if (_timer > fireDuration)
        {
            _timer = 0;
            return true;
        }
        else
        {
            _timer += Time.deltaTime;
            return false;
        }
    }

    private void GunPositioning(Vector3 PlayerPosition)
    {
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

