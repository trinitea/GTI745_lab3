using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableImage : Image, IInteractable {

    [SerializeField]
    private Instrument instrument;

    [SerializeField]
    private OrchestraEditor editor;

    [SerializeField]
    private Image subImage;

    void Start()
    {
        base.Start();

        subImage.sprite = instrument.icon;
    }

    public Instrument GetInstrument()
    {
        return instrument;
    }

    public void SetSelected(bool selected)
    {
        if (instrument == null) return;

        if(selected)
        {
            color = instrument.glowColor;
            subImage.color = instrument.glowColor;
        }
        else
        {
            color = new Color(1.0f, 1.0f, 1.0f, 0.7843f);
            subImage.color = new Color(1.0f, 1.0f, 1.0f, 0.7843f);
        }
    }

    public string DebugText()
    {
        return "Interactable Image";
    }

    public InteractableType GetInteractableType()
    {
        return InteractableType.UI;
    }

    public void OnInteract()
    {
        if (editor == null || instrument == null) return;

        editor.editInstrument(instrument);
    }

    public void OnLookAtEnd(PointerEventData ped)
    {
        
    }

    public void OnLookAtStart(PointerEventData ped)
    {
        
    }
}
