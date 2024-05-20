using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalEulerAnglesZTween : Tween<Transform, float> {
    public sealed override float Current(Transform component) {
      return component.localEulerAngles.z;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, float value) {
      var localEulerAngles = component.localEulerAngles;
      localEulerAngles.z = value;
      component.localEulerAngles = localEulerAngles;
    }
  }
}