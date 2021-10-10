using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Vector2 pitchRange;
    [SerializeField] private Vector2 volumeRange;

    public void PlayStep()
    {
        //if (audioSource.isPlaying)
        //    return;

        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        audioSource.volume = Random.Range(volumeRange.x, volumeRange.y);

        audioSource.Play();
    }
}
