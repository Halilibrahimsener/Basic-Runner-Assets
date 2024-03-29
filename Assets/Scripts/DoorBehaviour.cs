using System;
using DG.Tweening;
using TMPro;
using UnityEngine;


public enum DoorType
{
    FireRange, //0
    FireRate  //1 
};

public class DoorBehaviour : MonoBehaviour
{
    bool _triggered = false;
    private DoorType _doorType;
    float _doorValue;
    [SerializeField] DoorSettings _doorSettings;
    [SerializeField] Renderer _renderer;
    [SerializeField] TextMeshPro _doorValueText;
    [SerializeField] TextMeshPro _doorTypeText;

    private void Start()
    {
        EventManager.current.OnDeleteCurrentLevel += OnDoorReturn;
    }

    private void OnEnable()
    {
        _triggered = false;
    }
    public void AssignDoorTypeAndValue(DoorType doorType, int doorValue)
    {
        _doorType = doorType;
        _doorTypeText.text = _doorType.ToString();

        _doorValue = doorValue;
        _doorValueText.text = _doorValue.ToString();

        if (doorValue < 0)
        {
            _renderer.material = _doorSettings.GetNegativeValueMaterials();
        }
        else
        {
            _renderer.material = _doorSettings.GetPositiveValueMaterials();
        }
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
            //Destroy(other.gameObject);
            PoolController.Return(other.name, other.gameObject);
            _doorValueText.text = _doorValue.ToString();
            if (_doorValue >= 0) { _renderer.material = _doorSettings.GetPositiveValueMaterials(); }
        }
    }

    private void OnDoorReturn()
    {
        transform.DOKill(false);
        PoolController.Return(name, gameObject);
    }
}
