using System;

namespace Cloth.Player
{
    /// <summary>
    /// Handles player money.
    /// </summary>
    public class PlayerMoney
    {
        private int money;
        public Action<int> OnMoneyChange;

        public bool TrySpend(int ammount)
        {
            if (money >= ammount)
            {
                money -= ammount;
                OnMoneyChange?.Invoke(money);
                return true;
            }

            return false;
        }

        public void Gain(int ammount)
        {
            money += ammount;
            OnMoneyChange?.Invoke(money);
        }

        public PlayerMoney(int startAmmount)
        {
            money = startAmmount;
        }
    }
}