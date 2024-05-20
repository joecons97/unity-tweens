using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AnchoredPositionYTween : Tween<RectTransform, float> {
    protected sealed override float Current(RectTransform component) {
      return component.anchoredPosition.y;
    }

    protected sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    protected sealed override void Apply(RectTransform component, float value) {
      var anchoredPosition = component.anchoredPosition;
      anchoredPosition.y = value;
      component.anchoredPosition = anchoredPosition;
    }
  }
}