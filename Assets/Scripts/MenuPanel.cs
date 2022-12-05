using System;

namespace HOG
{
    //весит на MenuPanel
    public class MenuPanel : BasePanelWIthButton
    {
        public event Action OnMenuButtonClick;

        protected override void OnButtonClick()
        {
            OnMenuButtonClick?.Invoke();
        }
    }
}