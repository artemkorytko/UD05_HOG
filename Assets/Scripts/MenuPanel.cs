using System;

namespace HOG
{
    public class MenuPanel : BasePanelWithButton
    {
        public event Action OnMenuButtonClick;

        protected override void OnButtonClick()
        {
            OnMenuButtonClick?.Invoke();
        }
    }
}