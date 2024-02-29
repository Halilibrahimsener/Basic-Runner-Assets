using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Registry : MonoBehaviour
{

    void Start()
    {
        InitializePlayerPrefs();
    }

    public void InitializePlayerPrefs()
    {
        if (!PlayerPrefs.HasKey("TotalMoney"))
        {
            PlayerPrefs.SetInt("TotalMoney", 0);
        }

        if (!PlayerPrefs.HasKey("LevelNo"))
        {
            PlayerPrefs.SetInt("LevelNo", 1);
        }

        if (!PlayerPrefs.HasKey("AdditionalFireRate"))
        {
            PlayerPrefs.SetInt("AdditionalFireRate", 0);
        }

        if (!PlayerPrefs.HasKey("AdditionalMoneyValue"))
        {
            PlayerPrefs.SetInt("AdditionalMoneyValue", 0);
        }

        if (!PlayerPrefs.HasKey("FireRateIncreaseCost"))
        {
            PlayerPrefs.SetInt("FireRateIncreaseCost", 10);
        }

        if (!PlayerPrefs.HasKey("MoneyValueIncreaseCost"))
        {
            PlayerPrefs.SetInt("MoneyValueIncreaseCost", 10);
        }

        Debug.Log("Total Money: " + PlayerPrefs.GetInt("TotalMoney"));
        Debug.Log("Level No: " + PlayerPrefs.GetInt("LevelNo"));
        Debug.Log("Additional Fire Rate: " + PlayerPrefs.GetInt("AdditionalFireRate"));
        Debug.Log("Additional Money Value: " + PlayerPrefs.GetInt("AdditionalMoneyValue"));
        Debug.Log("Fire Rate Increase Cost: " + PlayerPrefs.GetInt("FireRateIncreaseCost"));
        Debug.Log("Money Value Increase Cost: " + PlayerPrefs.GetInt("MoneyValueIncreaseCost"));

    }

    public void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        InitializePlayerPrefs();

        EventManager.current.OnChangeMoneyCounterTextInvoke(PlayerPrefs.GetInt("TotalMoney"));
        EventManager.current.OnChangeLevelCounterTextInvoke(PlayerPrefs.GetInt("LevelNo"));

        GunSettings.GunNumber = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
