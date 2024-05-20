#if TWEENS_DEFINED_COM_UNITY_UGUI
using Tweens.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Tweens {
  public sealed class GraphicColorTween : Tween<Graphic, Color> {
    public sealed override Color Current(Graphic component) {
      return component.color;
    }

    public sealed override Color Lerp(Color from, Color to, float time) {
      return Color.LerpUnclamped(from, to, time);
    }

    public sealed override void Apply(Graphic component, Color value) {
      component.color = value;
    }
  }
}
#endif