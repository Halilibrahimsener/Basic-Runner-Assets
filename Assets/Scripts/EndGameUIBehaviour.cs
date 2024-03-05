using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUIBehaviour : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _fireRateIncreaseCostText;
    [SerializeField] TextMeshProUGUI _moneyIncomeIncreaseCostText;
    [SerializeField] Button _increaseFireRateButton;
    [SerializeField] Button _increaseMoneyValueButton;



    private void OnEnable()
    {
        _fireRateIncreaseCostText.text = CreateCostMoneyText(Registry.FireRateIncreaseCost);
        _moneyIncomeIncreaseCostText.text = CreateCostMoneyText(Registry.MoneyIncomeIncreaseCost);

        CheckIsMoneyEnough();
    }

    public void OnFireRateIncrease()
    {
        Registry.TotalMoney -= Registry.FireRateIncreaseCost;
        Registry.FireRateIncreaseCost *= 2;
        _fireRateIncreaseCostText.text = CreateCostMoneyText(Registry.FireRateIncreaseCost);

        Registry.AdditionalFireRate += 1;

        EventManager.current.OnChangeMoneyCounterTextInvoke(Registry.TotalMoney);

        CheckIsMoneyEnough();
    }

    public void OnMoneyIncomeIncrease()
    {
        Registry.TotalMoney -= Registry.MoneyIncomeIncreaseCost;
        Registry.MoneyIncomeIncreaseCost *= 2;
        _moneyIncomeIncreaseCostText.text = CreateCostMoneyText(Registry.MoneyIncomeIncreaseCost);

        Registry.AdditionalMoneyIncome += 1;

        EventManager.current.OnChangeMoneyCounterTextInvoke(Registry.TotalMoney);

        CheckIsMoneyEnough();
    }

    private void CheckIsMoneyEnough()
    {
        if (Registry.TotalMoney >= Registry.FireRateIncreaseCost)
        {
            _increaseFireRateButton.interactable = true;
        }
        else { _increaseFireRateButton.interactable = false; }

        if (Registry.TotalMoney >= Registry.MoneyIncomeIncreaseCost)
        {
            _increaseMoneyValueButton.interactable = true;
        }
        else { _increaseMoneyValueButton.interactable = false; }
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

    public void OnNextLevel()
    {
        GunSettings.GunNumber = 0;
        Registry.LevelNo += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 1;
    }



}
