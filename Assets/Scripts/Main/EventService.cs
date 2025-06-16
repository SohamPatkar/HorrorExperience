using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using UnityEngine;

namespace HorrorGame.Main
{
    public class EventService
    {
        private static EventService instance;

        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }

        public EventController<IInteractable> OnRemoveItem { get; private set; }

        public EventService()
        {
            OnRemoveItem = new EventController<IInteractable>();
        }

    }
}


