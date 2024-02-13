using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] ObstacleSettings _obstacleSettings;
    [SerializeField] Collider _collider;
    float _health;
    float _closingSpeed;
    float _playersPushBackDistance;
    float _triggerDelay;

    void Start()
    {
        _health = _obstacleSettings.GetHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _closingSpeed = _obstacleSettings.GetClosingSpeed();                          //I defined these here so that we can change the settings and see the 
            _playersPushBackDistance = _obstacleSettings.GetPlayersPushBackDistance();    //changes at the same time while the game is playing.
            _triggerDelay = _obstacleSettings.GetTriggerDelay();

            _health -= 1;
            if (_health == 0)
            {
                float closingSpeed = _closingSpeed * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 2, 1 / closingSpeed);
            }

            other.transform.DOMoveZ(other.transform.position.z - _playersPushBackDistance, 1f);
            _collider.isTrigger = false;
            Invoke("isTriggerOpener", _triggerDelay);  //I used this method just to implement 1second delay. 0.2seconds was not long enough
        }
    }

    private void isTriggerOpener()
    {
        _collider.isTrigger = true;
    }
}
