using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class EulerAnglesZTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.eulerAngles.z;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var eulerAngles = component.eulerAngles;
      eulerAngles.z = value;
      component.eulerAngles = eulerAngles;
    }
  }
}