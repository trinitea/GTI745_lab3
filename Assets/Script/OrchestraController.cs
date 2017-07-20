using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool isPlaying { get; private set; }
    private List<Instrument> instruments;

    private int part; // experimental

    private float timeSinceLastNote;
    private float currentTimeline;

    [SerializeField]
    private List<Image> playingNotifiers;

    [SerializeField]
    private AudioSource backgroundMusic;

    // TimeLine animation
    [SerializeField]
    private Image timeLine;

    private float pixelBetweenButton = 160.0f;
    private float startingX = -796.0f;
    private float endingX = 804.0f;
    private float currentX = -796.0f;

    void Awake()
    {
        part = 0;
        timeSinceLastNote = currentTimeline = 0.0f;
        instruments = FindObjectsOfType<Instrument>().ToList();

        for (int i = 0; i < instruments.Count(); i++)
        {
            instruments[i].Initialize(timeLineSize);
        }

        backgroundMusic.loop = true;
        backgroundMusic.Play();
    }
	// Use this for initialization
	void Start () {
        isPlaying = false;
        timeLine.enabled = false;

        timeLine.rectTransform.localPosition.Set(currentX, 0.0f, 0.0f);

        foreach(Image notifier in playingNotifiers)
        {
            notifier.enabled = false;
        }
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

            currentX += (Time.deltaTime / timeBetweenNotes) * pixelBetweenButton;
            if (currentX > endingX) currentX -= (endingX - startingX);
            timeLine.rectTransform.anchoredPosition = new Vector2(currentX, 0.0f);
        }

    }

    public void TooglePlaying()
    {
        if(isPlaying) StopPlaying();
        else StartPlaying();
    }

    private void StartPlaying()
    {
        isPlaying = true;
        timeLine.enabled = true;

        part = 0;

        timeSinceLastNote = currentTimeline = timeBetweenNotes / 2;
        timeLine.rectTransform.anchoredPosition = new Vector2(currentX = startingX, 0.0f);

        foreach (Image notifier in playingNotifiers)
        {
            notifier.enabled = true;
        }

        backgroundMusic.Stop();
    }

    private void StopPlaying()
    {
        isPlaying = false;
        
        timeLine.enabled = false;

        foreach (Image notifier in playingNotifiers)
        {
            notifier.enabled = false;
        }

        backgroundMusic.Play();
    }

    enum OrchestraStatus
    {
        PLAYING,
        PAUSED,
        STOPPED
    }
}
