using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager currentGameManager;
    private void Awake()
    {
        if (currentGameManager == null)
        {
            currentGameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion Singleton

    [SerializeField] ScriptableLevelConfig[] _levels;
    [SerializeField] DoorBehaviour _doorPrefab;
    [SerializeField] GunButtonBehaviour _gunButtonPrefab;
    [SerializeField] ObstacleBehavior _obstaclePrefab;


    private void Start()
    {
        InstantiateGunButtons();
        InstantiateDoors();
        InstantiateObstacles();
    }

    private void InstantiateGunButtons()
    {
        ScriptableLevelConfig.GunButtons[] gunButtonList;
        gunButtonList = _levels[Registry.LevelNo - 1].GetGunButtons();
        for (int i = 0; i < gunButtonList.Length; i++)
        {
            Vector3 gunButtonPosition = gunButtonList[i].Position;
            GunType gunType = gunButtonList[i].gunType;
            GunButtonBehaviour gunButton = Instantiate<GunButtonBehaviour>(_gunButtonPrefab, gunButtonPosition, Quaternion.identity);
            gunButton.AssignGunType(gunType);
        }
    }
    private void InstantiateDoors()
    {
        ScriptableLevelConfig.Doors[] doorList;
        doorList = _levels[Registry.LevelNo - 1].GetDoors();

        for (int i = 0; i < doorList.Length; i++)
        {
            Vector3 doorPosition = doorList[i].Position;
            DoorType doorType = doorList[i].doorType;
            int doorValue = doorList[i].DoorValue;
            DoorBehaviour door = Instantiate<DoorBehaviour>(_doorPrefab, doorPosition, Quaternion.identity);
            door.AssignDoorType(doorType);
            door.AssignDoorValue(doorValue);
        }
    }

    private void InstantiateObstacles()
    {
        ScriptableLevelConfig.Obstacles[] obstacleList;
        obstacleList = _levels[Registry.LevelNo - 1].GetObstacles();

        for (int i = 0; i < obstacleList.Length; i++)
        {
            Vector3 obstaclePosition = obstacleList[i].Position;
            ObstacleBehavior obstacle = Instantiate<ObstacleBehavior>(_obstaclePrefab, obstaclePosition, Quaternion.identity);
        }
    }
}
