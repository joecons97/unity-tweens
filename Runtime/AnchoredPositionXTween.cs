using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AnchoredPositionXTween : Tween<RectTransform, float> {
    public sealed override float Current(RectTransform component) {
      return component.anchoredPosition.x;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(RectTransform component, float value) {
      var anchoredPosition = component.anchoredPosition;
      anchoredPosition.x = value;
      component.anchoredPosition = anchoredPosition;
    }
  }
}