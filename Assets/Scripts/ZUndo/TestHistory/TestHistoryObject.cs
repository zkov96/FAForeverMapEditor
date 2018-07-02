using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZUndo.TestHistory
{
    public class TestHistoryObject:ZHistoryObject
    {
        private TestHistoryParameter parameter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter">is new object state (after changes)</param>
        public TestHistoryObject(TestHistoryParameter parameter) : base(parameter)
        {
            this.parameter = parameter;
        }

        protected override void OnRestoreState()
        {
            if (parameter.setCalback!=null)
            {
                parameter.setCalback(parameter);
            }
        }
    }

    public class TestHistoryParameter : ZHistoryParameter
    {
        public string param1;
        public int param2;
        public float param3;
        public Vector2[] param4;
        public List<byte> param5;
        
        public TestHistoryParameter(string param1, int param2, float param3, Vector2[] param4, List<byte> param5, Action<ZHistoryParameter> setCalback) : base(setCalback)
        {
            this.param1 = param1;
            this.param2 = param2;
            this.param3 = param3;
            this.param4 = param4;
            this.param5 = param5;
        }
    }
}