using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class RotationTween : Tween<Transform, Quaternion> {
    public sealed override Quaternion Current(Transform component) {
      return component.rotation;
    }

    public sealed override Quaternion Lerp(Quaternion from, Quaternion to, float time) {
      return Quaternion.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, Quaternion value) {
      component.rotation = value;
    }
  }
}