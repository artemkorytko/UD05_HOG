using System;

namespace HOG
{
    public class WinPanel : BasePanelWIthButton
    {
        public event Action OnNextLevelButtonClick;
      
        protected override void OnButtonClick()
        {
            OnNextLevelButtonClick?.Invoke();
        }
    }
}