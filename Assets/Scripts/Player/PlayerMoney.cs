using System;

namespace Cloth.Player
{
    public class PlayerMoney
    {
        public int money { get; private set; }
        public Action<int> OnMoneyChange;

        public bool Spend(int ammount)
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