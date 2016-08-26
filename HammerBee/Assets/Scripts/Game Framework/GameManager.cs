using UnityEngine;
using System.Collections;

namespace Game
{
    using System.Collections.Generic;

    public class GameManager : MonoBehaviour
    {

        public static GameManager instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            InitGame();
        }

        void InitGame()
        {

        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}