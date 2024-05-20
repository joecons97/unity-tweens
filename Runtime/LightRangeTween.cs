using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LightRangeTween : Tween<Light, float> {
    public sealed override float Current(Light component) {
      return component.range;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Light component, float value) {
      component.range = value;
    }
  }
}