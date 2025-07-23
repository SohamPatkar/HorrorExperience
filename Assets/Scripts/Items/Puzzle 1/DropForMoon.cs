using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using HorrorGame.Main;
using HorrorGame.Sounds;
using UnityEngine;

namespace HorrorGame.Items
{
    public class DropForMoon : MonoBehaviour, IInteractable
    {
        [SerializeField] private MoonItem moonItem;
        [SerializeField] private GameObject puzzleTwo;

        private GameObject moon;

        public void Interact()
        {
            if (GameService.Instance.PlayerService.GetPlayerItemList().Contains(moonItem))
            {
                moon = moonItem.gameObject;
                moon.SetActive(true);
                SendToDrop();
                ChangeMaterialEmission();

                FirstPuzzleCompleted();
            }
        }

        private void SendToDrop()
        {
            moon.transform.SetParent(transform, true);
            moon.transform.localPosition = Vector3.zero;
            moon.transform.localPosition = Vector3.zero;
            moon.GetComponent<BoxCollider>().enabled = false;
        }

        private void ChangeMaterialEmission()
        {
            Material mat = moon.gameObject.GetComponent<Renderer>().material;
            Color baseColor = Color.white;
            Color finalColor = baseColor * Mathf.LinearToGammaSpace(50);
            mat.SetColor("_EmissionColor", finalColor);
        }

        private void FirstPuzzleCompleted()
        {
            EventService.Instance.OnRemoveItem.InvokeEvent(moonItem);
            EventService.Instance.SetNextTask.InvokeEvent(puzzleTwo);
            SoundManager.Instance.PlaySfx(SoundType.Changed);
            EventService.Instance.DimLights.InvokeEvent();
            EventService.Instance.OnFirstPuzzle.InvokeEvent();
        }
    }
}


