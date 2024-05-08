using UnityEngine;

namespace Cloth.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] Animator _bodyAnimator;
        [SerializeField] Animator _clothesAnimator;
        [SerializeField] PlayerMovement _movement;

        // Start is called before the first frame update
        void Start()
        {
            _movement.OnDirectionChange += MovingAnimation;
        }

        public void ChangeClothes(AnimatorOverrideController newClothes)
        {
            _clothesAnimator.runtimeAnimatorController = newClothes;
        }

        private void MovingAnimation(Vector2 direction)
        {
            bool isMoving = direction != Vector2.zero;

            _bodyAnimator.SetBool("isMoving", isMoving);
            _clothesAnimator.SetBool("isMoving", isMoving);

            if (!isMoving) return;

            _bodyAnimator.SetFloat("X", direction.x);
            _bodyAnimator.SetFloat("Y", direction.y);
            _clothesAnimator.SetFloat("X", direction.x);
            _clothesAnimator.SetFloat("Y", direction.y);
        }
    }
}