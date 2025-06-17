using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class EyesView : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Vector3 start = transform.rotation.eulerAngles;
            transform.eulerAngles = new Vector3(90f, start.y, start.z);
            EventService.Instance.AddPuzzleCounter.InvokeEvent();
        }
    }
}


