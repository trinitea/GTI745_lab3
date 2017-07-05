using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PianoKeyScript : MonoBehaviour {

	public float semiToneOffset = 0f;

	public float Anote = -4f;  
	public float Bnote = -2f; 
	public float Cnote = 0f;  
	public float Dnote = 2f;  
	public float Enote = 4f; 
	public float Fnote = 6f; 
	public float Gnote = 8f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		PlayNote ();
	}

	void PlayNote(){
		AudioSource audioSource = GetComponent<AudioSource> ();
		audioSource.pitch = Mathf.Pow(2f, semiToneOffset / 12.0f);
		audioSource.Play ();
	}

	void SetSemiToneOffset(float newSemiToneOffset){
		semiToneOffset = newSemiToneOffset;
	}
}
