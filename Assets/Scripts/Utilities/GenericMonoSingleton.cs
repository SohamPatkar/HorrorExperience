using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HorrorGame.Utilities
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }

        void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}


