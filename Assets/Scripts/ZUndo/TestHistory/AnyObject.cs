using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZUndo.TestHistory
{
    public class AnyObject:MonoBehaviour
    {
        [SerializeField] private ZUndoManager undoManager;
        [SerializeField] private Button button;
        
        public string param1;
        public int param2;
        public float param3;
        public Vector2[] param4;
        public List<byte> param5;
        
        public void RestoreFromHistory(ZHistoryParameter historyParameter)
        {
            TestHistoryParameter testHistoryParameter = historyParameter as TestHistoryParameter;
            if (testHistoryParameter == null)
            {
                return;
            }

            param1 = testHistoryParameter.param1;
            param2 = testHistoryParameter.param2;
            param3 = testHistoryParameter.param3;
            param4 = testHistoryParameter.param4;
            param5 = testHistoryParameter.param5;
        }

        private void Start()
        {
            button.onClick.AddListener(OnClick);
            undoManager.RegisterStartState(new TestHistoryObject(new TestHistoryParameter(param1, param2, param3, param4, param5, RestoreFromHistory)));
        }

        private void OnClick()
        {
            undoManager.RegisterState(new TestHistoryObject(new TestHistoryParameter(param1, param2, param3, param4, param5, RestoreFromHistory)));
        }
    }
}