using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class OpponentAIController : MonoBehaviour
    {
        [SerializeField] float _verticalSpeedMin;
        [SerializeField] float _verticalSpeedMax;
        [SerializeField] float _rotationSpeed;
        [SerializeField] float _pipeRadius;
        [SerializeField] float _currentRotationAngle;
        
        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float horizontalInput = Random.Range(-500, 500);
            float verticalInput = Random.Range(_verticalSpeedMin, _verticalSpeedMax);

            if (horizontalInput == -5f || horizontalInput == 5f)
            {
                _currentRotationAngle += horizontalInput * _rotationSpeed * Time.fixedDeltaTime;
                _currentRotationAngle %= 360f;
            }

            float radians = _currentRotationAngle * Mathf.Deg2Rad;
            float x = Mathf.Sin(radians) * _pipeRadius;
            float y = Mathf.Cos(radians) * _pipeRadius;

            Vector3 newPosition = new(x, y, transform.position.z + verticalInput * Time.fixedDeltaTime);

            Quaternion newRotation = Quaternion.Euler(_currentRotationAngle, 90, 0);

            _rb.MovePosition(newPosition);
            _rb.MoveRotation(newRotation);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("FinalLine"))
            {
                StartCoroutine(CollisionFinalLine(2f));
            }
        }

        IEnumerator CollisionFinalLine(float second)
        {
            yield return new WaitForSeconds(second);
            _verticalSpeedMin = 0;
            _verticalSpeedMax = 0;
            _rotationSpeed = 0;
        }
    }
}