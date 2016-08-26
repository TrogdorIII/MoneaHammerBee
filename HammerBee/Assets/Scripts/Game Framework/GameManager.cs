using UnityEngine;
using System.Collections;

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine.Networking;

    public class GameManager : NetworkBehaviour
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