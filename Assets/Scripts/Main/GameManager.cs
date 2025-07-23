using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Main
{
    public enum GameState
    {
        Gameplay,
        UI
    }

    public class GameManager : MonoBehaviour
    {
        [Header("Puzzles")]
        [SerializeField] private List<GameObject> puzzles;

        [Header("Event 1")]
        [SerializeField] private List<Light> lights;

        [Header("Event 2")]
        [SerializeField] private GameObject furnitureObjects;

        [Header("End Event")]
        [SerializeField] private List<Light> endGame;

        private GameState currentGameState;

        private void OnEnable()
        {
            EventService.Instance.SetNextTask.AddListener(StartPuzzle);
            EventService.Instance.DimLights.AddListener(TurnOffLightsPuzzleOne);
            EventService.Instance.DeactivateGameObjects.AddListener(DeactivateGameObjects);
            EventService.Instance.OnLastPuzzle.AddListener(LightsOn);
            EventService.Instance.OnStateChange.AddListener(SetGameState);
            EventService.Instance.OnFirstPuzzle.AddListener(FirstPuzzleDone);
            EventService.Instance.OnSecondPuzzle.AddListener(SecondPuzzleDone);
            EventService.Instance.OnThirdPuzzle.AddListener(ThirdPuzzleDone);
        }

        private void OnDisable()
        {
            EventService.Instance.SetNextTask.RemoveListener(StartPuzzle);
            EventService.Instance.DimLights.RemoveListener(TurnOffLightsPuzzleOne);
            EventService.Instance.DeactivateGameObjects.RemoveListener(DeactivateGameObjects);
            EventService.Instance.OnLastPuzzle.RemoveListener(LightsOn);
            EventService.Instance.OnStateChange.RemoveListener(SetGameState);
            EventService.Instance.OnFirstPuzzle.RemoveListener(FirstPuzzleDone);
            EventService.Instance.OnSecondPuzzle.RemoveListener(SecondPuzzleDone);
            EventService.Instance.OnThirdPuzzle.RemoveListener(ThirdPuzzleDone);
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

        private void FirstPuzzleDone()
        {
            GameService.Instance.SanitySystem.RemoveColorAdjustments();
        }

        private void SecondPuzzleDone()
        {
            GameService.Instance.SanitySystem.RemoveVignette();
        }

        private void ThirdPuzzleDone()
        {
            GameService.Instance.SanitySystem.RemoveDepthOfField();
        }

        private void SetGameState(GameState state)
        {
            currentGameState = state;
        }

        public GameState GetGameState()
        {
            return currentGameState;
        }

        private void TurnOffLightsPuzzleOne()
        {
            foreach (Light light in lights)
            {
                light.intensity = 0f;
            }
        }

        private void DeactivateGameObjects()
        {
            furnitureObjects.SetActive(false);

            foreach (GameObject puzzleItem in puzzles)
            {
                puzzleItem.SetActive(false);
            }
        }

        private void LightsOn()
        {
            foreach (Light light in endGame)
            {
                light.intensity = 1f;
            }
        }
    }
}


