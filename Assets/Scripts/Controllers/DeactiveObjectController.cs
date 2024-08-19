using UnityEngine;

public class DeactiveObjectController : MonoBehaviour
{
    [SerializeField] Transform _player;

    [SerializeField] float _offsetPosition;
    
    private void FixedUpdate()
    {
        transform.position = new(0, 0, _player.position.z + _offsetPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Wood"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
