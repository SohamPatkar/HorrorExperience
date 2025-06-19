using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Main
{
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

        private void OnEnable()
        {
            EventService.Instance.SetNextTask.AddListener(StartPuzzle);
            EventService.Instance.DimLights.AddListener(TurnOffLightsPuzzleOne);
            EventService.Instance.DeactivateGameObjects.AddListener(DeactivateGameObjects);
            EventService.Instance.OnLastPuzzle.AddListener(LightsOn);
        }

        private void ODisable()
        {
            EventService.Instance.SetNextTask.RemoveListener(StartPuzzle);
            EventService.Instance.DimLights.RemoveListener(TurnOffLightsPuzzleOne);
            EventService.Instance.DeactivateGameObjects.RemoveListener(DeactivateGameObjects);
            EventService.Instance.OnLastPuzzle.RemoveListener(LightsOn);
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


