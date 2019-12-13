using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEffect {
  Click = 0,
  Deal,
  MoveCard,
  Shuffle
}

public class SoundEffects : MonoBehaviour {
  static SoundEffects instance;

  AudioSource [] sources;
  bool playSounds = true;

  public enum Effects : int {
    click = 0,
    die = 0
  };

  public static SoundEffects Instance()
  {
    return instance;
  }

  void Start()
  {
    instance = this;

    playSounds = PlayerPrefs.GetInt ("sounds", 1) != 0;

    List<AudioSource> ads = new List<AudioSource> ();
    List<string> sfx = new List<string> ();
    sfx.Add ("sfx/click");     // Click

    foreach (string s in sfx) {
      GameObject go = new GameObject (s);
      go.transform.SetParent (transform);
      AudioSource a = go.AddComponent<AudioSource> ();
      a.clip = Resources.Load<AudioClip> (s);
      ads.Add (a);
    }
    sources = ads.ToArray ();
  }

  public void Play(int effect)
  {
    if (!playSounds)
      return;

    AudioSource source = sources [effect];
    source.Play ();
  }

  public void PlayEffect(SoundEffects.Effects effect)
  {
    instance.Play ((int)effect);
  }

  public void ButtonClicked() {
    PlayEffect(Effects.click);
  }

}

