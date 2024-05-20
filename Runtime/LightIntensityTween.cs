using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LightIntensityTween : Tween<Light, float> {
    protected sealed override float Current(Light component) {
      return component.intensity;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Light component, float value) {
      component.intensity = value;
    }
  }
}