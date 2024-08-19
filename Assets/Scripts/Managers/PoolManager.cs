using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] PoolController _poolController;

        private void OnEnable()
        {
            PoolSignals.Instance.onGetEntityFromPool += _poolController.GetPooledObject;
        }

        private void OnDisable()
        {
            PoolSignals.Instance.onGetEntityFromPool -= _poolController.GetPooledObject;
        }
    }
}