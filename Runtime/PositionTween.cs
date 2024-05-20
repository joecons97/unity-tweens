using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class PositionTween : Tween<Transform, Vector3> {
    public sealed override Vector3 Current(Transform component) {
      return component.position;
    }

    public sealed override Vector3 Lerp(Vector3 from, Vector3 to, float time) {
      return Vector3.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, Vector3 value) {
      component.position = value;
    }
  }
}