using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourcePanTween : Tween<AudioSource, float> {
    public sealed override float Current(AudioSource component) {
      return component.panStereo;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(AudioSource component, float value) {
      component.panStereo = value;
    }
  }
}