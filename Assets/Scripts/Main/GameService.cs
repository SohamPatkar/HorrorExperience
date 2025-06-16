using System.Collections;
using System.Collections.Generic;
using HorrorGame.Player;
using HorrorGame.Utilities;
using UnityEngine;

namespace HorrorGame.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField] public PlayerService playerService { get; private set; }
        [SerializeField] private PlayerView playerView;
        [SerializeField] private GameObject playerSpawnPosition;

        void Start()
        {
            playerService = new PlayerService(playerView, playerSpawnPosition);
        }
    }
}


