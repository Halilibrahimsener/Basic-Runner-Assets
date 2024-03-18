using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Flexalon;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TargetBehaviour : MonoBehaviour
{

    [SerializeField] TextMeshPro _targetValueText;
    [SerializeField] TargetSettings _targetSetting;
    [SerializeField] FlexalonGridLayout _layoutSetting;
    float _targetValue;
    int _moneyCounter = 0;
    private static int TargetNo = 1;


    void Start()
    {
        EventManager.current.OnDeleteCurrentLevel += OnTargetReturn;
    }

    private void OnEnable()
    {
        GivePositionAndValueToTarget();
        ChangeTextValue();
        _moneyCounter = 0;
    }

    void GivePositionAndValueToTarget()  //Bu işlemi aslında GameManager'a yaptırsam daha hızlı çalışabilir kod? Poziyonlar her level'da aynı neticede.
    {
        int targetsPerRow = _targetSetting.GetTargetsPerRow();
        float distanceBetweenRows = _targetSetting.GetDistanceBetweenRows();
        float firstRowLocationZ = _targetSetting.GetFirstRowLocationZ();
        float distanceBetweenColumns = _targetSetting.GetDistanceBetweenColums();
        int totalNumberOfRows = _targetSetting.GetTotalNumberOfRows();

        int rowNumber = (TargetNo - 1) / targetsPerRow;
        _targetValue = _targetSetting.GetTargetRowValues()[rowNumber];

        float positionX = -distanceBetweenColumns + ((TargetNo - 1) % targetsPerRow) * distanceBetweenColumns;
        float positionZ = rowNumber * distanceBetweenRows + firstRowLocationZ;
        UnityEngine.Vector3 position = new UnityEngine.Vector3(positionX, 1, positionZ);
        transform.position = position;

        if (TargetNo == targetsPerRow * totalNumberOfRows)
        {
            TargetNo = 1;
        }
        else
        {
            TargetNo++;
        }
    }

    void ChangeTextValue()
    {
        float value;
        if (_targetValue / 1000000 > 1)
        {
            value = Mathf.Round(_targetValue / 1000) * 0.01f;
            _targetValueText.text = value.ToString() + "M";
        }
        else if (_targetValue / 1000 > 1)
        {
            value = Mathf.Round(_targetValue / 10) * 0.01f;
            _targetValueText.text = value.ToString() + "K";
        }
        else if (_targetValue / 1000 < 1)
        {
            value = _targetValue;
            _targetValueText.text = value.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Bullet"))
        {
            if (_targetValue <= 1)
            {
                if (_moneyCounter == 0)
                {
                    GameObject moneyPrefab = _targetSetting.GetMoneyPrefab();
                    PoolController.Get(moneyPrefab.name, transform.position);
                    PoolController.Return(name, gameObject);
                    _moneyCounter++;
                }
            }
            else
            {
                float damage = other.GetComponent<BulletBehaviour>().GetBulletDamage();
                _targetValue -= damage;
                ChangeTextValue();
            }

            PoolController.Return(other.name, other.gameObject);
        }
    }

    private void OnTargetReturn()
    {
        PoolController.Return(name, gameObject);
    }


}
