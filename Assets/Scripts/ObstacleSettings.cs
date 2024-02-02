using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Obstacle Setting", menuName = "New Obstacle Setting", order = 1)]

public class ObstacleSettings : ScriptableObject
{
    [Header("Obstacle Settings")]
    [SerializeField] float Health;
    [SerializeField] float ClosingSpeed;
    [SerializeField] float PlayersPushBackDistance;
    [SerializeField] float TriggerDelayInSeconds;



    public float GetHealth() { return Health; }
    public float GetClosingSpeed() { return ClosingSpeed; }
    public float GetPlayersPushBackDistance() { return PlayersPushBackDistance; }
    public float GetTriggerDelay() { return TriggerDelayInSeconds; }

}
