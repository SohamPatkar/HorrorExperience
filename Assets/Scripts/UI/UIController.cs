using System.Collections;
using HorrorGame.Main;
using TMPro;
using UnityEngine;

namespace HorrorGame.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI suggestionText;
        [SerializeField] private TextMeshProUGUI notesText;
        [SerializeField] private GameObject suggestionsObject;
        [SerializeField] private GameObject notesObject;
        [SerializeField] private GameObject startMenu;
        [SerializeField] private GameObject interaction;
        [SerializeField] private GameObject GameEnd;

        void OnEnable()
        {
            EventService.Instance.SetSuggestionText.AddListener(SetSuggestionText);
            EventService.Instance.SetNotesText.AddListener(NotesText);
            EventService.Instance.OpenNotesText.AddListener(OpenNotes);
            EventService.Instance.ShowMainMenu.AddListener(ShowStartMenu);
            EventService.Instance.OnDoorOpen.AddListener(ShowGameEnd);
        }

        void OnDisable()
        {
            EventService.Instance.SetSuggestionText.RemoveListener(SetSuggestionText);
            EventService.Instance.SetNotesText.RemoveListener(NotesText);
            EventService.Instance.OpenNotesText.RemoveListener(OpenNotes);
            EventService.Instance.ShowMainMenu.RemoveListener(ShowStartMenu);
            EventService.Instance.OnDoorOpen.RemoveListener(ShowGameEnd);
        }

        private void ShowStartMenu()
        {
            SetUIState();
            startMenu.SetActive(true);
        }

        private void SetUIState()
        {
            EventService.Instance.OnStateChange.InvokeEvent(GameState.UI);
        }

        private void SetSuggestionText(string suggestion)
        {
            suggestionsObject.SetActive(true);
            suggestionText.text = suggestion;
            StartCoroutine(HideText(suggestionsObject));
        }

        private void NotesText(string note)
        {
            notesText.text = note;
        }

        private void OpenNotes()
        {
            SetUIState();
            notesObject.SetActive(true);
            suggestionsObject.SetActive(false);
            DisableInteractionUI();
        }

        private void StartInteractionUI()
        {
            interaction.SetActive(true);
        }

        private void DisableInteractionUI()
        {
            interaction.SetActive(false);
        }

        private void ShowGameEnd()
        {
            SetUIState();
            GameEnd.SetActive(true);
        }

        public void StartGameButton()
        {
            EventService.Instance.OnStartGame.InvokeEvent();
            StartInteractionUI();
            startMenu.SetActive(false);
        }

        public void CloseNotes()
        {
            notesObject.SetActive(false);
            EventService.Instance.OnStateChange.InvokeEvent(GameState.Gameplay);
            StartInteractionUI();
        }

        private IEnumerator HideText(GameObject gameObject)
        {
            yield return new WaitForSeconds(1.5f);
            gameObject.SetActive(false);
        }


    }

}

