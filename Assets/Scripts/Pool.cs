using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{

    public List<GameObject> ObjectPool;

    public Pool()                                   // Burası nasıl çalışıyor anlamadım? Class'la aynı isimde...
    {
        ObjectPool = new List<GameObject>(150);
    }

    public void ReturnToPool(GameObject gameObject)
    {
        ObjectPool.Add(gameObject);
        gameObject.SetActive(false);
    }

    public GameObject GetFromPool(string key, Vector3 position)
    {
        if (ObjectPool.Count <= 0)
        {
            var resource = Resources.Load<UnityEngine.GameObject>(key);
            var gameObject = Object.Instantiate(resource, position, Quaternion.identity);              // Instantite(resource) ile Object.Instantite(resource) farkı anlamadım?
            gameObject.SetActive(true);
            gameObject.name = key;
            return gameObject;
        }
        else
        {
            var gameObject = ObjectPool[ObjectPool.Count - 1];
            ObjectPool.RemoveAt(ObjectPool.Count - 1);
            gameObject.transform.position = position;
            gameObject.SetActive(true);
            return gameObject;
        }

    }
}
