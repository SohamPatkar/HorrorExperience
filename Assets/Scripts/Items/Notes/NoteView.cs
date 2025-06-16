using System.Collections;
using System.Collections.Generic;
using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class NoteView : MonoBehaviour, IInteractable
    {
        [SerializeField] private NotesScriptableObject noteData;

        public void Interact()
        {
            EventService.Instance.OpenNotesText.InvokeEvent();
            EventService.Instance.SetNotesText.InvokeEvent(noteData.NoteContents);
        }

    }
}


