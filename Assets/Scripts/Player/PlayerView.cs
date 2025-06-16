using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using HorrorGame.Main;
using HorrorGame.SO;
using UnityEngine;


namespace HorrorGame.Player
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        private PlayerController playerController;

        void Start()
        {
            EventService.Instance.OnRemoveItem.AddListener(playerController.RemoveListItem);
        }

        // Update is called once per frame
        void Update()
        {
            playerController.CameraMovement();
            playerController.PlayerMovement();
            playerController.Interact();
            playerController.GetCount();
        }

        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public Camera GetCamera()
        {
            return camera;
        }

        public PlayerScriptableObject GetPlayerSO()
        {
            return playerScriptableObject;
        }

        public Transform GetPlayerTransform()
        {
            return transform;
        }

        void OnTriggerStay(Collider other)
        {
            IInteractable interactable;

            if (other.TryGetComponent(out interactable) && playerController.IsInteracted)
            {
                interactable.Interact();
                playerController.IsInteracted = false;
            }
        }

        void OnDisable()
        {
            EventService.Instance.OnRemoveItem.RemoveListener(playerController.RemoveListItem);
        }
    }
}


