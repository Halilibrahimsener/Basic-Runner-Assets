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


    private Color redTransparentColor = Color.red;
    private Color greenTransparentColor = Color.green;
    [SerializeField] private Renderer ColorRenderer;
    [SerializeField] float DoorClosingSpeed = 0.1f;

    private void Awake()
    {

        redTransparentColor.a = 0.42f;
        greenTransparentColor.a = 0.42f;

        if (_doorValue < 0)
        {
            ColorRenderer.material.color = redTransparentColor;
            _triggered = false;
            _doorType = DoorType.Type1;
        }
        else
        {
            ColorRenderer.material.color = greenTransparentColor;
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
                float _doorClosingSpeed = DoorClosingSpeed * Time.deltaTime;
                transform.DOMoveY(transform.position.y - 5, 1 / _doorClosingSpeed);
            }
        }
    }
}
