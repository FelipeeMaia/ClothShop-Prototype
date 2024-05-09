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
        public Action<Item> OnItemEquip;
        
        public List<Item> Items { get; private set; }
        private Item[] _equipedItems;

        public PlayerMoney Money { get; private set; }
        [SerializeField] int startingMoney;

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
            int index = (int)item.itemSlot;
            Item equipedItem = _equipedItems[index];

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