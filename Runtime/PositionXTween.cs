using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class PositionXTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return component.position.x;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) {
      var position = component.position;
      position.x = value;
      component.position = position;
    }
  }
}