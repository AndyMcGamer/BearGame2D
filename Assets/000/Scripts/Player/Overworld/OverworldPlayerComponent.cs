using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BearGame.Player.Overworld
{
    public class OverworldPlayerComponent : PlayerComponent
    {
        protected new OverworldPlayerManager playerManager;

        public override void Init(PlayerManager playerManager)
        {
            base.Init(playerManager);
            this.playerManager = playerManager as OverworldPlayerManager;
        }
    }
}
