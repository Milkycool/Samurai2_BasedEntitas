﻿using System.Collections.Generic;
using BlueGOAP;
using UnityEngine;

namespace Game.AI.ViewEffect
{
    public abstract class AiViewMgrBase<T>
    {
        private IFSM<T> _fsm;
        private Dictionary<T, IFsmState<T>> _viewDic;
        public AIModelMgrBase<T> ModelMgr { get; private set; }
        public EffectMgr EffectMgr { get; private set; }
        public AudioMgr AudioMgr { get; private set; }
        public AIAniMgr AniMgr { get; private set; }
        public object Self { get; private set; }

        public AiViewMgrBase(string enemyID, object source, object selfTrans)
        {
            Self = selfTrans;
            _fsm = new ActionFSM<T>();
            _viewDic = new Dictionary<T, IFsmState<T>>();
            EffectMgr = new EffectMgr();
            AudioMgr = new AudioMgr(enemyID, source);
            AniMgr = new AIAniMgr(selfTrans);

            ModelMgr = InitModelMgr();

            InitViews();
            InitFsm();
        }

        private void InitFsm()
        {
            foreach (KeyValuePair<T, IFsmState<T>> state in _viewDic)
            {
                _fsm.AddState(state.Key, state.Value);
            }
        }

        protected abstract void InitViews();
        protected abstract AIModelMgrBase<T> InitModelMgr();

        protected void AddView(IFsmState<T> state)
        {
            T key = state.Label;
            if (_viewDic.ContainsKey(key))
            {
                DebugMsg.LogError("已包含当前键值");
            }
            else
            {
                _viewDic.Add(key,state);
            }
        }

        public void ExcuteState(T key)
        {
            if (_viewDic.ContainsKey(key))
            {
                _fsm.ExcuteNewState(key);
            }
            else
            {
                DebugMsg.LogWarning("动作" + key + "不在当前动作缓存内");
            }
        }
    }

    public class AiViewMgr : AiViewMgrBase<ActionEnum>
    {

        public AiViewMgr(string enemyID,object source,object selfTrans) : base(enemyID,source, selfTrans)
        {
            var spawnView = new SpawnView();
            spawnView.Play(EffectMgr,AudioMgr, selfTrans);
        }

        protected override void InitViews()
        {
            AddView(new AttackView(this));
            AddView(new DeadNormalView(this));
            AddView(new DeadHeadView(this));
            AddView(new DeadBodyView(this));
            AddView(new DeadLegView(this));
            AddView(new IdleSwordView(this));
            AddView(new IdleView(this));
            AddView(new UpInjureView(this));
            AddView(new DownInjureView(this));
            AddView(new LeftInjureView(this));
            AddView(new RightInjureView(this));
            AddView(new MoveBackwardView(this));
            AddView(new MoveView(this));
            AddView(new EnterAlertView(this));
            AddView(new ExitAlertView(this));
        }

        protected override AIModelMgrBase<ActionEnum> InitModelMgr()
        {
            return new AIModelMgr();
        }
    }
}
