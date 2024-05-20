using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourcePanTween : Tween<AudioSource, float> {
    protected sealed override float Current(AudioSource component) {
      return component.panStereo;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(AudioSource component, float value) {
      component.panStereo = value;
    }
  }
}