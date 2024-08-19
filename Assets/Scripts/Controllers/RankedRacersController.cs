using Assets.Scripts.Signals;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class RankedRacersController : MonoBehaviour
    {
        [SerializeField] List<GameObject> boats;

        private int _positionCount;

        private void Awake()
        {
            _positionCount = 1;
        }

        private void Update()
        {
            if (!CoreGameSignals.Instance.onGetIsGameFinished.Invoke())
            {
                var rankedBoats = boats.OrderBy(boat => Vector3.Distance(transform.position, boat.transform.position)).ToArray();

                for (int i = 0; i < rankedBoats.Length; i++)
                {
                    if (rankedBoats[i].CompareTag("Player"))
                    {
                        CanvasSignals.Instance.onSetPlayerPosition?.Invoke((i + _positionCount) + " / 4");
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player") && boats.Contains(other.gameObject))
            {
                boats.Remove(other.gameObject);
                _positionCount++;
            }

            if (other.gameObject.CompareTag("Player"))
            {
                CoreGameSignals.Instance.onGameFinish.Invoke();
            }
        }
    }
}