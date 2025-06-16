using System.Collections;
using HorrorGame.Main;
using TMPro;
using UnityEngine;

namespace HorrorGame.UI
{
    public class UIService : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI suggestionText;
        [SerializeField] private TextMeshProUGUI notesText;
        [SerializeField] private GameObject suggestionsObject;
        [SerializeField] private GameObject notesObject;

        void Start()
        {
            EventService.Instance.SetSuggestionText.AddListener(ShowSuggestionText);
            EventService.Instance.SetNotesText.AddListener(NotesText);
            EventService.Instance.OpenNotesText.AddListener(OpenNotes);
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

        public void CloseNotes()
        {
            notesObject.SetActive(false);
        }

        private IEnumerator HideText(GameObject gameObject)
        {
            yield return new WaitForSeconds(3f);
            gameObject.SetActive(false);
        }

        void OnDisable()
        {
            EventService.Instance.SetSuggestionText.RemoveListener(ShowSuggestionText);
            EventService.Instance.SetNotesText.RemoveListener(NotesText);
            EventService.Instance.OpenNotesText.RemoveListener(OpenNotes);
        }

    }

}

