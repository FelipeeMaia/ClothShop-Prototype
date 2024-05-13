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
        [SerializeField] AnimatorOverrideController _emptyAnimator;

        void Start()
        {
            _movement.OnDirectionChange += UpdateMovingAnimation;
            _inventory.OnItemEquip += EquipClothes;
            _inventory.OnItemUnequip += RemoveClothes;

            foreach(Item item in _inventory.GetEquipedItems())
            {
                EquipClothes(item);
            }
        }

        public void EquipClothes(Item itemEquiped)
        {
            if (itemEquiped == null) return;

            int slot = (int)itemEquiped.itemSlot;
           _animators[slot].runtimeAnimatorController = itemEquiped.animation;

            int hairSlot = (int)ItemSlot.Hair;
            if(itemEquiped.itemSlot == ItemSlot.Head)
            {
                _animators[hairSlot].gameObject.SetActive(false);
            }

            _animators[slot].gameObject.SetActive(true);
        }

        public void RemoveClothes(int itemType)
        {
            _animators[itemType].runtimeAnimatorController = _emptyAnimator;
            _animators[itemType].gameObject.SetActive(false);

            int hairSlot = (int)ItemSlot.Hair;
            if (itemType == (int)ItemSlot.Head &&
                _animators[hairSlot].runtimeAnimatorController != _emptyAnimator)
            {
                _animators[hairSlot].gameObject.SetActive(true);
            }
        }

        private void UpdateMovingAnimation(Vector2 direction)
        {
            bool isMoving = direction != Vector2.zero;

            for (int i = 0; i < _animators.Length; i++)
            {
                _animators[i].SetBool("isMoving", isMoving);

                if (!isMoving) continue;

                _animators[i].SetFloat("X", direction.x);
                _animators[i].SetFloat("Y", direction.y);
            }
        }
    }
}