using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InteractableToggle : Image, IInteractable {

    public Sprite normalBackground;
    public Sprite activatedBackground;

    public bool activated { get; private set; }

    public int x;
    public int y;
    
    private OrchestraEditor editor;

    void Awake()
    {
        base.Awake();

        editor = GameObject.FindGameObjectWithTag("OrchestraEditor").GetComponent<OrchestraEditor>();
        editor.registerToggle(this, x, y);
    }
    
    public void Toogle()
    {
        SetState(!activated);
    }

    public void SetState(bool state)
    {
        activated = state;

        if (activated)
        {
            sprite = activatedBackground;
        }
        else
        {
            sprite = normalBackground;
        }
    }

    public void SetColor(Color newColor)
    {
        color = newColor;
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
        if (editor == null) return;

        editor.triggerGrid(x,y);
        SetState(editor.currentInstrument.GetNoteState(x, y));
    }

    public void OnLookAtEnd(PointerEventData ped)
    {
        
    }

    public void OnLookAtStart(PointerEventData ped)
    {
        
    }
}
