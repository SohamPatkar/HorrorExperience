using HorrorGame.Main;
using UnityEngine;

namespace HorrorGame.Items
{
    public class NoteView : MonoBehaviour, IInteractable
    {
        [SerializeField] private NotesScriptableObject noteData;

        public void Interact()
        {
            if (noteData.NoteID == "#2")
            {
                EventService.Instance.OnNotePick.InvokeEvent();
            }

            EventService.Instance.OpenNotesText.InvokeEvent();
            EventService.Instance.SetNotesText.InvokeEvent(noteData.NoteContents);
        }

    }
}


