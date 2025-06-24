using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class EyesView : MonoBehaviour, IInteractable
    {
        private BoxCollider eyeBoxCollider;

        void Awake()
        {
            eyeBoxCollider = GetComponent<BoxCollider>();
        }

        public void Interact()
        {
            Vector3 start = transform.rotation.eulerAngles;
            transform.eulerAngles = new Vector3(90f, start.y, start.z);
            eyeBoxCollider.enabled = false;
            EventService.Instance.AddPuzzleCounter.InvokeEvent();
        }
    }
}


