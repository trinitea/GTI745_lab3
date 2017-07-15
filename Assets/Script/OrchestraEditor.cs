using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrchestraEditor : MonoBehaviour {

    private List<InteractableImage> instruments; // the images contains the instrument
    public Instrument currentInstrument { get; private set; }

    public InteractableToggle[,] grid = new InteractableToggle[10,5];

    [SerializeField]
    private Image powerIndicator;

    public List<Image> images;
    public List<Light> lights;

    // Use this for initialization
    void Start () {
		//List<InteractableImage> allInteractableImages = FindObjectsOfType<InteractableImage>().ToList();
        instruments = FindObjectsOfType<InteractableImage>().ToList();

        editInstrument(instruments[0].GetInstrument());
    }

    void Update()
    {
        powerIndicator.enabled = !currentInstrument.activated;
    }

    public void editInstrument(Instrument instrument)
    {
        if (currentInstrument == instrument) return;

        foreach (InteractableImage image in instruments)
        {
            image.SetSelected(image.GetInstrument() == instrument);
        }

        currentInstrument = instrument;

        // set grid and color
        for (int x = 0; x < 10; x ++)
        {
            for (int y = 0; y < 5; y ++)
            {
                grid[x, y].SetState(currentInstrument.GetNoteState(x, y));
                grid[x, y].SetColor(currentInstrument.glowColor);
            }
        }

        // Images
        foreach(Image image in images)
        {
            image.sprite = currentInstrument.icon;
            image.color = currentInstrument.glowColor;
        }

        // Lights
        foreach (Light light in lights)
        {
            light.color = currentInstrument.glowColor;
        }
    }

    // crappy function
    public void registerToggle(InteractableToggle toggle, int x,int y)
    {
        grid[x, y] = toggle;
    }

    public void triggerGrid(int x, int y)
    {
        currentInstrument.ToggleNote(x, y);
    }
}
