using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "Money Setting", menuName = "New Money Setting", order = 7)]
public class MoneySettings : ScriptableObject
{
    [SerializeField] int _moneyValue;
    private int _totalMoney = 0;

    public int GetMoneyValue() { return _moneyValue; }

    public int GetTotalMoney() { return _totalMoney; }

}
