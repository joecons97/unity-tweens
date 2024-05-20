using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LightRangeTween : Tween<Light, float> {
    protected sealed override float Current(Light component) {
      return component.range;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Light component, float value) {
      component.range = value;
    }
  }
}