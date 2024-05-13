using System;

namespace Cloth.Player
{
    /// <summary>
    /// Handles player money.
    /// </summary>
    public class PlayerMoney
    {
        public int Value { get; private set; }
        public Action<int> OnMoneyChange;

        public bool TrySpend(int ammount)
        {
            if (Value >= ammount)
            {
                Value -= ammount;
                OnMoneyChange?.Invoke(Value);
                return true;
            }

            return false;
        }

        public void Gain(int ammount)
        {
            Value += ammount;
            OnMoneyChange?.Invoke(Value);
        }

        public PlayerMoney(int startAmmount)
        {
            Value = startAmmount;
        }
    }
}