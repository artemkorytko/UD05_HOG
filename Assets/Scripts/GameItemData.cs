using UnityEngine;

namespace HOG
{
    public class GameItemData //будет хранить картинку и кол-во
    {
       
        private Sprite _sprite;
        private int _amount;

        public int Amount => _amount;

        public Sprite Sprite => _sprite;

        


      

        public GameItemData(Sprite sprite)
        {
            _sprite = sprite;
            _amount = 1;
        }

        public void IncreaseAmount()
        {
            _amount++;
        }

        public void DecreaseAmount()
        {
            _amount--;
        }
    }
}