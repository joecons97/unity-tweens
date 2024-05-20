using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class SpriteRendererColorTween : Tween<SpriteRenderer, Color> {
    public sealed override Color Current(SpriteRenderer component) {
      return component.color;
    }

    public sealed override Color Lerp(Color from, Color to, float time) {
      return Color.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(SpriteRenderer component, Color value) {
      component.color = value;
    }
  }
}