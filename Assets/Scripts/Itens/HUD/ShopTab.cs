using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Cloth.Items.HUD
{
    public class ShopTab: MonoBehaviour
    {
        [SerializeField] Image _iconDisplay;
        [SerializeField] TMP_Text _nameDisplay;
        [SerializeField] TMP_Text _priceDisplay;
        [SerializeField] Button button;

        private Item _myItem;
        private ShopWindow _parent;

        public void Setup(Item item, ShopWindow shop)
        {
            _iconDisplay.sprite = item.icon;
            _nameDisplay.text = item.name;
            _priceDisplay.text = "" + item.price;

            _myItem = item;
            _parent = shop;

            gameObject.SetActive(true);
        }

        private void CallParent()
        {
            _parent.Transaction(this, _myItem);
        }

        private void Start()
        {
            button.onClick.AddListener(CallParent);
        }
    }
}