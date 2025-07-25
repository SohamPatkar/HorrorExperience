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
        [SerializeField] private PlayerScriptableObject playerScriptableObject;

        private Camera camera;

        private IInteractable interactable;

        private PlayerController playerController;

        void Awake()
        {
            Debug.Log("Awake");
            camera = GameObject.Find("Camera").GetComponent<Camera>();
        }

        void OnEnable()
        {
            Debug.Log("Enable");
        }

        void OnDisable()
        {
            EventService.Instance.OnRemoveItem.RemoveListener(playerController.RemoveListItem);
        }

        void Start()
        {
            Debug.Log("Start");
            EventService.Instance.OnRemoveItem.AddListener(playerController.RemoveListItem);
            ResetCameraPosition();
        }

        void Update()
        {
            playerController.PlayerMovement();
            playerController.Interact();
            playerController.GetCount();
        }

        void LateUpdate()
        {
            playerController.CameraMovement();
        }

        private void ResetCameraPosition()
        {
            camera.transform.position = transform.position;
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
    }
}


