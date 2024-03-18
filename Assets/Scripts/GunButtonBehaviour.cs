using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GunButtonBehaviour : MonoBehaviour
{
    [SerializeField] GunButtonSettings _gunButtonSetting;
    [SerializeField] TextMeshPro _gunNameText;
    GunBehaviour[] _gunPrefabArray;   //must be sorted according to _gunType enum
    GunBehaviour _gun;
    float _closingSpeed;

    void Start()
    {
        EventManager.current.OnDeleteCurrentLevel += OnGunButtonReturn;
    }
    private void OnEnable()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _closingSpeed = _gunButtonSetting.GetGunButtonClosingSpeed() * Time.deltaTime;
            Debug.Log("In trigger and closing speed: " + _closingSpeed);
            PoolController.Get(_gun.name, transform.position);
            transform.DOMoveY(transform.position.y - 1, 1 / _closingSpeed);
        }
    }

    public void AssignGunType(GunType gunType)
    {
        _gunPrefabArray = _gunButtonSetting.GetGunPrefabArray();
        int gunIndex = (int)gunType;
        _gun = _gunPrefabArray[gunIndex];
        _gunNameText.text = _gun.name;
    }

    private void OnGunButtonReturn()
    {
        transform.DOKill(false);
        PoolController.Return(name, gameObject);
    }
}
