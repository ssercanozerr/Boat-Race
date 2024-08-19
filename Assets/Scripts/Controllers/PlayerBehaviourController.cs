using Assets.Scripts.Signals;
using System.Collections;
using UnityEngine;

public class PlayerBehaviourController : MonoBehaviour
{
    [SerializeField] float _forwardConstantSpeed;
    [SerializeField] float _verticalSpeed;
    [SerializeField] float _rotationSpeed;
    [SerializeField] float _pipeRadius;

    private Rigidbody _rb;
    private AudioSource _audioGems;
    
    private float _currentRotationAngle;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioGems = GetComponent<AudioSource>();
        _currentRotationAngle = 0f;
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0)
        {
            _currentRotationAngle += horizontalInput * _rotationSpeed * Time.fixedDeltaTime;
            _currentRotationAngle %= 360f;
        }

        float radians = _currentRotationAngle * Mathf.Deg2Rad;
        float x = Mathf.Sin(radians) * _pipeRadius;
        float y = Mathf.Cos(radians) * _pipeRadius;

        Vector3 forwardMovement = _forwardConstantSpeed * Time.fixedDeltaTime * transform.right;

        Vector3 newPosition = new(x, y, transform.position.z + verticalInput * _verticalSpeed * Time.fixedDeltaTime);

        Quaternion newRotation = Quaternion.Euler(_currentRotationAngle, 90, 0);

        _rb.MovePosition(newPosition + forwardMovement);
        _rb.MoveRotation(newRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BreakPoint"))
        {
            PlayerSignals.Instance.onPlayerReachedBreakPoint?.Invoke();
            other.transform.parent.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Diamond"))
        {
            _audioGems.Play();
            CanvasSignals.Instance.onSetPlayerScore?.Invoke(10);
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("Wood"))
        {
            StartCoroutine(CollisionWood(2f));
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("FinalLine"))
        {
            StartCoroutine(CollisionFinalLine(2f));
        }
    }

    IEnumerator CollisionWood(float second)
    {
        _forwardConstantSpeed = -100f;
        yield return new WaitForSeconds(second);
        _forwardConstantSpeed = -400;
    }

    IEnumerator CollisionFinalLine(float second)
    {
        yield return new WaitForSeconds(second);
        _forwardConstantSpeed = 0;
        _verticalSpeed = 0;
        _rotationSpeed = 0;
    }
}
