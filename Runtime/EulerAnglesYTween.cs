using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class EulerAnglesYTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return component.eulerAngles.y;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) {
      var eulerAngles = component.eulerAngles;
      eulerAngles.y = value;
      component.eulerAngles = eulerAngles;
    }
  }
}