using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUIBehaviour : MonoBehaviour
{

    private int _fireRateIncreaseCost;
    private int _moneyValueIncreaseCost;
    [SerializeField] TextMeshProUGUI _fireRateIncreaseCostText;
    [SerializeField] TextMeshProUGUI _moneyValueIncreaseCostText;
    [SerializeField] Button IncreaseFireRateButton;
    [SerializeField] Button IncreaseMoneyValueButton;


    private void OnEnable()
    {
        _fireRateIncreaseCost = PlayerPrefs.GetInt("FireRateIncreaseCost");
        _moneyValueIncreaseCost = PlayerPrefs.GetInt("MoneyValueIncreaseCost");

        _fireRateIncreaseCostText.text = CreateCostMoneyText(_fireRateIncreaseCost);
        _moneyValueIncreaseCostText.text = CreateCostMoneyText(_moneyValueIncreaseCost);

        CheckIsMoneyEnough();
    }

    public void OnFireRateIncrease()
    {
        MoneyBehaviour.TotalMoney -= _fireRateIncreaseCost;
        _fireRateIncreaseCost *= 2;
        PlayerPrefs.SetInt("FireRateIncreaseCost", _fireRateIncreaseCost);
        _fireRateIncreaseCostText.text = CreateCostMoneyText(_fireRateIncreaseCost);

        int currentAdditionalFireRate = PlayerPrefs.GetInt("AdditionalFireRate");
        PlayerPrefs.SetInt("AdditionalFireRate", currentAdditionalFireRate + 1);

        EventManager.current.OnChangeMoneyCounterTextInvoke(MoneyBehaviour.TotalMoney);

        CheckIsMoneyEnough();
    }

    public void OnMoneyIncomeIncrease()
    {
        MoneyBehaviour.TotalMoney -= _moneyValueIncreaseCost;
        _moneyValueIncreaseCost *= 2;
        PlayerPrefs.SetInt("MoneyValueIncreaseCost", _moneyValueIncreaseCost);
        _moneyValueIncreaseCostText.text = CreateCostMoneyText(_moneyValueIncreaseCost);

        int currentAdditionalMoneyValue = PlayerPrefs.GetInt("AdditionalMoneyValue");
        PlayerPrefs.SetInt("AdditionalMoneyValue", currentAdditionalMoneyValue + 1);

        EventManager.current.OnChangeMoneyCounterTextInvoke(MoneyBehaviour.TotalMoney);

        CheckIsMoneyEnough();
    }

    public void OnNextLevel()
    {
        GunSettings.GunNumber = 0;
        PlayerPrefs.SetInt("TotalMoney", MoneyBehaviour.TotalMoney);
        PlayerPrefs.SetInt("LevelNo", PlayerPrefs.GetInt("LevelNo") + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void CheckIsMoneyEnough()
    {
        if (MoneyBehaviour.TotalMoney >= _fireRateIncreaseCost)
        {
            IncreaseFireRateButton.interactable = true;
        }
        else { IncreaseFireRateButton.interactable = false; }

        if (MoneyBehaviour.TotalMoney >= _moneyValueIncreaseCost)
        {
            IncreaseMoneyValueButton.interactable = true;
        }
        else { IncreaseMoneyValueButton.interactable = false; }
    }

    private string CreateCostMoneyText(int totalMoney)
    {
        float value;
        string moneyText = "";
        if (totalMoney / 1000000 > 1)
        {
            value = Mathf.Round(totalMoney / 1000) * 0.01f;
            moneyText = "Cost: " + value.ToString() + "M $";
        }
        else if (totalMoney / 1000 > 1)
        {
            value = Mathf.Round(totalMoney / 10) * 0.01f;
            moneyText = "Cost: " + value.ToString() + "K $";
        }
        else if (totalMoney / 1000 < 1)
        {
            value = totalMoney;
            moneyText = "Cost: " + value.ToString() + " $";
        }

        return moneyText;
    }



}
