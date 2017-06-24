using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTest : MonoBehaviour {

    public float semitone_offset = 0;

    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        PlayNote();
    }

    void OnCollisionEnter()
    {
        PlayNote();
    }

    void PlayNote()
    {
        //audioSource.pitch = Mathf.Pow(2f, semitone_offset / 12.0f);

        audioSource.pitch = Random.Range(0.0f, 3.0f);

        audioSource.Play();
    }
}
