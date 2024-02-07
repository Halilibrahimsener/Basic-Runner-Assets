using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    [SerializeField] GunSettings gunSetting;
    [SerializeField] float distanceBetweenGuns = 0.15f;
    float timer = 0;
    float fireDuration;
    float fireRate;

    void Start()
    {
        fireRate = gunSetting.GetFireRate();
        fireDuration = 1f / (fireRate * Time.deltaTime);
        EventManager.current.OnFireEvent += InstantiateBullet;
    }


    void Update()
    {

    }

    private void InstantiateBullet(Vector3 PlayerPosition)
    {
        Vector3 gunPosition = GunPositioning(PlayerPosition);

        //Debug.Log("GunBehaviour: x: " + gunPosition.x + ",y: " + gunPosition.y + ",z: " + gunPosition.z);
        //Debug.Log("GunBehaviour2: x: " + transform.position.x + ",y: " + transform.position.y + ",z: " + transform.position.z);

        if (timer > fireDuration)
        {
            timer = 0;
            GameObject bulletPrefab = gunSetting.GetBulletPrefab();
            Instantiate(bulletPrefab, gunPosition, Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private Vector3 GunPositioning(Vector3 PlayerPosition)
    {
        int gunID = gunSetting.GetGunID(); //1,2,3,4,...
        float xPosition = gunID * distanceBetweenGuns;
        Vector3 gunPosition;
        if (gunID % 2 == 0)
        {
            xPosition -= distanceBetweenGuns;
            gunPosition = Vector3.right * xPosition + PlayerPosition;
        }
        else
        {
            gunPosition = Vector3.left * xPosition + PlayerPosition;
        }

        //transform.position = gunPosition;

        return gunPosition;
    }
}
