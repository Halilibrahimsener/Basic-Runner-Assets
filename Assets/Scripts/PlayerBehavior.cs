using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;


public class PlayerBehavior : MonoBehaviour
{


    [SerializeField] GameObject GroundObject;
    float _clampX;
    void Start()
    {
        EventManager.current.OnInputEvent += PlayerMovement;
        _clampX = GroundObject.transform.localScale.x / 2 - 1;
    }


    void Update()
    {
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0.1f, 0);
    }



    private void PlayerMovement(float _xDifference)
    {
        Vector3 pos;
        pos = transform.position;
        pos.x -= _xDifference / 100;            //not sure about this division. I did some sort of alibration here :)
        pos.x = Mathf.Clamp(pos.x, -_clampX, _clampX);
        transform.position = pos;
    }
}
