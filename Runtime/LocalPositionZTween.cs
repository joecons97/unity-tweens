using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalPositionZTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return component.localPosition.z;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) {
      var localPosition = component.localPosition;
      localPosition.z = value;
      component.localPosition = localPosition;
    }
  }
}