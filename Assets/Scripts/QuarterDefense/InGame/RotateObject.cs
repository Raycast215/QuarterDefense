using UnityEngine;

namespace QuarterDefense.InGame
{
    public class RotateObject : MonoBehaviour
    {
        [SerializeField] private float speed = 0.0f;

        private void FixedUpdate()
        {
            OnRotate();
        }

        private void OnRotate()
        {
            transform.Rotate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}