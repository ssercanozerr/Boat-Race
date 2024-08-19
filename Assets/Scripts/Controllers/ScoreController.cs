using TMPro;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _scoreText;
        
        private int _score;

        private void Awake()
        {
            UpdateScore(0);
        }

        public void UpdateScore(int score)
        {
            _score += score;
            _scoreText.text = _score.ToString("000");
        }

        public int GetScore()
        {
            return _score;
        }
    }
}