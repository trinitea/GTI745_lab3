using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument : MonoBehaviour {

    public string name;

    public bool initialized { get; private set; }
    public bool activated { get; set; }

    [SerializeField]
    private AudioSource[] soundSources;

    private bool[,] noteMatrix;

    private int nbNotesInRange = 5;
    private int rangeSize = 10;

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


        // test
        noteMatrix[0, 0] = true;
        noteMatrix[0, 1] = true;
        noteMatrix[0, 2] = true;
        noteMatrix[0, 3] = true;
        noteMatrix[0, 4] = true;
        noteMatrix[3,0] = true;
        noteMatrix[6, 1] = true;
        noteMatrix[6, 2] = true;
    }

    // Update is called once per frame
    /*
    void Update () {
		
	}
    */

    public void PlayNotes(int part)
    {
        for (int y = 0; y < nbNotesInRange; y ++)
        {
            if (noteMatrix[part, y])
            {
                soundSources[y].Play();
            }
        }
    }
}
