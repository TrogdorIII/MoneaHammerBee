using UnityEngine;
using System.Collections;

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine.Networking;

    public class GameManager : NetworkBehaviour
    {
        public static GameManager instance;

        public bool roundInProgress;
        public float roundTime;
        public float roundTimeLeft;

        public int beeScore;
        public PlayerScore playerScore1;
        public PlayerScore playerScore2;

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
            roundTimeLeft = roundTime;

            playerScore1 = new PlayerScore(0, true);
            playerScore2 = new PlayerScore(1, false);
            if (playerScore2.isHuman == playerScore1.isHuman)
                playerScore2.isHuman = !playerScore1.isHuman;


        }

        void Start()
        {

        }

        void Update()
        {
            if (roundInProgress)
                CountdownRoundTimer();

            if (roundTimeLeft <= 0)
            {
                EndRound();
            }
        }

        #region Rounds
        void CountdownRoundTimer()
        {
            roundTimeLeft -= Time.deltaTime;
        }

        void StartRound()
        {
            roundTimeLeft = roundTime;
            roundInProgress = true;
        }

        void EndRound()
        {
            roundInProgress = false;
        }
        #endregion

        #region Win/Loss
        void DecideWinner()
        {
            if (playerScore1.score > playerScore2.score)
            {
                print("Player 1 Wins");
            }
            else if (playerScore1.score < playerScore2.score)
            {
                print("Player 2 Wins");
            }
            else
            {
                print("Tie");
            }
        }
        #endregion

        void SwapPlayerPrefabs()
        {
            playerScore1.SwapPrefab();
            playerScore2.isHuman = !playerScore1.isHuman;
        }
    }
}

public class PlayerScore
{
    public int index;
    public float score;
    public bool isHuman = false;

    public PlayerScore()
    {
        index = 0;
        score = 0;
    }

    public PlayerScore(int index)
    {
        this.index = index;
        score = 0;
    }

    public PlayerScore(int index, bool isHuman)
    {
        this.index = index;
        this.isHuman = isHuman;
    }

    public void AddScore(float value)
    {
        score += value;
    }

    public void SetScore(float value)
    {
        score = value;
    }

    public void SwapPrefab()
    {
        isHuman = !isHuman;
    }
}