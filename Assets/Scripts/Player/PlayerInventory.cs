using System.Collections.Generic;
using UnityEngine;
using Cloth.Items;
using System;

namespace Cloth.Player
{
    /// <summary>
    /// Handle players items and money.
    /// </summary>
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] Item headItem;
        [SerializeField] Item clothesItem;
        public List<Item> Items { get; private set; }
        public PlayerMoney Money { get; private set; }
        [SerializeField] int startingMoney;

        public Action<Item> OnItemEquip;

        public void AddItem(Item item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public void EquipItem(Item item)
        {
            Item equipedItem = item.itemSlot switch
            {
                ItemSlot.Clothes => clothesItem,
                ItemSlot.Head    => headItem,
                _                => null
            };

            if (equipedItem)
                Items.Add(equipedItem);

            Items.Remove(item);
            equipedItem = item;

            OnItemEquip?.Invoke(item);
        }

        private void Start()
        {
            Money = new PlayerMoney(startingMoney);
        }
    }
}