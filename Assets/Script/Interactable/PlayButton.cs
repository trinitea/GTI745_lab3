using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animation))]
public class PlayButton : MonoBehaviour, IInteractable {

    [SerializeField]
    private string turningOnAnimationName;
    [SerializeField]
    private string turningOffAnimationName;
    
    private Animation anim;

	private OrchestraController orchestraController;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        orchestraController = GameObject.FindGameObjectWithTag("GameController").GetComponent<OrchestraController>();
    }

    #region Interactable Interface

    public InteractableType GetInteractableType()
    {
        return InteractableType.PARTY;
    }

    public void OnInteract()
    {
        SwapState();
    }

    public void OnLookAtEnd(PointerEventData ped)
    {
        //throw new NotImplementedException();
    }

    public void OnLookAtStart(PointerEventData ped)
    {
        //throw new NotImplementedException();
    }

    public string DebugText()
    {
        return gameObject.ToString();
    }

    #endregion

	private void SwapState ()
	{
        if (orchestraController.isPlaying)
        {
            anim.Play(turningOffAnimationName);
        }
        else
        {
            anim.Play(turningOnAnimationName);
        }

        orchestraController.TooglePlaying();
	}

}
