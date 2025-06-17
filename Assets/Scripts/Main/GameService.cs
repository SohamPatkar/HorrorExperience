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
        [SerializeField] private UIService uIService;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private GameObject playerSpawnPosition;
        [SerializeField] private List<GameObject> puzzles;

        public PlayerService playerService { get; private set; }
        public UIService UIService { get { return uIService; } }

        void Start()
        {
            playerService = new PlayerService(playerView, playerSpawnPosition);

            EventService.Instance.SetSuggestionText.InvokeEvent("Look for Notes");
            EventService.Instance.SetNextTask.AddListener(StartPuzzle);
        }

        private void StartPuzzle(GameObject puzzle)
        {
            foreach (GameObject puzzleItem in puzzles)
            {
                if (puzzleItem.name == puzzle.name)
                {
                    puzzle.SetActive(true);
                }
            }
        }

        void OnDisable()
        {
            EventService.Instance.SetNextTask.RemoveListener(StartPuzzle);
        }
    }
}


