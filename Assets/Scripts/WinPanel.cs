using System;

namespace HOG
{
    public class WinPanel : BasePanelWithButton
    {
        public event Action OnNextlevelButtonClick;
        
        protected override void OnButtonClick()
        {
            OnNextlevelButtonClick?.Invoke();
        }
    }
}