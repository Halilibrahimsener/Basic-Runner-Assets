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
        EventManager.current.OnDeleteCurrentLevel += OnObstacleReturn;
    }
    private void OnEnable()
    {
        _health = _obstacleSettings.GetHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _closingSpeed = _obstacleSettings.GetClosingSpeed();
            _playersPushBackDistance = _obstacleSettings.GetPlayersPushBackDistance();
            _triggerDelay = _obstacleSettings.GetTriggerDelay();

            _health -= 1;
            if (_health == 0)
            {
                float closingSpeed = _closingSpeed * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 2, 1 / closingSpeed);
            }

            other.transform.DOMoveZ(other.transform.position.z - _playersPushBackDistance, 1f);
            _collider.isTrigger = false;
            Invoke("isTriggerOpener", _triggerDelay);
        }
    }

    private void isTriggerOpener()
    {
        _collider.isTrigger = true;
    }

    private void OnObstacleReturn()
    {
        transform.DOKill(false);
        PoolController.Return(name, gameObject);
    }
}
