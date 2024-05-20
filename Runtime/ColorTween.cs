using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class ColorTween : Tween<Transform, Color> {
    public sealed override Color Current(Transform component) {
      return Color.clear;
    }

    public sealed override Color Lerp(Color from, Color to, float time) {
      return Color.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Transform component, Color value) { }
  }
}