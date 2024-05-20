using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalScaleXTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.localScale.x;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var localScale = component.localScale;
      localScale.x = value;
      component.localScale = localScale;
    }
  }
}