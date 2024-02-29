using System.Collections;
using System.Collections.Generic;
using Flexalon;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TargetBehaviour : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _targetValueText;
    [SerializeField] TargetSettings _targetSetting;
    [SerializeField] FlexalonGridLayout _layoutSetting;
    float _targetValue;
    int _moneyCounter = 0;

    void Start()
    {
        GiveTargetValue();
        ChangeTextValue();
    }

    void GiveTargetValue()
    {
        float _rowSize, _rowNumber, _startPoint;

        _rowSize = _layoutSetting.RowSize;
        _rowNumber = _layoutSetting.Rows;
        _startPoint = transform.parent.position.z - _rowSize * ((_rowNumber - 1) / 2);

        int[] targetRowValues = _targetSetting.GetTargetRowValues();
        for (int i = 0; i < _rowNumber; i++)
        {
            if (transform.position.z == _startPoint + _rowSize * i)
            {
                _targetValue = targetRowValues[i];
            }
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
                    Instantiate(moneyPrefab, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    _moneyCounter++;
                }
            }
            else
            {
                float damage = other.GetComponent<BulletBehaviour>().GetBulletDamage(); //I couldn't find a different way.
                _targetValue -= damage;
                ChangeTextValue();
            }

            Destroy(other.gameObject);
        }
    }


}
