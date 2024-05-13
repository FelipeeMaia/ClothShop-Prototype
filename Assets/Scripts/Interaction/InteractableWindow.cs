using Cloth.HUD;
using UnityEngine;

namespace Cloth.Interaction
{
    /// <summary>
    /// Interactable objects that open an window when interacted.
    /// </summary>
    public class InteractableWindow : Interactable
    {
        [SerializeField] Window _window;

        public override void Interact()
        {
            _window.OnWindowClosed += EndInteraction;
            _window.OpenWindow();
        }

        private void EndInteraction()
        {
            _window.OnWindowClosed -= EndInteraction;
            OnInteractionEnd?.Invoke(this);
        }
    }
}