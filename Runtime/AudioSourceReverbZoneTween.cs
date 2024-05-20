using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourceReverbZoneMixTween : Tween<AudioSource, float> {
    public sealed override float Current(AudioSource component) {
      return component.reverbZoneMix;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(AudioSource component, float value) {
      component.reverbZoneMix = value;
    }
  }
}