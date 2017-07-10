using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrchestraEditor : MonoBehaviour {

    private List<InteractableImage> instruments; // the images contains the instrument
    private Instrument currentInstrument;

	// Use this for initialization
	void Start () {
		List<InteractableImage> allInteractableImages = FindObjectsOfType<InteractableImage>().ToList();
        
    }

    public void editInstrument(Instrument instrument)
    {
        if (currentInstrument == instrument) return;

        foreach (InteractableImage image in instruments)
        {
            image.SetSelected(image.GetInstrument() == instrument);
        }

        currentInstrument = instrument;

        // set grid


        // set color
    }

    public void triggerGrid(int x, int y)
    {

    }
}
