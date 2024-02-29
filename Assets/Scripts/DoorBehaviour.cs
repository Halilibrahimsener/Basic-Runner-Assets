using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public enum DoorType
{
    FireRange, //0
    FireRate  //1 
};

public class DoorBehaviour : MonoBehaviour
{
    bool _triggered = false;
    DoorType _doorType;
    [SerializeField] float _doorValue;  // I gave value randomly.
    [SerializeField] DoorSettings _doorSettings;
    [SerializeField] Renderer _renderer;
    [SerializeField] TextMeshProUGUI _doorValueText;
    [SerializeField] TextMeshProUGUI _doorTypeText;

    private void Awake()
    {
        float randomValue = Random.value;

        if (randomValue >= 0.5) { _doorType = DoorType.FireRange; }
        else { _doorType = DoorType.FireRate; }


        if (_doorValue < 0)
        {
            _renderer.material = _doorSettings.GetNegativeValueMaterials();
        }
        else
        {
            _renderer.material = _doorSettings.GetPositiveValueMaterials();
        }

        _doorValueText.text = _doorValue.ToString();
        _doorTypeText.text = _doorType.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_triggered)
            {
                _triggered = true;
                float doorClosingSpeed = _doorSettings.GetClosingSpeed() * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 3, 1 / doorClosingSpeed);
                EventManager.current.OnUpdateFireRangeOrRateInvoke(_doorType, _doorValue);
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            _doorValue += 1;
            Destroy(other.gameObject);
            _doorValueText.text = _doorValue.ToString();
            if (_doorValue >= 0) { _renderer.material = _doorSettings.GetPositiveValueMaterials(); }
        }
    }
}
