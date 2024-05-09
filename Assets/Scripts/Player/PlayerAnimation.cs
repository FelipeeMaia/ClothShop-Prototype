using Cloth.Items;
using UnityEngine;

namespace Cloth.Player
{
    /// <summary>
    /// Controls the player layered animation.
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator[] _animators;
        [SerializeField] PlayerMovement _movement;
        [SerializeField] PlayerInventory _inventory;

        void Start()
        {
            _movement.OnDirectionChange += UpdateMovingAnimation;
            _inventory.OnItemEquip += ChangeClothes;
        }

        public void ChangeClothes(Item itemEquiped)
        {
            int slot = (int)itemEquiped.itemSlot;
           _animators[slot].runtimeAnimatorController = itemEquiped.animation;
        }

        private void UpdateMovingAnimation(Vector2 direction)
        {
            bool isMoving = direction != Vector2.zero;

            for (int i = 0; i < _animators.Length; i++)
            {
                _animators[i].SetBool("isMoving", isMoving);

                if (!isMoving) break;

                _animators[i].SetFloat("X", direction.x);
                _animators[i].SetFloat("Y", direction.y);
            }
        }
    }
}