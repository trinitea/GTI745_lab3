using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animation))]
public class SwitchOnOff : MonoBehaviour, IInteractable {

    [SerializeField]
    private string turningOnAnimationName;
    [SerializeField]
    private string turningOffAnimationName;

    private SwitchState state;
    private Animation anim;

	public Instrument instrument;

    public List<Light> spotLights;

    enum SwitchState
    {
        OFF,
        ON
    }

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();

        foreach(Light light in spotLights)
        {
            light.color = instrument.glowColor;
            light.enabled = instrument.activated;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    #region Interactable Interface

    public InteractableType GetInteractableType()
    {
        return InteractableType.PHYSICAL;
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
		switch (state) {
		    case SwitchState.OFF:
			    anim.Play (turningOnAnimationName);
			    state = SwitchState.ON;
			    instrument.activated = true;
                turnOnOff(true);
                break;

		    case SwitchState.ON:
			    anim.Play (turningOffAnimationName);
			    state = SwitchState.OFF;
                instrument.activated = false;
                turnOnOff(false);
                break;
		}
	}

    private void turnOnOff(bool state)
    {
        foreach(Light light in spotLights)
        {
            light.enabled = state;
        }
    }

}
