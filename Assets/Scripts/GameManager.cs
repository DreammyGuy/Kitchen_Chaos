using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;

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
    private float playingTimer = 5f;

    private void Awake()
    {
        Instance = this;

        state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;

                Debug.Log("Waiting to start: " + waitingToStartTimer);

                if (waitingToStartTimer < 0)
                {
                    state = State.CountingToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountingToStart:
                // Waiting for countdown to finish
                countingToStartTimer -= Time.deltaTime;

                Debug.Log("Counting to start: " + countingToStartTimer);

                if (countingToStartTimer < 0)
                {
                    state = State.Playing;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                // Game logic goes here
                playingTimer -= Time.deltaTime;

                Debug.Log("Playing: " + playingTimer);

                if (playingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                // Handle game over logic
                Debug.Log("Game Over!");

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
}
