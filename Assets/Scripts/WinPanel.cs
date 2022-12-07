using System;

namespace HOG
{
    public class WinPanel : BasePanelWithButton
    {
        public event Action OnNextLevelButtonClick;
        
        protected override void OnButtonClick()
        {
            OnNextLevelButtonClick?.Invoke();
        }
    }
}