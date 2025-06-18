using System;
using UnityEngine;

namespace HorrorGame.Sounds
{
    public enum SoundType
    {
        BackgroundMusic,
        Changed
    }

    [Serializable]
    public class Sound
    {
        public SoundType audioType;
        public AudioClip audioClip;
    }


    public class SoundManager : MonoBehaviour
    {
        [Header("Audios Array")]
        [SerializeField] private Sound[] sounds;

        [Header("Audio Source")]
        [SerializeField] private AudioSource sfxSource;
        [SerializeField] private AudioSource musicSource;

        private static SoundManager instance;
        public static SoundManager Instance { get { return instance; } }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        void Start()
        {
            SoundManager.Instance.PlayBackgroundMusic(SoundType.BackgroundMusic);
        }

        public void PlayBackgroundMusic(SoundType soundType)
        {
            AudioClip musicClip = GetClip(soundType);
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        private AudioClip GetClip(SoundType soundType)
        {
            Sound sound = Array.Find(sounds, sound => sound.audioType == soundType);
            return sound.audioClip;
        }

        public void PlaySfx(SoundType soundType)
        {
            AudioClip musicClip = GetClip(soundType);
            sfxSource.PlayOneShot(musicClip);
        }
    }
}


