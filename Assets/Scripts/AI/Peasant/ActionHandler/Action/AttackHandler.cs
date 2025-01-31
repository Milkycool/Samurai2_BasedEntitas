﻿using BlueGOAP;
using Game.AI.ViewEffect;
using UnityEngine;

namespace Game.AI
{
    public class AttackHandler : HandlerBase<AttackModel>
    {
        public AttackHandler(
            IAgent<ActionEnum, GoalEnum> agent,
            IMaps<ActionEnum, GoalEnum> maps, 
            IAction<ActionEnum> action) 
            : base(agent, maps, action)
        {
        }
    }
}
