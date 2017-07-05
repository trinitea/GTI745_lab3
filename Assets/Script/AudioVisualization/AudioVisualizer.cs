using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class AudioVisualizer : MonoBehaviour {

	AudioSource audioSource;
	public static float[] audioSamples = new float[512];
	public int AUDIO_CHANNEL = 0;


	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		GetSpectrumAudioSource ();
	}

	void GetSpectrumAudioSource()
	{
		audioSource.GetSpectrumData (audioSamples, AUDIO_CHANNEL, FFTWindow.Blackman);
	}
}
