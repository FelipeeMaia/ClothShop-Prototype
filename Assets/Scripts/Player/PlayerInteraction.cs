using Cloth.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth.Player
{
    /// <summary>
    /// Handle players interactions.
    /// </summary>
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] Transform _sensor;
        [SerializeField] Vector3 _offset;
        [SerializeField] float _sensorRange;
        [SerializeField] float _sensorRadius;
        [SerializeField] LayerMask _whatIsInteractable;

        [SerializeField] PlayerMovement _movement;

        public bool blockInteractions;

        void Start()
        {
            _movement.OnDirectionChange += ChangeFacingDirection;
        }

        private void ChangeFacingDirection(Vector2 newDirection)
        {
            if (newDirection == Vector2.zero) return;

            if (newDirection.y != 0)
                newDirection.x = 0;

            Vector3 sensorPosition = (Vector3) 
                (newDirection * _sensorRange) + _offset;

            _sensor.localPosition = sensorPosition;
        }

        private void Update()
        {
            if (blockInteractions) return;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                TryInteraction();
            }
        }

        private void TryInteraction()
        {
            var objectFound = Physics2D.OverlapCircle
                (_sensor.position, _sensorRadius, _whatIsInteractable);

            if (!objectFound) return;

            var interactable = objectFound.GetComponent<Interactable>();

            if (!interactable) return;

            interactable.OnInteractionEnd += InteractionEnded;
            _movement.blockMovement = true;
            blockInteractions = true;
            interactable.Interact();
        }

        private void InteractionEnded(Interactable interactable)
        {
            interactable.OnInteractionEnd -= InteractionEnded;

            _movement.blockMovement = false;
            blockInteractions = false;
        }
    }
}