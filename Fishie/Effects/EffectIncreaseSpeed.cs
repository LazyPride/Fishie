﻿using Fishie.Entities;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fishie.Effects
{
    class EffectIncreaseSpeed : Effect
    {
        public EffectIncreaseSpeed(float multipler, float seconds) : base()
        {
            this.multipler = multipler;
            Timeout = seconds;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
        }

        public override void OnApply(Entity e)
        {
            Log.Info("Effect: Speed");
            clock.Restart();
        }

        public override void OnTimeoutElapsed(Entity e)
        {
            Log.Warn("Effect end: Speed");
        }

        public override void Update(Entity e, float deltaTime)
        {
            e.Character.Velocity *= multipler;
        }
        private float multipler;
    }
}
