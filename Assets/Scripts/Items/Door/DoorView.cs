using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using HorrorGame.Sounds;
using UnityEngine;

namespace HorrorGame.Items
{
    public class DoorView : MonoBehaviour, IInteractable
    {
        private BoxCollider doorCollider;

        void Awake()
        {
            doorCollider = GetComponent<BoxCollider>();
        }

        private void OnEnable()
        {
            EventService.Instance.OnLastPuzzle.AddListener(SetBoxColliderOn);
        }

        void OnDisable()
        {
            EventService.Instance.OnLastPuzzle.RemoveListener(SetBoxColliderOn);
        }

        private void SetBoxColliderOn()
        {
            doorCollider.enabled = true;
        }

        public void Interact()
        {
            EventService.Instance.OnDoorOpen.InvokeEvent();
        }
    }
}


