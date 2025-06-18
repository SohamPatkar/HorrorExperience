using System.Collections;
using System.Collections.Generic;
using HorrorGame.Player;
using HorrorGame.UI;
using HorrorGame.Utilities;
using UnityEngine;

namespace HorrorGame.Main
{
    public class GameService : GenericMonoSingleton<GameService>
    {
        [SerializeField] private UIController uIController;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private GameObject playerSpawnPosition;


        public PlayerService playerService { get; private set; }
        public GameManager GameManager { get { return gameManager; } }
        public UIController UIController { get { return uIController; } }

        void OnEnable()
        {
            EventService.Instance.OnStartGame.AddListener(CreatePlayer);
        }

        void Start()
        {
            EventService.Instance.ShowMainMenu.InvokeEvent();
        }


        private void CreatePlayer()
        {
            playerService = new PlayerService(playerView, playerSpawnPosition);
            SetSuggestions();
        }

        private void SetSuggestions()
        {
            EventService.Instance.SetSuggestionText.InvokeEvent("Look for Notes");
        }
    }
}


