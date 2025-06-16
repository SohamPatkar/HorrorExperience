using System.Collections.Generic;
using HorrorGame.Items;
using HorrorGame.SO;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

namespace HorrorGame.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerScriptableObject playerScriptableObject;

        private float mouseX;
        private float mouseY;
        private float mouseXSens;
        private float mouseYSens;
        private Camera playerCam;
        private Transform playerTransform;
        private float movementSpeed;
        public bool IsInteracted;

        public PlayerController(PlayerScriptableObject playerScriptableObject, PlayerView playerView, Vector3 spawnPos)
        {
            this.playerScriptableObject = playerScriptableObject;
            this.playerView = Object.Instantiate(playerView.gameObject, spawnPos, quaternion.identity).GetComponent<PlayerView>();

            Initialize();
        }

        private void Initialize()
        {
            mouseXSens = 250f;
            mouseYSens = 250f;
            playerView.SetController(this);
            playerCam = playerView.GetCamera();
            playerTransform = playerView.GetPlayerTransform();
            movementSpeed = playerScriptableObject.MovementSpeed;
            IsInteracted = false;
        }

        public void PlayerMovement()
        {
            float verticalmovement = Input.GetAxis("Vertical");
            float horizontalmovement = Input.GetAxis("Horizontal");
            Rigidbody rb = playerTransform.GetComponent<Rigidbody>();

            Vector3 moveDirection = (playerTransform.forward * verticalmovement) + (playerTransform.right * horizontalmovement);

            moveDirection.Normalize();

            if (moveDirection.magnitude > 0.01f)
            {
                rb.isKinematic = false;
                rb.velocity = new Vector3(moveDirection.x * movementSpeed, rb.velocity.y, moveDirection.z * movementSpeed);
            }
            else
            {
                rb.isKinematic = true;
            }
        }

        public void CameraMovement()
        {
            Cursor.lockState = CursorLockMode.Locked;

            float mouseXRotation = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseXSens;
            float mouseYRotation = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseYSens;

            mouseX -= mouseYRotation;
            mouseY += mouseXRotation;

            mouseX = Mathf.Clamp(mouseX, -90f, 90f);

            playerCam.transform.position = new Vector3(playerTransform.position.x, playerCam.transform.position.y, playerTransform.position.z);

            playerCam.transform.rotation = Quaternion.Euler(mouseX, mouseY, 0);
            playerTransform.rotation = Quaternion.Euler(0, mouseY, 0);
        }

        public void Interact()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                IsInteracted = true;
            }
        }

        public void GetCount()
        {
            Debug.Log(playerScriptableObject.Items.Count);
        }

        public List<IInteractable> GetList()
        {
            return playerScriptableObject.Items;
        }

        public void RemoveListItem(IInteractable interactable)
        {
            if (playerScriptableObject.Items.Contains(interactable))
            {
                playerScriptableObject.Items.Remove(interactable);
            }
        }

    }

}

