using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public enum DoorType
{
    Type1, //0
    Type2  //1 
};

public class DoorBehaviour : MonoBehaviour
{
    private bool _triggered;
    private DoorType _doorType;
    [SerializeField] private float _doorValue;  // I gave value randomly.
    [SerializeField] DoorSettings doorSettings;
    [SerializeField] private Renderer ColorRenderer;

    private void Awake()
    {
        if (_doorValue < 0)
        {
            ColorRenderer.material.color = doorSettings.GetNegativeValueColors();
            _triggered = false;
            _doorType = DoorType.Type1;
        }
        else
        {
            ColorRenderer.material.color = doorSettings.GetPositiveValueColors();
            _triggered = false;
            _doorType = DoorType.Type2;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("\nDoor Type: " + _doorType + "\tDoor Value: " + _doorValue);
            if (!_triggered)
            {
                _triggered = true;
                float _doorClosingSpeed = doorSettings.GetClosingSpeed() * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 3, 1 / _doorClosingSpeed);
            }
        }
    }
}
