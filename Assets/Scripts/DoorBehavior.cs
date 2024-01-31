using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


public enum DoorType
{
    Type1, //0
    Type2  //1 
};

public class DoorBehavior : MonoBehaviour
{
    private bool _triggered;
    private DoorType _doorType;
    [SerializeField] private float _doorValue;  // I gave value randomly.


    private Color redTransparentColor = Color.red;
    private Color greenTransparentColor = Color.green;
    private Renderer ColorRenderer;

    private void Awake()
    {
        ColorRenderer = GetComponent<Renderer>();   // I couldn't find a way to do it 
                                                    // without GetComponent method 

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
            _triggered = true;
            _doorType = DoorType.Type2;
        }

        //Döküman ve örnek oyuna bakarak böylesi daha mantıklı geldi. Dökümandaki
        //yeri tam olarak anlayamadım.
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("\nDoor Type: " + _doorType + "\tDoor Value: " + _doorValue);

        if (!_triggered)
        {
            _triggered = true;
            other.transform.DOMoveY(transform.position.y - 5, 1f);
        }
    }
}
