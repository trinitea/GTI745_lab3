using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

    public string name;
    public float masterVolume = 1.0f;

    public bool initialized { get; private set; }
    public bool activated { get; set; }

    public Color glowColor;
    public Sprite icon;

    [SerializeField]
    private AudioSource[] soundSources;

    private bool[,] noteMatrix;

    public int nbNotesInRange { get; private set; }
    public int rangeSize { get; private set; }

	// Use this for initialization

    public void Initialize(int timeLineSize)
    {
        if (initialized) return;

        rangeSize = timeLineSize;
        nbNotesInRange = soundSources.Length;

        noteMatrix = new bool[rangeSize, nbNotesInRange];

        for (int x = 0; x < rangeSize; x++)
            for (int y = 0; y < nbNotesInRange; y++)
                noteMatrix[x, y] = false;

        foreach(AudioSource source in soundSources)
        {
            source.volume = masterVolume;
        }

        activated = false;
    }

    public void PlayNotes(int part)
    {
        if (!activated) return;

        for (int y = 0; y < nbNotesInRange; y ++)
        {
            if (noteMatrix[part, y])
            {
                soundSources[y].Play();
            }
        }
    }

    public void PlayArbitraryNote(int note)
    {
        if (note < 0 || note >= soundSources.Length) return;
        soundSources[note].Play();
    }

    public bool GetNoteState(int x, int y)
    {
        if (x < 0 || x >= rangeSize || y < 0 || y >= nbNotesInRange) return false;

        return noteMatrix[x, y];
    }

    public void ToggleNote(int x, int y)
    {
        noteMatrix[x, y] = !noteMatrix[x, y];
    }
}
