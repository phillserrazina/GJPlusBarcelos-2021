using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;
    private void Start() 
    {
        foreach (var source in sources)
        {
            source.Play();
        }
    }
}
