using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    public static SoundManager Instance { get; private set; }

    [SerializeField] AudioClipRefsSO audioClipRefsSO;

    private float volume = 1f;

    private void Awake()
    {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
    }

    private void CuttingCounter_OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefsSO.chop, cuttingCounter.transform.position);
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipRefsSO.objectDrop, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipRefsSO.objectDrop, baseCounter.transform.position);
    }

    private void Player_OnPickedSomething(object sender, EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickup, Player.Instance.transform.position);
    }

    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
        Vector3 position = DeliveryCounter.Instance.transform.position;
        PlaySound(audioClipRefsSO.deliveryFail, position);
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
    {
        Vector3 position = DeliveryCounter.Instance.transform.position;
        PlaySound(audioClipRefsSO.deliverySuccess, position);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volumn = 1f)
    {
        AudioClip audioClip = audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)];
        PlaySound(audioClip, position, volumn);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volumn = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumn);
    }

    public void PlayFootstepSound(Vector3 position, float volumnMultiplier = 1f)
    {
        PlaySound(audioClipRefsSO.footstep, position, volumnMultiplier * volume);
    }

    public void ChangeVollumn()
    {
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

   public float GetVollumn()
    {
        return volume;
    }
}
