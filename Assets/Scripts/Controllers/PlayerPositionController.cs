using TMPro;
using UnityEngine;

public class PlayerPositionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _positionText;

    public void GetPlayerPosition(string position)
    {
        _positionText.text = position;
    }
}
