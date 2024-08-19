using Assets.Scripts.Enums;
using Assets.Scripts.Signals;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] int _pipeRadius;
        [SerializeField] int _pipeAmount;
        [SerializeField] int _diamondAmount;

        [SerializeField] Vector3 _pipeStartPosition;

        private int _currentPipeIndex = 0;

        private void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                GetObjectPipe();
                GetObjectDiamond();
            }
        }

        public void SpawnNewStage()
        {
            if (_currentPipeIndex <= _pipeAmount)
            {
                GetRandomObject();
            }
            GetObjectPipe();
        }

        private void GetRandomObject()
        {
            if (Random.Range(0, 2) == 0)
            {
                GetObjectDiamond();
            }
            else
            {
                GetObjectWood();
            }
        }

        private void GetObjectPipe()
        {
            GameObject pipe = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Pipe);
            pipe.transform.position = _pipeStartPosition * _currentPipeIndex;
            _currentPipeIndex++;
        }

        private void GetObjectDiamond()
        {
            int diamondPosition_z = 0;
            float randomAngle = Random.Range(0f, 360f);

            for (int i = 0; i < _diamondAmount; i++)
            {
                GameObject diamond_1 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Diamond_1);
                GameObject diamond_2 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Diamond_2);
                GameObject diamond_3 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Diamond_3);

                SetObjectPositionAndRotation(diamond_1, new Vector2(130, 260), diamondPosition_z, randomAngle);
                SetObjectPositionAndRotation(diamond_2, new Vector2(0, 270), diamondPosition_z, randomAngle);
                SetObjectPositionAndRotation(diamond_3, new Vector2(-130, 235), diamondPosition_z, randomAngle);

                diamondPosition_z += 200;
            }
        }

        private void GetObjectWood()
        {
            float randomAngle = Random.Range(0f, 360f);

            GameObject wood_1 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Wood_1);
            GameObject wood_2 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Wood_2);
            GameObject wood_3 = PoolSignals.Instance.onGetEntityFromPool?.Invoke(EntityTypes.Wood_3);

            SetObjectPositionAndRotation(wood_1, new Vector2(0, -300), 0, randomAngle);
            SetObjectPositionAndRotation(wood_2, new Vector2(300, 0), 0, randomAngle);
            SetObjectPositionAndRotation(wood_3, new Vector2(-300, 0), 0, randomAngle);
        }

        private void SetObjectPositionAndRotation(GameObject diamond, Vector2 initialPosition, int z, float angle)
        {
            float radians = angle * Mathf.Deg2Rad;

            float x = initialPosition.x * Mathf.Cos(radians) - initialPosition.y * Mathf.Sin(radians);
            float y = initialPosition.x * Mathf.Sin(radians) + initialPosition.y * Mathf.Cos(radians);

            Vector3 objectPosition = new(x, y, _pipeStartPosition.z * _currentPipeIndex + z);
            diamond.transform.position = objectPosition;

            Vector3 direction = (objectPosition - new Vector3(0, 0, objectPosition.z)).normalized;

            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            diamond.transform.rotation = rotation * Quaternion.Euler(90, 0, 0);
        }
    }
}