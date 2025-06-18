using System.Collections;
using System.Collections.Generic;
using HorrorGame.Items;
using UnityEngine;

namespace HorrorGame.Mother
{
    public class MotherView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem smokeparticle;
        [SerializeField] private GameObject motherPrefab;
        [SerializeField] private GameObject note;

        private float timer = 1f;

        private void OnTriggerEnter(Collider other)
        {
            smokeparticle.Play();

            if (motherPrefab != null)
            {
                motherPrefab.SetActive(true);
                Destroy(gameObject, timer);
            }
            else if (note != null)
            {
                note.SetActive(true);
            }

        }
    }
}

