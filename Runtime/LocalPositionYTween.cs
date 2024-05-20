using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalPositionYTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.localPosition.y;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var localPosition = component.localPosition;
      localPosition.y = value;
      component.localPosition = localPosition;
    }
  }
}