using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class DropForMoon : MonoBehaviour, IInteractable
    {
        [SerializeField] private MoonItem moonItem;
        private GameObject moon;

        public void Interact()
        {
            if (GameService.Instance.playerService.GetPlayerItemList().Contains(moonItem))
            {
                moon = moonItem.gameObject;
                moon.SetActive(true);
                SendToDrop();
                EventService.Instance.OnRemoveItem.InvokeEvent(moonItem);
            }
        }

        private void SendToDrop()
        {
            moon.transform.SetParent(transform, true);
            moon.transform.localPosition = Vector3.zero;
            moon.transform.localPosition = Vector3.zero;
        }
    }
}


