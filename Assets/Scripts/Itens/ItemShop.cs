using System.Collections.Generic;
using Cloth.Player;
using UnityEngine;

namespace Cloth.Items
{
    /// <summary>
    /// Sells and buy items from player.
    /// </summary>
    public class ItemShop : MonoBehaviour
    {
        [SerializeField] private List<Item> _stock;

        public bool PlayerSell(PlayerInventory player, Item item)
        {
            player.RemoveItem(item);
            _stock.Add(item);
            player.Money.Gain(item.price);
            return true;
        }

        public bool PlayerBuy(PlayerInventory player, Item item)
        {
            bool succes = player.Money.TrySpend(item.price);
            if(succes)
            {
                _stock.Remove(item);
                player.AddItem(item);
            }

            return succes;
        }

        public ref readonly List<Item> GetProducts()
        {
            return ref _stock;
        }
    }
}