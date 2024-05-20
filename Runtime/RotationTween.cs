using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class RotationTween : Tween<Transform, Quaternion> {
    protected sealed override Quaternion Current(Transform component) {
      return component.rotation;
    }

    protected sealed override Quaternion Lerp(Quaternion from, Quaternion to, float time) {
      return Quaternion.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, Quaternion value) {
      component.rotation = value;
    }
  }
}