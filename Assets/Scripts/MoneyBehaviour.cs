using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class MoneyBehaviour : MonoBehaviour
{


    [SerializeField] MoneySettings _moneySetting;
    public static int TotalMoney;
    private int _moneyValue;
    [SerializeField] Collider _collider;

    private void Start()
    {
        _moneyValue = _moneySetting.GetMoneyValue() + PlayerPrefs.GetInt("AdditionalMoneyValue");

        TotalMoney = PlayerPrefs.GetInt("TotalMoney");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TotalMoney += _moneyValue;
            EventManager.current.OnChangeMoneyCounterTextInvoke(TotalMoney);
            Destroy(gameObject);
        }
    }
}
