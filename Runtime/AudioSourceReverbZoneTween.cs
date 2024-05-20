using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourceReverbZoneMixTween : Tween<AudioSource, float> {
    protected sealed override float Current(AudioSource component) {
      return component.reverbZoneMix;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(AudioSource component, float value) {
      component.reverbZoneMix = value;
    }
  }
}