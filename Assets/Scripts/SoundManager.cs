using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;

   private void Awake()
   {
      instance = this;
   }

   public AudioSource clickSound;
   public AudioSource clickUpSound;

   public void PlaySound(AudioSource source)
   {
      source.Play();
   }
}
