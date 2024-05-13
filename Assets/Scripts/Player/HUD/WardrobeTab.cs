using UnityEngine.UI;
using UnityEngine;
using Cloth.Items;
using TMPro;

namespace Cloth.Player.HUD
{
    public class WardrobeTab : MonoBehaviour
    {
        [SerializeField] Image _itemIcon;
        [SerializeField] TMP_Text _itemNameDisplay;
        [SerializeField] Button _equipButton;
        [SerializeField] Button _unequipButton;

        private Item _myItem;
        private PlayerWardrobe _parent;
        private PlayerInventory _player;

        public void Setup(Item item, PlayerInventory player, PlayerWardrobe parent)
        {
            _myItem = item;
            _parent = parent;
            _player = player;

            _itemIcon.sprite = item.icon;
            _itemNameDisplay.text = item.name;
            gameObject.SetActive(true);
        }

        private void EquipButtonClicked()
        {
            _player.EquipItem(_myItem);
            _parent.UpdateWardrobe();
        }

        private void UnequipButtonClicked()
        {
            _player.UnequipItem(_myItem);
            _parent.UpdateWardrobe();
        }

        private void Start()
        {
            _equipButton.onClick.AddListener(EquipButtonClicked);
            _unequipButton.onClick.AddListener(UnequipButtonClicked);
        }
    }
}