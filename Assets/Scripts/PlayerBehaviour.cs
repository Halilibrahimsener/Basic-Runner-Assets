using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;


public class PlayerBehaviour : MonoBehaviour
{


    [SerializeField] GameObject GroundObject;
    float _clampX;
    [SerializeField] PlayerSettings PlayerSetting;
    void Start()
    {
        EventManager.current.OnInputEvent += OnInputPlayerLateralMovement;
        _clampX = GroundObject.transform.localScale.x / 2 - 1;
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        float _forwardSpeed = PlayerSetting.GetForwardSpeed() * Time.deltaTime;
        transform.Translate(0, 0, _forwardSpeed);
    }



    private void OnInputPlayerLateralMovement(float xDifference)
    {
        Vector3 pos;
        pos = transform.position;
        pos.x += xDifference * PlayerSetting.GetLateralSpeed() * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -_clampX, _clampX);
        transform.position = pos;
    }
}
