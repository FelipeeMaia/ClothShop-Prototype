using System;
using UnityEngine;

namespace Cloth.Interaction
{
    public abstract class Interactable : MonoBehaviour
    {
        public Action<Interactable> OnInteractionEnd;

        public abstract void Interact();
    }
}