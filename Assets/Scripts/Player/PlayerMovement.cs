using UnityEngine;
using System;

namespace Cloth.Player
{
    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] float _speed;
        private Vector2 _directions;
        public Action<Vector2> OnDirectionChange;

        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            var newDirections = new Vector2(x, y);
            if(newDirections != _directions)
            {
                _directions = newDirections;
                OnDirectionChange?.Invoke(_directions);
            }

            Move(_directions);
        }

        private void Move(Vector2 directions)
        {
            Vector2 moveDirection = directions.normalized;
            Vector3 movement = moveDirection * Time.deltaTime * _speed;
            Vector3 newPosition = transform.position + movement;
            transform.position = newPosition;
        }
    }
}