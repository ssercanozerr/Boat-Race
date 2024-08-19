using Assets.Scripts.Signals;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CanvasController : MonoBehaviour
    {
        [SerializeField] GameObject _finishPanel;
        [SerializeField] TextMeshProUGUI _finalScoreText;

        public void OnGameStart()
        {
            _finishPanel.SetActive(false);
        }

        public void OnGameFinish()
        {
            _finishPanel.SetActive(true);
            _finalScoreText.text = CanvasSignals.Instance.onGetPlayerScore?.Invoke().ToString();
        }
    }
}