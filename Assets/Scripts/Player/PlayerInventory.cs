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
        public Action<int> OnItemUnequip;

        [SerializeField] List<Item> _items;
        [SerializeField] Item[] _equipedItems;

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

            if (equipedItem is not null)
            {
                UnequipItem(equipedItem);
            }

            _items.Remove(item);
            _equipedItems[index] = item;

            OnItemEquip?.Invoke(item);
        }

        public void UnequipItem(Item item)
        {
            int index = (int)item.itemSlot;
            _equipedItems[index] = null;

            _items.Add(item);
            OnItemUnequip?.Invoke(index);
        }

        private void Awake()
        {
            Money = new PlayerMoney(startingMoney);
        }

        public ref readonly List<Item> GetItems()
        {
            return ref _items;
        }

        public ref readonly Item[] GetEquipedItems()
        {
            return ref _equipedItems;
        }
    }
}