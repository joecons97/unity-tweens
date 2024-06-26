using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class RectTween : Tween<Transform, Rect> {
    public sealed override Rect Current(Transform component) {
      return Rect.zero;
    }

    public sealed override Rect Lerp(Rect from, Rect to, float time) {
      var x = Mathf.LerpUnclamped(from.x, to.x, time);
      var y = Mathf.LerpUnclamped(from.y, to.y, time);
      var width = Mathf.LerpUnclamped(from.width, to.width, time);
      var height = Mathf.LerpUnclamped(from.height, to.height, time);
      return new Rect(x, y, width, height);
    }

    public sealed override void Apply(Transform component, Rect value) { }
  }
}