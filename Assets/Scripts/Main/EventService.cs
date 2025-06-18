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
        public EventController<string> SetSuggestionText { get; private set; }
        public EventController<string> SetNotesText { get; private set; }
        public EventController<GameObject> SetNextTask { get; private set; }
        public EventController OpenNotesText { get; private set; }
        public EventController AddPuzzleCounter { get; private set; }
        public EventController DimLights { get; private set; }
        public EventController OnStartGame { get; private set; }
        public EventController ShowMainMenu { get; private set; }

        public EventService()
        {
            OnRemoveItem = new EventController<IInteractable>();
            SetNotesText = new EventController<string>();
            SetSuggestionText = new EventController<string>();
            SetNextTask = new EventController<GameObject>();
            OpenNotesText = new EventController();
            AddPuzzleCounter = new EventController();
            DimLights = new EventController();
            OnStartGame = new EventController();
            ShowMainMenu = new EventController();
        }

    }
}


