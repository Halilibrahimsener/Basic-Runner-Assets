using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] ObstacleSettings obstacleSettings;
    [SerializeField] Collider _collider;
    float Health;
    float ClosingSpeed;
    float PlayersPushBackDistance;
    float TriggerDelay;

    void Start()
    {
        Health = obstacleSettings.GetHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ClosingSpeed = obstacleSettings.GetClosingSpeed();                          //I defined these here so that we can change the settings and see the 
            PlayersPushBackDistance = obstacleSettings.GetPlayersPushBackDistance();    //changes at the same time while the game is playing.
            TriggerDelay = obstacleSettings.GetTriggerDelay();

            Health -= 1;
            if (Health == 0)
            {
                float _closingSpeed = ClosingSpeed * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 2, 1 / _closingSpeed);
            }

            other.transform.DOMoveZ(other.transform.position.z - PlayersPushBackDistance, 1f);
            _collider.isTrigger = false;
            Invoke("isTriggerOpener", TriggerDelay);  //I used this method just to implement 1second delay. 0.2seconds was not long enough
        }
    }

    private void isTriggerOpener()
    {
        _collider.isTrigger = true;
    }
}
