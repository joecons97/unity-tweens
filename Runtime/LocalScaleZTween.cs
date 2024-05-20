using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalScaleZTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.localScale.z;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var localScale = component.localScale;
      localScale.z = value;
      component.localScale = localScale;
    }
  }
}