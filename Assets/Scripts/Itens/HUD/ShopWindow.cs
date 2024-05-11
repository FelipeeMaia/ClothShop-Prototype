using System.Collections.Generic;
using Cloth.Player;
using Cloth.HUD;
using UnityEngine;

namespace Cloth.Items.HUD
{
    public class ShopWindow : Window
    {
        [SerializeField] List<ShopTab> _buyTabs;
        [SerializeField] List<ShopTab> _sellTabs;
        [SerializeField] ItemShop _shop;
        [SerializeField] PlayerInventory _player;

        private void OnEnable()
        {
            OpenWindow();
        }

        public override void OpenWindow()
        {
            UpdateTabs();
            base.OpenWindow();
        }

        public void UpdateTabs()
        {
            for(int i = 0; i < _buyTabs.Count; i++)
            {
                SetItemTab(_buyTabs[i], _shop.GetProducts(), i);
                SetItemTab(_sellTabs[i], _player.GetItems(), i);
            }
        }

        private void SetItemTab(ShopTab tab, List<Item> Items, int index)
        {
            if(index < Items.Count)
            {
                tab.Setup(Items[index], this);
            }
            else
            {
                tab.gameObject.SetActive(false);
            }
        }

        public void Transaction(ShopTab tab, Item item)
        {
            bool succes = false;

            if(_buyTabs.Contains(tab))
            {
                succes = _shop.PlayerBuy(_player, item);
            }
            else if(_sellTabs.Contains(tab))
            {
                succes = _shop.PlayerSell(_player, item);
            }

            if(succes)
            {
                UpdateTabs();
            }
        }
    }
}