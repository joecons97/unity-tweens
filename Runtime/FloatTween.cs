using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class FloatTween : Tween<Transform, float> {
    protected sealed override float Current(Transform component) {
      return 0;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(Transform component, float value) { }
  }
}