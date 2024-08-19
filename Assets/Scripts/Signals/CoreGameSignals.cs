using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CoreGameSignals : MonoBehaviour
    {
        public static CoreGameSignals Instance;

        public UnityAction onGameFinish = delegate { };

        public Func<bool> onGetIsGameFinished = delegate { return false; };

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