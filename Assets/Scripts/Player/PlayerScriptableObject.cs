using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using UnityEngine;

namespace HorrorGame.SO
{
    [CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "PlayerSO")]
    public class PlayerScriptableObject : ScriptableObject
    {
        public string Name;
        public List<IInteractable> Items = new List<IInteractable>();
        public int MovementSpeed;
    }
}


