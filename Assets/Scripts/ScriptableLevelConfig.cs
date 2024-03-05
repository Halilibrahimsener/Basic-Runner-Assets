using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "New Level Config", order = 8)]
public sealed class ScriptableLevelConfig : ScriptableObject
{
    [SerializeField] Doors[] _doors;
    [SerializeField] Obstacles[] _obstacles;
    [SerializeField] GunButtons[] _gunButtons;



    [Serializable]
    public struct Doors
    {
        public Vector3 Position;
        public DoorType doorType;
        public int DoorValue;
    }

    [Serializable]
    public struct Obstacles
    {
        public Vector3 Position;
    }

    [Serializable]
    public struct GunButtons
    {
        public Vector3 Position;
        public GunType gunType;
    }

    public Doors[] GetDoors() { return _doors; }
    public Obstacles[] GetObstacles() { return _obstacles; }
    public GunButtons[] GetGunButtons() { return _gunButtons; }

}
