using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Signals
{
    public class CanvasSignals : MonoBehaviour
    {
        public static CanvasSignals Instance;

        public UnityAction<string> onSetPlayerPosition;
        public UnityAction<int> onSetPlayerScore;

        public Func<int> onGetPlayerScore;

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