using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolController
{
    public static Dictionary<string, Pool> PoolDictionary = new Dictionary<string, Pool>();

    public static GameObject Get(string key, Vector3 position)
    {
        if (!PoolDictionary.TryGetValue(key, out var pool))
        {
            pool = new Pool();
            PoolDictionary.Add(key, pool);
        }
        return pool.GetFromPool(key, position);
    }

    public static void Return(string key, GameObject gameObject)
    {
        PoolDictionary[key].ReturnToPool(gameObject);
    }

}
