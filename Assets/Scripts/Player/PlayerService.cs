using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using UnityEngine;

namespace HorrorGame.Player
{
    public class PlayerService
    {
        private PlayerView playerView;
        private PlayerController playerController;
        private GameObject spawnPosition;


        public PlayerService(PlayerView playerView, GameObject spawnPosition)
        {
            this.playerView = playerView;
            this.spawnPosition = spawnPosition;
            CreatePlayer();
        }

        private void CreatePlayer()
        {
            playerController = new PlayerController(playerView.GetPlayerSO(), playerView, spawnPosition.transform.position);
        }

        public List<IInteractable> GetPlayerItemList()
        {
            return playerController.GetList();
        }
    }
}


