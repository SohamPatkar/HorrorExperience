using HorrorGame.Main;
using HorrorGame.Sounds;
using UnityEngine;

namespace HorrorGame.Items
{
    public class PuzzleEnd : MonoBehaviour
    {
        [SerializeField] private GameObject puzzleThree;
        [SerializeField] private GameObject windowBlock;
        [SerializeField] private GameObject[] frames;
        private int framesTurnedCount = 0;
        private int totalFrames = 3;

        void OnEnable()
        {
            EventService.Instance.OnNotePick.AddListener(ActivateFrames);
        }

        void OnDisable()
        {
            EventService.Instance.OnNotePick.RemoveListener(ActivateFrames);
        }

        private void Start()
        {
            EventService.Instance.AddPuzzleCounter.AddListener(AddCount);
        }

        private void AddCount()
        {
            framesTurnedCount += 1;

            if (framesTurnedCount == totalFrames)
            {
                SecondPuzzleCompleted();
            }
        }

        private void ActivateFrames()
        {
            foreach (GameObject frame in frames)
            {
                frame.SetActive(true);
            }
        }

        private void SecondPuzzleCompleted()
        {
            windowBlock.SetActive(true);
            SoundManager.Instance.PlaySfx(SoundType.Changed);
            EventService.Instance.SetNextTask.InvokeEvent(puzzleThree);
            EventService.Instance.OnSecondPuzzle.InvokeEvent();
        }
    }
}


