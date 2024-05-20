using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class SpriteRendererColorTween : Tween<SpriteRenderer, Color> {
    protected sealed override Color Current(SpriteRenderer component) {
      return component.color;
    }

    protected sealed override Color Lerp(Color from, Color to, float time) {
      return Color.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(SpriteRenderer component, Color value) {
      component.color = value;
    }
  }
}