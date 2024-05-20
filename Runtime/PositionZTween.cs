using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class PositionZTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.position.z;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var position = component.position;
      position.z = value;
      component.position = position;
    }
  }
}