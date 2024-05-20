using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class PositionYTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.position.y;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var position = component.position;
      position.y = value;
      component.position = position;
    }
  }
}