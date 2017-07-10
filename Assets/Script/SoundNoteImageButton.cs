using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundNoteImageButton : MonoBehaviour {
    
    private string SoundNoteOn;
    private string SoundNoteOff;

    public Color activeNoteColor;
    public Color inactiveNoteColor;

    private Color currentNoteColor;
    private bool soundNoteState;

    // Use this for initialization
    void Start () {
        soundNoteState = false;
        GetComponent<Image>().color = inactiveNoteColor;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetNoteActiveColor() {

        //Add note
        if (soundNoteState == false) {
            soundNoteState = true;
            GetComponent<Image>().color = activeNoteColor;
        }

        //Remove note
        else {
            soundNoteState = false;
            GetComponent<Image>().color = inactiveNoteColor;
        }
        //soundNoteState = !soundNoteState;
    }
}
