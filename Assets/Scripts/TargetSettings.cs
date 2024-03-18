using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Target", menuName = "New Target Setting", order = 5)]
public class TargetSettings : ScriptableObject
{
    [Header("Target Number Settings")]
    [SerializeField] int _targetsPerRow;
    [SerializeField] float _distanceBetweenRows;
    [SerializeField] float _distanceBetweenColums;
    [SerializeField] float _firstRowLocationZ;
    [SerializeField] int _totalNumberOfRows;

    [Header("Target Values")]
    [SerializeField] int _firstRow;
    [SerializeField] int _secondRow;
    [SerializeField] int _thirdRow;
    [SerializeField] int _fourthRow;
    [SerializeField] int _fifthRow;
    [SerializeField] int _sixthRow;
    [SerializeField] int _seventhRow;
    [SerializeField] int _eighthRow;
    [SerializeField] int _ninethRow;
    [SerializeField] int _tenthRow;

    [Header("Other Properties")]
    [SerializeField] GameObject _moneyPrefab;



    public int[] GetTargetRowValues()
    {
        int[] _rowValues = { _firstRow, _secondRow, _thirdRow, _fourthRow, _fifthRow, _sixthRow, _seventhRow, _eighthRow, _ninethRow, _tenthRow };
        return _rowValues;
    }

    public GameObject GetMoneyPrefab() { return _moneyPrefab; }
    public int GetTargetsPerRow() { return _targetsPerRow; }
    public float GetDistanceBetweenRows() { return _distanceBetweenRows; }
    public float GetFirstRowLocationZ() { return _firstRowLocationZ; }
    public float GetDistanceBetweenColums() { return _distanceBetweenColums; }
    public int GetTotalNumberOfRows() { return _totalNumberOfRows; }
}
