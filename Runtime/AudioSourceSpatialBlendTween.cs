using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourceSpatialBlendTween : Tween<AudioSource, float> {
    protected sealed override float Current(AudioSource component) {
      return component.spatialBlend;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(AudioSource component, float value) {
      component.spatialBlend = value;
    }
  }
}