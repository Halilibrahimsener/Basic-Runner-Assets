using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] GameObject _doorPrefab;
    [SerializeField] GameObject _gunButtonPrefab;
    [SerializeField] GameObject _obstaclePrefab;
    [SerializeField] GameObject _targetPrefab;
    [SerializeField] TargetSettings _targetSetting;
    [SerializeField] GameObject _playerPrefab;

    private void Start()
    {
        InstantiateLevel();
    }

    public void InstantiateLevel()
    {
        InstantiateGunButtons();
        InstantiateDoors();
        InstantiateObstacles();
        InstantiateTargets();
        InstantiatePlayer();
        InstantiateStartingGun();
    }

    public void DeletePreviousLevel()
    {
        EventManager.current.OnDeleteCurrentLevelInvoke();
    }
    private void InstantiateGunButtons()
    {
        ScriptableLevelConfig.GunButtons[] gunButtonList;
        gunButtonList = _levels[Registry.LevelNo - 1].GetGunButtons();
        for (int i = 0; i < gunButtonList.Length; i++)
        {
            Debug.Log(i);
            Vector3 gunButtonPosition = gunButtonList[i].Position;
            GunType gunType = gunButtonList[i].gunType;
            GameObject gunButton = PoolController.Get(_gunButtonPrefab.name, gunButtonPosition);
            gunButton.GetComponent<GunButtonBehaviour>().AssignGunType(gunType);                // Bunu başka türlü nasıl yapabilirim. Prefab kullanarak bir gameobject oluşturduktan sonra
                                                                                                // bu gameobject altındaki bir tool'a ulaşmak istiyorum. Başka yolu var mı?
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
            //DoorBehaviour door = Instantiate<DoorBehaviour>(_doorPrefab, doorPosition, Quaternion.identity);
            //door.AssignDoorTypeAndValue(doorType, doorValue);
            GameObject door = PoolController.Get(_doorPrefab.name, doorPosition);
            door.GetComponent<DoorBehaviour>().AssignDoorTypeAndValue(doorType, doorValue); // :(
        }
    }
    private void InstantiateObstacles()
    {
        ScriptableLevelConfig.Obstacles[] obstacleList;
        obstacleList = _levels[Registry.LevelNo - 1].GetObstacles();

        for (int i = 0; i < obstacleList.Length; i++)
        {
            Vector3 obstaclePosition = obstacleList[i].Position;
            //ObstacleBehavior obstacle = Instantiate<ObstacleBehavior>(_obstaclePrefab, obstaclePosition, Quaternion.identity);
            GameObject obstacle = PoolController.Get(_obstaclePrefab.name, obstaclePosition);
        }
    }
    private void InstantiateTargets()
    {
        int totalnumberOfRows = _targetSetting.GetTotalNumberOfRows();
        int targetsPerRow = _targetSetting.GetTargetsPerRow();
        float firstRowLocationZ = _targetSetting.GetFirstRowLocationZ();
        Vector3 position = new Vector3(0, 0, firstRowLocationZ);

        for (int i = 0; i < totalnumberOfRows * targetsPerRow; i++)
        {
            GameObject target = PoolController.Get(_targetPrefab.name, position);
        }
    }
    private void InstantiatePlayer()
    {
        _playerPrefab.transform.position = new Vector3(0, 1, 0);
    }

    private void InstantiateStartingGun()
    {
        GunType startingGunType = _levels[Registry.LevelNo - 1].GetStartingGun();
        GameObject startingGun = PoolController.Get(startingGunType.ToString(), _playerPrefab.transform.position);
    }

}
