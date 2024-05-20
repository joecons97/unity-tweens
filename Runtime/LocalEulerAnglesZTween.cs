using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LocalEulerAnglesZTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return component.localEulerAngles.z;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) {
      var localEulerAngles = component.localEulerAngles;
      localEulerAngles.z = value;
      component.localEulerAngles = localEulerAngles;
    }
  }
}