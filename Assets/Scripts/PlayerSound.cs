using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float walkSoundTimer;
    private float walkSoundTimerMax = 0.1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        walkSoundTimer -= Time.deltaTime;
        if (walkSoundTimer < 0f)
        {
            walkSoundTimer = walkSoundTimerMax;

            if (player.IsWalking())
            {
                Vector3 position = player.transform.position;

                float volume = 1f;
                SoundManager.Instance.PlayFootstepSound(position, volume);
            }
        }
    }
}
