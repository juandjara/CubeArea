﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    public bool inGame = false;
    public AudioClip secondClip;

    // Use this for initialization
    void Start()
    {
        AudioSource bgMusic = gameObject.GetComponent<AudioSource>();

        if (PlayerPrefs.HasKey("MusicToggle"))
        {
            int playmusic = PlayerPrefs.GetInt("MusicToggle");
            if (playmusic == 0)
            {
                bgMusic.enabled = false;
            }
            else
            {
                bgMusic.enabled = true;
            }
        }
        if (inGame)
        {
            AudioClip originalClip = bgMusic.clip;
            AudioClip[] clips = { originalClip, secondClip };
            int index = Random.Range(0, (clips.Length - 1));
            AudioClip choosenClip = clips[index];

            bgMusic.clip = choosenClip;
        }
    }
}
