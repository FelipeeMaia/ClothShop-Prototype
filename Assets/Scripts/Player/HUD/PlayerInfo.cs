using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cloth.Player.HUD
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] TMP_Text _moneyDisplay;
        [SerializeField] PlayerInventory _inventory;
        [SerializeField] float _waitTime;
        [SerializeField] int _ammountPerTick;

        private bool _isUpdating;
        private int _displayValue;
        private int _actualValue;

        private void Start()
        {
            _inventory.Money.OnMoneyChange += UpdateDisplay;

            _actualValue = _inventory.Money.Value;
            _displayValue = _actualValue;
            _moneyDisplay.text = "" + _displayValue;
        }

        private void UpdateDisplay(int newValue)
        {
            _actualValue = newValue;

            if(!_isUpdating)
                StartCoroutine(ChangeValue());
        }

        private IEnumerator ChangeValue()
        {
            _isUpdating = true;

            while(_actualValue != _displayValue)
            {
                ChangeValueTick();
                yield return new WaitForSeconds(_waitTime);
            }

            _isUpdating = false;
        }

        private void ChangeValueTick()
        {
            int ammount;
            int dif = _actualValue - _displayValue;

            if(dif > 0)
            {
                ammount = dif > _ammountPerTick ? _ammountPerTick : dif;
            }
            else
            {
                ammount = dif < -_ammountPerTick ? -_ammountPerTick : dif; 
            }

            _displayValue += ammount;
            _moneyDisplay.text = "" + _displayValue;
        }
    }
}