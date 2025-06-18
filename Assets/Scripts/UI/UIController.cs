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

        void OnEnable()
        {
            EventService.Instance.SetSuggestionText.AddListener(ShowSuggestionText);
            EventService.Instance.SetNotesText.AddListener(NotesText);
            EventService.Instance.OpenNotesText.AddListener(OpenNotes);
            EventService.Instance.ShowMainMenu.AddListener(ShowStartMenu);
        }

        void OnDisable()
        {
            EventService.Instance.SetSuggestionText.RemoveListener(ShowSuggestionText);
            EventService.Instance.SetNotesText.RemoveListener(NotesText);
            EventService.Instance.OpenNotesText.RemoveListener(OpenNotes);
            EventService.Instance.ShowMainMenu.RemoveListener(ShowStartMenu);
        }

        private void ShowStartMenu()
        {
            startMenu.SetActive(true);
        }

        private void ShowSuggestionText(string suggestion)
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
            notesObject.SetActive(true);
            StartCoroutine(HideText(notesObject));
        }

        public void StartGameButton()
        {
            EventService.Instance.OnStartGame.InvokeEvent();
            startMenu.SetActive(false);
        }

        public void CloseNotes()
        {
            notesObject.SetActive(false);
        }

        private IEnumerator HideText(GameObject gameObject)
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }


    }

}

