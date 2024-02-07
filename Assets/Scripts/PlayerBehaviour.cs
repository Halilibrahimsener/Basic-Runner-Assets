using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;




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

        Debug.Log("PlayerBehaviour: x: " + transform.position.x + ",y: " + transform.position.y + ",z: " + transform.position.z);
        Vector3 playerPosition = transform.position;
        EventManager.current.OnFireEventInvoke(playerPosition);
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
