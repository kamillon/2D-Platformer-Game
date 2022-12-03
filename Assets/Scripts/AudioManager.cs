using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip Jump, Banana;

    public static AudioClip JumpSound, BananaSound;
    static AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        JumpSound = Jump;
        BananaSound = Banana;
    }

    public static void PlaySound(string soundClip)
    {
        switch (soundClip)
        {
            case "Jump":
                audioSrc.PlayOneShot(JumpSound, 1f);
                break;
            case "Banana":
                audioSrc.PlayOneShot(BananaSound, 1f);
                break;
        }
    }
}
