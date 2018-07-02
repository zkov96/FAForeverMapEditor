using System;

namespace ZUndo
{
    public abstract class ZHistoryObject
    {
        public ZHistoryObject(ZHistoryParameter parameter)
        {
            
        }
        
        public void RestoreState()
        {
            OnRestoreState();
        }

        public virtual string GetDesription()
        {
            return String.Empty;
        }
        
        protected abstract void OnRestoreState();
    }

    public abstract class ZHistoryParameter
    {
        public Action<ZHistoryParameter> setCalback;

        protected ZHistoryParameter(Action<ZHistoryParameter> setCalback)
        {
            this.setCalback = setCalback;
        }
    }
}