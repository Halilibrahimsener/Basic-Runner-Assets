using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float fireRate;
    private float timeBetweenTwoBullet;


    void Start()
    {

    }


    void Update()
    {


    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Door"))
        {
            Destroy(gameObject);
        }

    }
}
