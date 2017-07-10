using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableToggle : Image, IInteractable {

    public static Image normalBackground;
    public static Image activatedBackground;

    public bool activated { get; private set; }

    [SerializeField]
    private OrchestraEditor editor;

    public void Toogle()
    {
        activated = !activated;

        if (activated)
        {
            sprite = activatedBackground.sprite;
        }
        else
        {
            sprite = normalBackground.sprite;
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
        //if (editor == null || instrument == null) return;

        //editor.editInstrument(instrument);
    }

    public void OnLookAtEnd(PointerEventData ped)
    {
        
    }

    public void OnLookAtStart(PointerEventData ped)
    {
        
    }
}
