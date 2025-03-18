using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class Sound : MonoBehaviour
{
    public static Sound instance;//Design pattern: Singleton
    private void Awake()
    {
      instance = this;
    }
  public void PlaySound(string clipName, float volumMultipler)
  {
   AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();//AudioClip: none
   audioSource.volume *= volumMultipler;
   audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clipName,typeof(AudioClip)));

  }

    internal void PlaySound(string v)
    {
        throw new NotImplementedException();
    }
}
