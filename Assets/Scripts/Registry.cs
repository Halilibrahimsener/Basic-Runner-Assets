using UnityEngine;
using UnityEngine.SceneManagement;

public static class Registry
{

    #region Keys
    private const string TotalMoneyKey = "TotalMoneyKey";
    private const string LevelNoKey = "LevelNoKey";
    private const string AdditionalFireRateKey = "AdditionalFireRateKey";
    private const string AdditionalMoneyIncomeKey = "AdditionalMoneyIncomeKey";
    private const string FireRateIncreaseCostKey = "FireRateIncreaseCostKey";
    private const string MoneyIncomeIncreaseCostKey = "MoneyIncomeIncreaseCostKey";

    #endregion

    public static int TotalMoney
    {
        set
        {
            PlayerPrefs.SetInt(TotalMoneyKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(TotalMoneyKey, 0);
        }
    }

    public static int LevelNo
    {
        set
        {
            PlayerPrefs.SetInt(LevelNoKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(LevelNoKey, 1);
        }
    }

    public static int AdditionalFireRate
    {
        set
        {
            PlayerPrefs.SetInt(AdditionalFireRateKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(AdditionalFireRateKey, 0);
        }
    }

    public static int AdditionalMoneyIncome
    {
        set
        {
            PlayerPrefs.SetInt(AdditionalMoneyIncomeKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(AdditionalMoneyIncomeKey, 0);
        }
    }

    public static int FireRateIncreaseCost
    {
        set
        {
            PlayerPrefs.SetInt(FireRateIncreaseCostKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(FireRateIncreaseCostKey, 10);
        }
    }

    public static int MoneyIncomeIncreaseCost
    {
        set
        {
            PlayerPrefs.SetInt(MoneyIncomeIncreaseCostKey, value);
            PlayerPrefs.Save();
        }
        get
        {
            return PlayerPrefs.GetInt(MoneyIncomeIncreaseCostKey, 10);
        }
    }

    public static void ResetAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

        EventManager.current.OnChangeMoneyCounterTextInvoke(TotalMoney);
        EventManager.current.OnChangeLevelCounterTextInvoke(LevelNo);

        GunSettings.GunNumber = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
