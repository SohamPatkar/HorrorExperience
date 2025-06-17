using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class FrameCounter : MonoBehaviour
    {
        [SerializeField] private GameObject puzzleThree;
        private int framesTurnedCount = 0;

        private void Start()
        {
            EventService.Instance.AddPuzzleCounter.AddListener(AddCount);
        }

        private void AddCount()
        {
            framesTurnedCount += 1;

            if (framesTurnedCount == 3)
            {
                EventService.Instance.SetNextTask.InvokeEvent(puzzleThree);
            }
        }

        void OnDisable()
        {
            EventService.Instance.AddPuzzleCounter.RemoveListener(AddCount);
        }
    }
}


