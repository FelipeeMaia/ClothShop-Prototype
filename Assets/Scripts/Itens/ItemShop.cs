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
        public List<Item> Stock { get; private set; }

        public void PlayerSell(PlayerInventory player, Item item)
        {
            player.RemoveItem(item);
            Stock.Add(item);
            player.Money.Gain(item.price);
        }

        public void PlayerBuy(PlayerInventory player, Item item)
        {
            bool succes = player.Money.TrySpend(item.price);
            if(succes)
            {
                Stock.Remove(item);
                player.AddItem(item);
            }
        }
    }
}