using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;




public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _groundObject;
    float _clampX;
    [SerializeField] PlayerSettings _playerSetting;
    [SerializeField] GameObject _endGameUI;

    void Start()
    {
        EventManager.current.OnInputEvent += OnInputPlayerLateralMovement;
        _clampX = _groundObject.transform.localScale.x / 2 - 1;
    }

    private void FixedUpdate()
    {
        float _forwardSpeed = _playerSetting.GetForwardSpeed() * Time.deltaTime;
        transform.Translate(0, 0, _forwardSpeed);
        EventManager.current.OnGunPositioningEventInvoke(transform.position);

    }

    private void OnInputPlayerLateralMovement(float xDifference)
    {
        Vector3 pos;
        pos = transform.position;
        pos.x += xDifference * _playerSetting.GetLateralSpeed() * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, -_clampX, _clampX);
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Time.timeScale = 0;
            _endGameUI.SetActive(true);
        }
    }
}
