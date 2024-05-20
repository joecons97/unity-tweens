using Tweens.Core;
using UnityEngine;

namespace Tweens {
  public sealed class AudioSourcePriorityTween : Tween<AudioSource, int> {
    public sealed override int Current(AudioSource component) {
      return component.priority;
    }

    public sealed override int Lerp(int from, int to, float time) {
      return Mathf.RoundToInt(Mathf.LerpUnclamped(from, to, time));
    }

    public sealed override void Apply(AudioSource component, int value) {
      component.priority = value;
    }
  }
}