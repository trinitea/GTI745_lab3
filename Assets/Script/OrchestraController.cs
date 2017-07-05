using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum InstrumentType
{
    PIANO,
    GUITAR,
    BATTERY
}

public class OrchestraController : MonoBehaviour {

    public float timeBetweenNotes;

    [Tooltip("Not used for now")]
    public int timeLineSize;

    private bool isPlaying;
    private List<Instrument> instruments;

    private int part; // experimental

    private float timeSinceLastNote;
    private float currentTimeline;


	// Use this for initialization
	void Start () {
        part = 0;
        timeSinceLastNote = currentTimeline = 0.0f;
        instruments = FindObjectsOfType<Instrument>().ToList();

        for (int i = 0; i < instruments.Count(); i ++)
        {
            instruments[i].Initialize(timeLineSize);
        }

        isPlaying = true; // remove this
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            if(timeSinceLastNote >= timeBetweenNotes)
            {
                foreach (Instrument instrument in instruments) instrument.PlayNotes(part);
                part++;
                timeSinceLastNote -= timeBetweenNotes;

                if (part == timeLineSize) part = 0;
            }

            timeSinceLastNote += Time.deltaTime;
        }
	}

    public void StartPlaying()
    {
        isPlaying = true;
    }

    public void StopPlaying()
    {
        isPlaying = false;

    }

    enum OrchestraStatus
    {
        PLAYING,
        PAUSED,
        STOPPED
    }
}
