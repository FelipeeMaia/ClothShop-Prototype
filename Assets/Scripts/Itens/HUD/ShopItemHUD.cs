using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cloth.Items.HUD
{
    public class ShopItemHUD : MonoBehaviour
    {
        [SerializeField] Image _iconDisplay;
        [SerializeField] TMP_Text _nameDisplay;
        [SerializeField] TMP_Text _priceDisplay;
        [SerializeField] Button button;

        private Item _myItem;
        private ShopHUD _parent;

        public void Setup(Item item, ShopHUD shop)
        {
            _iconDisplay.sprite = item.icon;
            _nameDisplay.text = item.name;
            _priceDisplay.text = "" + item.price;

            _myItem = item;
            _parent = shop;
        }

        private void CallParent()
        {
            //_parent.ButtonCall(_myItem);
        }

        private void Start()
        {
            button.onClick.AddListener(CallParent);
        }
    }
}