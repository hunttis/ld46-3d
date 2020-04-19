using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    private AudioSource Empty;
    private AudioSource Ambience;
    private AudioSource PartABass;
    private AudioSource PartAFemaleSinger;
    private AudioSource PartAMaleSinger;
    private AudioSource PartBDrums;
    private AudioSource PartBBass;
    private AudioSource PartBBlip;
    private AudioSource PartCAmbience;
    private AudioSource PartCDrums;
    private AudioSource PartCBass;
    private AudioSource PartCMelody;
    private AudioSource PartCBreaks;
    private AudioSource PartCBlip;
    private AudioSource PartCBassdrum;
    private AudioSource PartCBlip2;

    private AudioSource[] Player;
    private int CurrentDangerLevel;
    private int StayedInCurrentDangerLevel;

    public int DangerLevel;

    void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        Empty = audioSources[0];
        Ambience = audioSources[1];
        PartABass = audioSources[2];
        PartAFemaleSinger = audioSources[3];
        PartAMaleSinger = audioSources[4];
        PartBDrums = audioSources[5];
        PartBBass = audioSources[6];
        PartBBlip = audioSources[7];
        PartCDrums = audioSources[8];
        PartCBass = audioSources[9];
        PartCMelody = audioSources[10];
        PartCBreaks = audioSources[11];
        PartCBlip = audioSources[12];
        PartCBassdrum = audioSources[13];
        PartCBlip2 = audioSources[14];

        Player = null;

        // Start playing
        PlayAmbience();
        PlayTracks();
    }

    void Update()
    {
        PlayAmbience();
        PlayTracks();
    }

    public void SetDangerLevel(int dangerLevel)
    {
        DangerLevel = dangerLevel;
    }

    private void PlayAmbience()
    {
        if (Ambience.isPlaying == false && CurrentDangerLevel != 0)
        {
            Ambience.Play();
        }
    }

    private void PlayTracks()
    {
        if (Player == null || Player[0].isPlaying == false)
        {
            // Check if danger level was changed
            if (DangerLevel != CurrentDangerLevel)
            {
                CurrentDangerLevel = DangerLevel;
                Debug.Log("CurrentDangerLevel = " + CurrentDangerLevel);
                StayedInCurrentDangerLevel = 0;
            }
            else if (StayedInCurrentDangerLevel == 10)
            {
                StayedInCurrentDangerLevel = 0;
            }
            else
            {
                StayedInCurrentDangerLevel += 1;
            }
            Debug.Log("StayedInCurrentDangerLevel = " + StayedInCurrentDangerLevel);

            // Stop all audio sources
            if (Player != null)
            {
                foreach (AudioSource audioSource in Player)
                {
                    if (audioSource.isPlaying == true)
                    {
                        audioSource.Stop();
                    }
                }
            }

            // Create list of new audio sources to be played
            List<AudioSource> player = new List<AudioSource>();
            if (CurrentDangerLevel == 1)
            {
                Debug.Log("Adding PartABass");
                player.Add(PartABass);

                if (StayedInCurrentDangerLevel > 1 && StayedInCurrentDangerLevel < 9)
                {
                    Debug.Log("Adding PartAFemaleSinger");
                    player.Add(PartAFemaleSinger);
                }

                if (StayedInCurrentDangerLevel > 3 && StayedInCurrentDangerLevel < 7)
                {
                    Debug.Log("Adding PartAMaleSinger");
                    player.Add(PartAMaleSinger);
                }
            }
            else if (CurrentDangerLevel == 2)
            {
                Debug.Log("Adding PartBDrums");
                player.Add(PartBDrums);
                Debug.Log("Adding PartAFemaleSinger");
                player.Add(PartAFemaleSinger);
                Debug.Log("Adding PartAMaleSinger");
                player.Add(PartAMaleSinger);

                if (StayedInCurrentDangerLevel > 1 && StayedInCurrentDangerLevel < 9)
                {
                    Debug.Log("Adding PartBBass");
                    player.Add(PartBBass);
                }

                if (StayedInCurrentDangerLevel > 5 && StayedInCurrentDangerLevel < 7)
                {
                    Debug.Log("Adding PartBBlip");
                    player.Add(PartBBlip);
                }
            }
            else if (CurrentDangerLevel == 3)
            {
                if (StayedInCurrentDangerLevel < 2)
                {
                    Debug.Log("Adding PartCDrums");
                    player.Add(PartCDrums);
                    Debug.Log("Adding PartCBass");
                    player.Add(PartCBass);
                    Debug.Log("Adding PartCMelody");
                    player.Add(PartCMelody);
                }
                else if (StayedInCurrentDangerLevel < 4)
                {
                    Debug.Log("Adding PartCDrums");
                    player.Add(PartCDrums);
                    Debug.Log("Adding PartCBass");
                    player.Add(PartCBass);
                    Debug.Log("Adding PartCMelody");
                    player.Add(PartCMelody);
                    if (StayedInCurrentDangerLevel == 2)
                    {
                        Debug.Log("Adding PartCBlip");
                        player.Add(PartCBlip);
                    }
                    else
                    {
                        Debug.Log("Adding PartCBlip2");
                        player.Add(PartCBlip2);
                    }
                }
                else if (StayedInCurrentDangerLevel < 6)
                {
                    if (StayedInCurrentDangerLevel == 5)
                    {
                        Debug.Log("Adding PartCBassdrum");
                        player.Add(PartCBassdrum);
                    }
                    Debug.Log("Adding PartCBreaks");
                    player.Add(PartCBreaks);
                    Debug.Log("Adding PartCBass");
                    player.Add(PartCBass);
                }
                else if (StayedInCurrentDangerLevel < 8)
                {
                    Debug.Log("Adding PartCDrums");
                    player.Add(PartCDrums);
                    Debug.Log("Adding PartCBreaks");
                    player.Add(PartCBreaks);
                    Debug.Log("Adding PartCBass");
                    player.Add(PartCBass);
                    Debug.Log("Adding PartCMelody");
                    player.Add(PartCMelody);
                    if (StayedInCurrentDangerLevel == 2)
                    {
                        Debug.Log("Adding PartCBlip");
                        player.Add(PartCBlip);
                    }
                    else
                    {
                        Debug.Log("Adding PartCBlip2");
                        player.Add(PartCBlip2);
                    }
                }
                else
                {
                    Debug.Log("Adding PartCMelody");
                    player.Add(PartCMelody);
                }
            }
            else
            {
                Debug.Log("Adding Empty");
                player.Add(Empty);
            }

            Player = player.ToArray();

            // Start new audio sources
            foreach (AudioSource audioSource in Player)
            {
                audioSource.Play();
            }
        }
    }
}