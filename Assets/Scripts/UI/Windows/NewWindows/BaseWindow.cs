using UnityEngine;

namespace UI.Windows
{
    public abstract class BaseWindow<T>:MonoBehaviour where T:BaseWindowArgs
    {
        public void Show(T windowArgs = null)
        {
            OnShow(windowArgs);
        }

        public void SetInteractive(bool interactive)
        {
            OnSetInteractive(interactive);
        }

        public void SetActive(bool active)
        {
            OnSetActive(active);
        }
        
        public void Hide()
        {
            OnHide();
        }

        protected abstract void OnShow(T windowArgs = null);
        protected abstract void OnSetInteractive(bool interactive);
        protected abstract void OnSetActive(bool active);
        protected abstract void OnHide();
    }
}