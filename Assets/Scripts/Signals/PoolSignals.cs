using Assets.Scripts.Enums;
using System;
using UnityEngine;

namespace Assets.Scripts.Signals
{
    public class PoolSignals : MonoBehaviour
    {
        public static PoolSignals Instance;

        public Func<EntityTypes, GameObject> onGetEntityFromPool;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
    }
}