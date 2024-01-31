// -----------------------------------------------------------------------
// <copyright file="World.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.CustomModules.API.Features.CustomGameModes
{
    using Exiled.API.Features.Core.Generic;
    using Exiled.CustomModules.API.Enums;
    using MEC;
    using PluginAPI.Core;

    using Server = Exiled.API.Features.Server;

    /// <summary>
    /// The world base.
    /// </summary>
    public class World : StaticActor<World>
    {
        private GameState gameState;

        /// <summary>
        /// Gets the <see cref="CustomGameModes.GameState"/>.
        /// </summary>
        public GameState GameState => gameState ??= GetComponent<GameState>();

        /// <inheritdoc/>
        protected override void Tick()
        {
            base.Tick();

            if (GameState.MatchState != UEMatchState.Terminated)
                return;

            if (GameState.Settings.RestartRoundOnEnd)
                Timing.CallDelayed(GameState.Settings.RestartWindupTime, Server.Restart);

            CanEverTick = false;
        }
    }
}