using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Main
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> puzzles;
        [SerializeField] private List<Light> lights;

        private void OnEnable()
        {
            EventService.Instance.SetNextTask.AddListener(StartPuzzle);
            EventService.Instance.DimLights.AddListener(TurnOffLightsPuzzleOne);
        }

        private void ODisable()
        {
            EventService.Instance.SetNextTask.RemoveListener(StartPuzzle);
            EventService.Instance.DimLights.RemoveListener(TurnOffLightsPuzzleOne);
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
    }
}


