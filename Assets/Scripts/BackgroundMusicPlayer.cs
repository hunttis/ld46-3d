using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    private const int Empty = 0;
    private const int Ambience = 1;
    private const int PartABass = 2;
    private const int PartAFemaleSinger = 3;
    private const int PartAMaleSinger = 4;
    private const int PartBDrums = 5;
    private const int PartBBass = 6; // 2x
    private const int PartBBlip = 7; // 4x
    private const int PartCDrums = 8;
    private const int PartCBass = 9; // 2x
    private const int PartCMelody = 10; // 2x
    private const int PartCBreaks = 11;
    private const int PartCBlip = 12; // 4x
    private const int PartCBassdrum = 13; // 2x

    private AudioSource[] Sounds;
    private AudioSource Sync;
    private int Part;
    private int Step;
    private List<List<List<int>>> Sequencer;

    public int DangerLevel;

    void Start()
    {
        Sounds = GetComponents<AudioSource>();
        Sequencer = new List<List<List<int>>>();

        Sequencer.Add(new List<List<int>>
        {
            new List<int> { Empty }
        });

        Sequencer.Add(new List<List<int>>
        {
            new List<int> { Empty, PartABass },
            new List<int> { Empty, PartABass, PartAFemaleSinger },
            new List<int> { Empty, PartABass, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { Empty, PartABass, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { Empty, PartABass, PartAMaleSinger },
        });

        Sequencer.Add(new List<List<int>>
        {
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger, PartBBass },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger, PartBBass, PartBBlip },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger, PartBBass },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger },
            new List<int> { PartBDrums, PartAFemaleSinger, PartAMaleSinger }
        });

        Sequencer.Add(new List<List<int>>
        {
            new List<int> { PartCDrums, PartCBass, PartCMelody },
            new List<int> { PartCDrums },
            new List<int> { PartCDrums, PartCBass, PartCMelody, PartCBlip },
            new List<int> { PartCDrums },
            new List<int> { PartCDrums, PartCBass, PartCMelody },
            new List<int> { PartCDrums },
            new List<int> { PartCBreaks, PartCBass, PartCMelody },
            new List<int> { PartCBreaks, PartCBassdrum },
            new List<int> { Empty, PartCBreaks, PartCBass, PartCMelody, PartCBlip },
            new List<int> { PartCDrums, PartCBreaks },
            new List<int> { PartCDrums, PartCBass, PartCMelody },
            new List<int> { PartCDrums }
        });

        Sequencer.Add(new List<List<int>>
        {
            new List<int> { PartCBassdrum }
        });

        // Initially sync to first item, in first part & first sequence
        Sync = Sounds[Sequencer[0][0][0]];

        // Start ambience
        PlayAmbience();

        // Star sequencer
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
        if (Sounds[Ambience].isPlaying == false && Part != 0)
        {
            Sounds[Ambience].Play();
        }
    }

    private void PlayTracks()
    {
        if (Sync.isPlaying == false)
        {
            // Check if danger level was changed
            if (DangerLevel != Part)
            {
                Part = DangerLevel;
                Step = 0;
            }
            else
            {
                Step += 1;
            }

            if (Sequencer[Part].Count == Step)
            {
                Step = 0;
            }

            Debug.Log("Playing Sequencer Part " + Part + "/" + (Sequencer.Count - 1) + ", Step " + Step + "/" + (Sequencer[Part].Count - 1));

            // Set sync to current part & current step first item
            Sync = Sounds[Sequencer[Part][Step][0]];

            // Play all audio sources in part
            foreach (int sound in Sequencer[Part][Step])
            {
                Sounds[sound].Play();
            }
        }
    }
}