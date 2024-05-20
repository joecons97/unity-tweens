using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class LightColorTween : Tween<Light, Color> {
    public sealed override Color Current(Light component) {
      return component.color;
    }

    public sealed override Color Lerp(Color from, Color to, float time) {
      return Color.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Light component, Color value) {
      component.color = value;
    }
  }
}