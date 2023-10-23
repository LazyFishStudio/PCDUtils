using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class StateMachine<T> {
        public T curState;
        public T defaultState;
        private ActionState<T> curStateAction;
        private Dictionary<T, ActionState<T>> stateDic;

        public StateMachine(T defaultState) {
            stateDic = new Dictionary<T, ActionState<T>>();
            CreateAllState((T[])Enum.GetValues(typeof(T)));
            this.defaultState = defaultState;
        }

        public void CreateAllState(T[] states) {
            foreach (T stateName in states) { CreateState(stateName); }
        }

        public void CreateState(T state) {
            if (stateDic.ContainsKey(state)) { return; }
            stateDic.Add(state, new ActionState<T>(state));
        }

        public ActionState<T> GetState(T state) {
            if (!stateDic.ContainsKey(state)) { return null; }
            return stateDic[state];
        }

        public void GotoState(T state, bool allowGotoSameState = true) {
            if (!stateDic.ContainsKey(state)) { return; }
            if (curStateAction != null) {
                curStateAction.onExit();
            }
            if (!allowGotoSameState && state.Equals(curState)) {
                return;
            }
            curStateAction = GetState(state);
            curState = curStateAction.state;
            curStateAction.onEnter();
        }

        public void Init() {
            GotoState(defaultState);
        }

        public void UpdateStateAction() {
            curStateAction.onUpdate();
        }

    }

    public class ActionState<T> {
        public ActionState(T stateName) {
            this.state = stateName;
        }
        public T state;
        public System.Action onEnter = () => {};
        public System.Action onUpdate = () => {};
        public System.Action onExit = () => {};

    // void CreateSM() {
    //     sm = new StateMachine<State>(State.Idle);

    //     sm.GetState(State.Idle).Bind(
    //         () => {},
    //         () => {},
    //         () => {}
    //     );

    //     sm.Init();

    // }
        public void Bind(System.Action onEnter, System.Action onUpdate, System.Action onExit) {
            this.onEnter = onEnter;
            this.onUpdate = onUpdate;
            this.onExit = onExit;
        }
    }
