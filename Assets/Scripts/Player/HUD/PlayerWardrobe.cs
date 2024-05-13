using Cloth.HUD;
using Cloth.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth.Player.HUD
{
    public class PlayerWardrobe : Window
    {
        [SerializeField] WardrobeTab[] _equippedTabs;
        [SerializeField] List<WardrobeTab> _inventoryTabs;

        [SerializeField] PlayerInventory _player;

        public override void OpenWindow()
        {
            UpdateWardrobe();
            base.OpenWindow();
        }

        public void UpdateWardrobe()
        {
            var equipedItems = _player.GetEquipedItems();
            var inventory = _player.GetItems();

            for(int i = 0; i < _inventoryTabs.Count; i++)
            {
                if (i < _equippedTabs.Length)
                    SetEquippedTab(_equippedTabs[i], equipedItems[i]);

                SetInventoryTab(_inventoryTabs[i], inventory, i);
            }
        }

        private void SetEquippedTab(WardrobeTab tab, Item item)
        {
            if (item is not null)
            {
                tab.Setup(item, _player, this);
            }
            else
            {
                tab.gameObject.SetActive(false);
            }
        }

        private void SetInventoryTab(WardrobeTab tab, List<Item> Items, int index)
        {
            if (index < Items.Count)
            {
                tab.Setup(Items[index], _player, this);
            }
            else
            {
                tab.gameObject.SetActive(false);
            }
        }
    }
}