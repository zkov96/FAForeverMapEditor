using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

namespace ZUndo
{
    public class ZUndoManager : MonoBehaviour
    {
        private List<ZHistoryObject> startStates;
        private List<ZHistoryObject> history;
        private int index;

        public void RegisterStartState(ZHistoryObject historyObject)
        {
            Type type = historyObject.GetType();
            if (startStates.FindIndex(o => o.GetType() == type) == -1)
            {
                startStates.Add(historyObject);
            }
        }

        public void RegisterState(ZHistoryObject historyObject)
        {
            if (index != history.Count-1)
            {
                history.RemoveRange(index+1, history.Count-(index+1));
            }
            history.Add(historyObject);
            index++;
        }

        /// <summary>
        /// Call on Ctrl+Z or Manual
        /// </summary>
        public bool OnUndo()
        {
            if (index <= 0)
            {
                Debug.LogFormat("No Undo");
                return false;
            }

            Type type = history[index].GetType();

            for (int i = index - 1; i >= 0; i--)
            {
                if (history[i].GetType() == type)
                {
                    history[i].RestoreState();
                    Debug.LogFormat("Undo {0}", history[index].GetDesription());
                    index--;
                    return true;
                }
            }

            for (int i = 0; i < startStates.Count; i--)
            {
                if (startStates[i].GetType() == type)
                {
                    startStates[i].RestoreState();
                    Debug.LogFormat("Undo to start state {0}", history[index].GetDesription());
                    index--;
                    return true;
                }
            }

            Debug.LogFormat("Unknow error for Undo {0}", history[index].GetDesription());

            return false;
        }

        /// <summary>
        /// Call on Ctrl+Y or Manual
        /// </summary>
        private bool OnRedo()
        {
            if (index >= history.Count)
            {
                Debug.LogFormat("No Redo");
                return false;
            }

            history[index + 1].RestoreState();
            Debug.LogFormat("Redo {0}", history[index + 1].GetDesription());
            index++;
            return true;
        }
    }
}