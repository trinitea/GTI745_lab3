using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrchestraEditor : MonoBehaviour {

    private List<Instrument> instruments;
    private Instrument currentInstrument;

	// Use this for initialization
	void Start () {
		instruments = FindObjectsOfType<Instrument>().ToList();
        
    }

    public void changeInstrument(Instrument instrument)
    {
        if (currentInstrument == instrument || !instruments.Contains(instrument)) return;

        currentInstrument = instrument;

        // set grid
        // set color
    }

    public void triggerGrid(int x, int y)
    {

    }
}
