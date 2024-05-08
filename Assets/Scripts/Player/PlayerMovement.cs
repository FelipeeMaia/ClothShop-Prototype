using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector2 _directions;
        public Action<Vector2> OnDirectionChange;

        // Update is called once per frame
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
        }
    }
}