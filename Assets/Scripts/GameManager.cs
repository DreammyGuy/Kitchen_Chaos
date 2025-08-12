using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;

    private enum State
    {
        WaitingToStart,
        CountingToStart,
        Playing,
        GameOver
    }

    private State state;

    private float waitingToStartTimer = 1f;
    private float countingToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;
    private bool isGamePaused = false;


    private void Awake()
    {
        Instance = this;

        state = State.WaitingToStart;
    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;

                if (waitingToStartTimer < 0)
                {
                    state = State.CountingToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountingToStart:
                // Waiting for countdown to finish
                countingToStartTimer -= Time.deltaTime;

                if (countingToStartTimer < 0)
                {
                    state = State.Playing;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);

                    gamePlayingTimer = gamePlayingTimerMax; // Reset the playing timer
                }
                break;
            case State.Playing:
                // Game logic goes here
                gamePlayingTimer -= Time.deltaTime;

                if (gamePlayingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                // Handle game over logic

                break;
        }
    }

    public bool IsGamePlaying()
    {
        return state == State.Playing;
    }

    public bool IsGameCountingToStart()
    {
        return state == State.CountingToStart;
    }

    public float GetCountingToStartTimer()
    {
        return countingToStartTimer;
    }

    public bool IsGameOver()
    {
        return state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {
            Time.timeScale = 0f;

            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }
}
