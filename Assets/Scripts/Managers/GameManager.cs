using Assets.Scripts.Controllers;
using Assets.Scripts.Signals;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameController _gameController;

    private bool _isGameFinished;

    private void OnEnable()
    {
        CoreGameSignals.Instance.onGameFinish += OnGameFinished;
        CoreGameSignals.Instance.onGetIsGameFinished += GetIsGameFinished;
        PlayerSignals.Instance.onPlayerReachedBreakPoint += _gameController.SpawnNewStage;
    }

    private void OnDisable()
    {
        CoreGameSignals.Instance.onGameFinish -= OnGameFinished;
        CoreGameSignals.Instance.onGetIsGameFinished -= GetIsGameFinished;
        PlayerSignals.Instance.onPlayerReachedBreakPoint -= _gameController.SpawnNewStage;
    }

    private bool GetIsGameFinished()
    {
        return _isGameFinished;
    }

    private void OnGameFinished()
    {
        _isGameFinished = true;
    }
}
