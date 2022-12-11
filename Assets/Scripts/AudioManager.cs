using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Jump, Pickup, GameOver, LevelUp;

    public static AudioClip JumpSound, PickupSound, GameOverSound, LevelUpSound;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        JumpSound = Jump;
        PickupSound = Pickup;
        GameOverSound = GameOver;
        LevelUpSound = LevelUp;
    }

    public static void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            case "Jump":
                audioSrc.PlayOneShot(JumpSound, 1f);
                break;
            case "Pickup":
                audioSrc.PlayOneShot(PickupSound, 1f);
                break;
            case "GameOver":
                audioSrc.PlayOneShot(GameOverSound, 1f);
                break;
            case "LevelUp":
                audioSrc.PlayOneShot(LevelUpSound, 1f);
                break;
        }
    }
}
