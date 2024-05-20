using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AnchorMaxTween : Tween<RectTransform, Vector2> {
    protected sealed override Vector2 Current(RectTransform component) {
      return component.anchorMax;
    }

    protected sealed override Vector2 Lerp(Vector2 from, Vector2 to, float time) {
      return Vector2.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(RectTransform component, Vector2 value) {
      component.anchorMax = value;
    }
  }
}