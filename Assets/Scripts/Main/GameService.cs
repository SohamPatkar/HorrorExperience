using UnityEngine.Rendering;
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

        [Header("Global Volume")]
        [SerializeField] private Volume globalVolume;

        private SanitySystem sanitySystem;

        public PlayerService PlayerService { get; private set; }
        public GameManager GameManager { get { return gameManager; } }
        public UIController UIController { get { return uIController; } }
        public SanitySystem SanitySystem { get { return sanitySystem; } }

        void OnEnable()
        {
            EventService.Instance.OnStartGame.AddListener(CreatePlayer);
        }

        void OnDisable()
        {
            EventService.Instance.OnStartGame.RemoveListener(CreatePlayer);
        }

        void Start()
        {
            EventService.Instance.ShowMainMenu.InvokeEvent();
        }

        private void CreatePlayer()
        {
            sanitySystem = new SanitySystem(globalVolume);
            PlayerService = new PlayerService(playerView, playerSpawnPosition);
            SetSuggestions();
            EventService.Instance.OnStateChange.InvokeEvent(GameState.Gameplay);
        }

        private void SetSuggestions()
        {
            EventService.Instance.SetSuggestionText.InvokeEvent("Look for Notes");
        }
    }
}


