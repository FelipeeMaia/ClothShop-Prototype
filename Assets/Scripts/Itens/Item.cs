using UnityEngine;

namespace Cloth.Items
{
    /// <summary>
    /// Items atributes.
    /// </summary>
    [CreateAssetMenu(fileName = "newItem", menuName = "Item", order = 1)]
    public class Item : ScriptableObject
    {
        public int price;
        public Sprite icon;
        public bool hidesHair;
        public ItemSlot itemSlot; 
        public AnimatorOverrideController animation;
    }

    public enum ItemSlot { Clothes = 1, Head, Hair}
}