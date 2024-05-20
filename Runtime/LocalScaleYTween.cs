using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalScaleYTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return component.localScale.y;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) {
      var localScale = component.localScale;
      localScale.y = value;
      component.localScale = localScale;
    }
  }
}