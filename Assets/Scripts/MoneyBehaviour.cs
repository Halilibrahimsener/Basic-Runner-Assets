using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{


    [SerializeField] MoneySettings _moneySetting;
    private int _moneyValue;

    private void Start()
    {
        EventManager.current.OnDeleteCurrentLevel += OnMoneyReturn;
    }
    private void OnEnable()
    {
        _moneyValue = _moneySetting.GetMoneyValue() + Registry.AdditionalMoneyIncome;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Registry.TotalMoney += _moneyValue;
            EventManager.current.OnChangeMoneyCounterTextInvoke(Registry.TotalMoney);
            PoolController.Return(name, gameObject);
        }
    }
    private void OnMoneyReturn()
    {
        PoolController.Return(name, gameObject);
    }


}
