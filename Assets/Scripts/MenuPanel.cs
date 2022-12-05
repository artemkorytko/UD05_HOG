using System;

namespace HOG
{
    public class MenuPanel : BasePanelWIthButton
    {
        public event Action OnMenuButtonClick;

        protected override void OnButtonClick()
        {
            OnMenuButtonClick?.Invoke();
        }
    }
}