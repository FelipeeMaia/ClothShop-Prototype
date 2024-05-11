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

        [SerializeField] private List<Item> _items;
        private Item[] _equipedItems;

        public PlayerMoney Money { get; private set; }
        [SerializeField] int startingMoney;

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public void EquipItem(Item item)
        {
            int index = (int)item.itemSlot;
            Item equipedItem = _equipedItems[index];

            if (equipedItem)
                _items.Add(equipedItem);

            _items.Remove(item);
            equipedItem = item;

            OnItemEquip?.Invoke(item);
        }

        private void Start()
        {
            Money = new PlayerMoney(startingMoney);
        }

        public ref readonly List<Item> GetItems()
        {
            return ref _items;
        }
    }
}