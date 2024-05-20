#if TWEENS_DEFINED_COM_UNITY_UGUI
using Tweens.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Tweens {
  public sealed class GraphicAlphaTween : Tween<Graphic, float> {
    public sealed override float Current(Graphic component) {
      return component.color.a;
    }

    public sealed override float Lerp(float from, float to, float time) {
      return Mathf.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Graphic component, float value) {
      var color = component.color;
      color.a = value;
      component.color = color;
    }
  }
}
#endif