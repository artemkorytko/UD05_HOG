using System;

namespace HOG
{
    //весит на WinPanel
    public class WinPanel : BasePanelWIthButton
    {
        public event Action OnNextLevelButtonClick;
      
        protected override void OnButtonClick()
        {
            OnNextLevelButtonClick?.Invoke();
        }
    }
}