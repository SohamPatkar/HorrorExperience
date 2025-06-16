using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Items
{
    [CreateAssetMenu(menuName = "Notes")]
    public class NotesScriptableObject : ScriptableObject
    {
        public string NoteID;
        public string NoteContents;
    }
}

