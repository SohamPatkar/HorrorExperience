using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using HorrorGame.Sounds;
using UnityEngine;

namespace HorrorGame.Items
{
    public class PuzzleEnd : MonoBehaviour
    {
        [SerializeField] private GameObject puzzleThree;
        [SerializeField] private GameObject windowBlock;
        private int framesTurnedCount = 0;
        private int totalFrames = 3;

        private void Start()
        {
            EventService.Instance.AddPuzzleCounter.AddListener(AddCount);
        }

        private void AddCount()
        {
            framesTurnedCount += 1;

            if (framesTurnedCount == totalFrames)
            {
                windowBlock.SetActive(true);
                SoundManager.Instance.PlaySfx(SoundType.Changed);
                EventService.Instance.SetNextTask.InvokeEvent(puzzleThree);
            }
        }

        void OnDisable()
        {
            EventService.Instance.AddPuzzleCounter.RemoveListener(AddCount);
        }
    }
}


