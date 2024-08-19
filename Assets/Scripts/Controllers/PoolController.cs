using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject objectPrefab;
        public int poolSize;
    }

    [SerializeField] Pool[] pools;

    private void Awake()
    {
        for (int j = 0; j < pools.Length; j++)
        {
            pools[j].pooledObjects = new Queue<GameObject>();

            for (int i = 0; i < pools[j].poolSize; i++)
            {
                GameObject obj = Instantiate(pools[j].objectPrefab);

                obj.SetActive(false);

                pools[j].pooledObjects.Enqueue(obj);
            }
        }
    }

    public GameObject GetPooledObject(EntityTypes entityType)
    {
        if (pools[(int)entityType].pooledObjects == null || pools[(int)entityType].pooledObjects.Count == 0)
        {
            return null;
        }

        GameObject obj = pools[((int)entityType)].pooledObjects.Dequeue();

        obj.SetActive(true);

        pools[((int)entityType)].pooledObjects.Enqueue(obj);

        return obj;
    }
}
