using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class CanvasManager : MonoBehaviour
    {
        [SerializeField] PlayerPositionController _playerPositionController;
        [SerializeField] ScoreController _scoreController;
        [SerializeField] CanvasController _canvasController;

        private void OnEnable()
        {
            CanvasSignals.Instance.onSetPlayerPosition += _playerPositionController.GetPlayerPosition;
            CanvasSignals.Instance.onSetPlayerScore += _scoreController.UpdateScore;
            CanvasSignals.Instance.onGetPlayerScore += _scoreController.GetScore;
            CoreGameSignals.Instance.onGameFinish += _canvasController.OnGameFinish;
        }

        private void OnDisable()
        {
            CanvasSignals.Instance.onSetPlayerPosition -= _playerPositionController.GetPlayerPosition;
            CanvasSignals.Instance.onSetPlayerScore -= _scoreController.UpdateScore;
            CanvasSignals.Instance.onGetPlayerScore -= _scoreController.GetScore;
            CoreGameSignals.Instance.onGameFinish -= _canvasController.OnGameFinish;
        }
    }
}