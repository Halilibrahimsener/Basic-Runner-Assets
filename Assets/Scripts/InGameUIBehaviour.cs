using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUIBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyText;
    [SerializeField] TextMeshProUGUI _levelText;
    private int _levelStartMoney;
    private int _currentLevel;
    Registry _registry;

    void Start()
    {
        _levelStartMoney = PlayerPrefs.GetInt("TotalMoney");
        ChangeMoneyText(_levelStartMoney);

        EventManager.current.OnChangeMoneyCounterText += ChangeMoneyText;

        _currentLevel = PlayerPrefs.GetInt("LevelNo");
        ChangeLevelText(_currentLevel);

        EventManager.current.OnChangeLevelCounterText += ChangeLevelText;
    }

    private void ChangeMoneyText(int totalMoney)
    {
        float value;
        if (totalMoney / 1000000 > 1)
        {
            value = Mathf.Round(totalMoney / 1000) * 0.01f;
            _moneyText.text = "Money: " + value.ToString() + "M $";
        }
        else if (totalMoney / 1000 > 1)
        {
            value = Mathf.Round(totalMoney / 10) * 0.01f;
            _moneyText.text = "Money: " + value.ToString() + "K $";
        }
        else if (totalMoney / 1000 < 1)
        {
            value = totalMoney;
            _moneyText.text = "Money: " + value.ToString() + " $";
        }
    }

    private void ChangeLevelText(int currentLevel)
    {
        _levelText.text = "Level: " + currentLevel.ToString();
    }


}
