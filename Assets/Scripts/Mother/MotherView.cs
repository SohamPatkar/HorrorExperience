using HorrorGame.Items;
using HorrorGame.Main;
using HorrorGame.Sounds;
using UnityEngine;

namespace HorrorGame.Mother
{
    public class MotherView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smokeparticle;
        [SerializeField] private GameObject motherPrefab;
        [SerializeField] private GameObject note;

        private float timer = 1f;

        private void OnTriggerEnter(Collider other)
        {
            smokeparticle.Play();

            if (motherPrefab != null)
            {
                motherPrefab.SetActive(true);
                Destroy(gameObject, timer);
            }
            else if (note != null)
            {
                ThirdPuzzleComplete();
            }
        }

        private void DeactivateGameobjects()
        {
            EventService.Instance.DeactivateGameObjects.InvokeEvent();
        }

        private void ThirdPuzzleComplete()
        {
            note.SetActive(true);
            DeactivateGameobjects();
            EventService.Instance.OnLastPuzzle.InvokeEvent();
            SoundManager.Instance.PlayBackgroundMusic(SoundType.EndMusic);
            SoundManager.Instance.PlaySfx(SoundType.Changed);
            EventService.Instance.OnThirdPuzzle.InvokeEvent();
            Destroy(gameObject, timer);
        }
    }
}

