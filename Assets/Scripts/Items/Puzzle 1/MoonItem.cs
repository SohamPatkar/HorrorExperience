using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using HorrorGame.Player;
using UnityEngine;

namespace HorrorGame.Items
{
    public class MoonItem : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            GameService.Instance.PlayerService.GetPlayerItemList()?.Add(this);
            gameObject.SetActive(false);
        }
    }
}


