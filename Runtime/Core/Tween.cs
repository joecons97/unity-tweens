using System;
using UnityEngine;

namespace ElRaccoone.Tweens.Core {
  public abstract class Tween<T> : MonoBehaviour, ITween {
    internal T valueFrom = default (T);
    internal T valueTo = default (T);
    internal T valueCurrent = default (T);

    private float time = 0;
    private Ease ease = 0;

    private bool hasLoopCount = false;
    private int loopCount = 0;

    private bool hasDuration = false;
    private float duration = 0;

    private bool hasDelay = false;
    private float delay = 0;
    private bool goToFirstFrameImmediately = false;

    private bool hasOvershooting = false;
    private float overshooting = 0;

    private Action onComplete = null;
    private bool hasOnComplete = false;

    private Action onCancel = null;
    private bool hasOnCancel = false;

    private bool isDecommissioned = false;
    private bool isInfinite = false;
    private bool didOverwriteFrom = false;
    private bool hasPingPong = false;
    private bool isPlayingForward = true;
    private bool timeDidReachEnd = false;

    public abstract bool OnInitialize ();
    public abstract T OnGetFrom ();
    public abstract void OnUpdate (float easedTime);

    private void Start () {
      // When From is not overwritten and the Tween has no delay, the valueFrom
      // is requested from the inheriter. Then the animation will be set to its
      // first frame. This is done during the Start method so other parameters
      // can be set.
      if (this.OnInitialize () == false)
        this.Decommission ();
      else if (this.hasDelay == false || this.goToFirstFrameImmediately == true) {
        if (this.didOverwriteFrom == false)
          this.valueFrom = this.OnGetFrom ();
        this.OnUpdate (Easer.Apply (this.ease, 0));
      }
    }

    private void Update () {
      // When the tween is decommissioned, tweening is aborted.
      if (this.isDecommissioned == true)
        return;
      // When the delay is active, the tween will wait for the delay to pass by.
      if (this.hasDelay == true) {
        this.delay -= Time.deltaTime;
        if (this.delay <= 0) {
          this.hasDelay = false;
          // When the delay is over, the valueFrom is requested from the 
          // inheriter. Then the animation will be set to its first frame.
          if (this.didOverwriteFrom == false)
            this.valueFrom = this.OnGetFrom ();
          this.OnUpdate (Easer.Apply (this.ease, 0));
        }
      }
      // When the tween has no duration, the timing will not be done and the
      // animation will be set to its last frame amd decomissioned right away.
      else if (this.hasDuration == false) {
        this.OnUpdate (Easer.Apply (this.ease, 1));
        this.Decommission ();
        return;
      }
      // Oterwise it is... Showtime!
      else {
        // Increase or decrease the time of the tween based on the direction.
        var _timeDelta = Time.deltaTime / this.duration;
        this.time += this.isPlayingForward == true ? _timeDelta : -_timeDelta;
        // The time will be capped to 1, when pingpong is enabled the tween will
        // play backwards, otherwise when the tween is not infinite, didReachEnd
        // will be set to true.
        if (this.time > 1) {
          this.time = 1;
          if (this.hasPingPong == true)
            this.isPlayingForward = false;
          else if (this.isInfinite == false)
            this.timeDidReachEnd = true;
          else
            this.time = 0;
        }
        // When pingpong is enabled, the time will be capped to 0 as well. When
        // it is hit, the tween will play forwards again and didReachEnd will be
        // set to true if the tween is not infinite.
        else if (this.hasPingPong == true && this.time < 0) {
          this.time = 0;
          this.isPlayingForward = true;
          if (this.isInfinite == false)
            this.timeDidReachEnd = true;
        }
        // The time will be updated on the inheriter.
        this.OnUpdate (Easer.Apply (this.ease, this.time));
        // When the end is reached either the loop count will be decreased, or
        // the tween will be decommissioned, and the oncomplete may be invoked.
        if (this.timeDidReachEnd == true)
          if (this.hasLoopCount == true && this.loopCount > 1) {
            this.timeDidReachEnd = false;
            this.loopCount -= 1;
            this.time = 0;
          } else {
            if (this.hasOnComplete == true)
              this.onComplete ();
            this.Decommission ();
          }
      }
    }

    /// Destroys the component.
    private void Decommission () {
      this.isDecommissioned = true;
      UnityEngine.Object.Destroy (this);
    }

    // Returns the interpolated value of time between from and to.
    internal float InterpolateValue (float from, float to, float value) {
      if (this.hasOvershooting == true) {
        if (value > 1)
          value -= (value - 1) / (this.overshooting + 1);
        else if (time < 0)
          value -= value / (this.overshooting + 1);
      }
      return from * (1 - value) + to * value;
    }

    /// Sets the final values required for the tween can start.
    internal Tween<T> Finalize (float duration, T valueTo) {
      this.duration = duration;
      this.hasDuration = duration > 0;
      this.valueTo = valueTo;
      return this;
    }

    /// Cancel the tween and decommision the component.
    public void Cancel () {
      if (this.hasOnCancel == true)
        this.onCancel ();
      this.Decommission ();
    }

    /// Sets the value this tween should animate from instead of its current.
    public Tween<T> SetFrom (T valueFrom) {
      this.didOverwriteFrom = true;
      this.valueFrom = valueFrom;
      return this;
    }

    /// Binds an onComplete event which will be invoked when the tween ends.
    public Tween<T> SetOnComplete (Action onComplete) {
      this.hasOnComplete = true;
      this.onComplete = onComplete;
      return this;
    }

    // Binds an onCancel event which will be invoked when the tween is canceled.
    public Tween<T> SetOnCancel (Action onCancel) {
      this.hasOnCancel = true;
      this.onCancel = onCancel;
      return this;
    }

    /// Sets the loop type to ping pong, this will bounce the animation back
    /// and forth endlessly. When a loop count is set, the tween has play forward
    /// and backwards to count as one cycle.
    public Tween<T> SetPingPong () {
      this.hasPingPong = true;
      return this;
    }

    /// Sets the loop count of this tween until it can be decomissioned.
    public Tween<T> SetLoopCount (int loopCount) {
      this.hasLoopCount = true;
      this.loopCount = loopCount;
      return this;
    }

    /// Sets this tween to infinite, the loopcount will be ignored.
    public Tween<T> SetInfinite () {
      this.isInfinite = true;
      return this;
    }

    /// Sets the delay of this tween. The tween will not play anything until
    /// the requested delay time is reached. You can change this behaviour by
    /// enabeling 'goToFirstFrameImmediately' to set the animation to the first
    /// frame immediately.
    public Tween<T> SetDelay (float delay, bool goToFirstFrameImmediately = false) {
      this.delay = delay;
      this.hasDelay = true;
      this.goToFirstFrameImmediately = goToFirstFrameImmediately;
      return this;
    }

    /// Sets the time of the tween to a random value.
    public Tween<T> SetRandomStartTime () {
      this.time = UnityEngine.Random.Range (0f, 1f);
      return this;
    }

    /// Sets the overshooting of Eases that exceed their boundaries such as
    /// elastic and back.
    public Tween<T> SetOvershooting (float overshooting) {
      this.overshooting = overshooting;
      this.hasOvershooting = true;
      return this;
    }

    /// Sets the ease for this tween.
    public Tween<T> SetEase (Ease ease) {
      this.ease = ease;
      return this;
    }

    public Tween<T> SetEaseLinear () {
      this.ease = Ease.Linear;
      return this;
    }

    public Tween<T> SetEaseSineIn () {
      this.ease = Ease.SineIn;
      return this;
    }

    public Tween<T> SetEaseSineOut () {
      this.ease = Ease.SineOut;
      return this;
    }

    public Tween<T> SetEaseSineInOut () {
      this.ease = Ease.SineInOut;
      return this;
    }

    public Tween<T> SetEaseQuadIn () {
      this.ease = Ease.QuadIn;
      return this;
    }

    public Tween<T> SetEaseQuadOut () {
      this.ease = Ease.QuadOut;
      return this;
    }

    public Tween<T> SetEaseQuadInOut () {
      this.ease = Ease.QuadInOut;
      return this;
    }

    public Tween<T> SetEaseCubicIn () {
      this.ease = Ease.CubicIn;
      return this;
    }

    public Tween<T> SetEaseCubicOut () {
      this.ease = Ease.CubicOut;
      return this;
    }

    public Tween<T> SetEaseCubicInOut () {
      this.ease = Ease.CubicInOut;
      return this;
    }

    public Tween<T> SetEaseQuartIn () {
      this.ease = Ease.QuartIn;
      return this;
    }

    public Tween<T> SetEaseQuartOut () {
      this.ease = Ease.QuartOut;
      return this;
    }

    public Tween<T> SetEaseQuartInOut () {
      this.ease = Ease.QuartInOut;
      return this;
    }

    public Tween<T> SetEaseQuintIn () {
      this.ease = Ease.QuintIn;
      return this;
    }

    public Tween<T> SetEaseQuintOut () {
      this.ease = Ease.QuintOut;
      return this;
    }

    public Tween<T> SetEaseQuintInOut () {
      this.ease = Ease.QuintInOut;
      return this;
    }

    public Tween<T> SetEaseExpoIn () {
      this.ease = Ease.ExpoIn;
      return this;
    }

    public Tween<T> SetEaseExpoOut () {
      this.ease = Ease.ExpoOut;
      return this;
    }

    public Tween<T> SetEaseExpoInOut () {
      this.ease = Ease.ExpoInOut;
      return this;
    }

    public Tween<T> SetEaseCircIn () {
      this.ease = Ease.CircIn;
      return this;
    }

    public Tween<T> SetEaseCircOut () {
      this.ease = Ease.CircOut;
      return this;
    }

    public Tween<T> SetEaseCircInOut () {
      this.ease = Ease.CircInOut;
      return this;
    }

    public Tween<T> SetEaseBackIn () {
      this.ease = Ease.BackIn;
      return this;
    }

    public Tween<T> SetEaseBackOut () {
      this.ease = Ease.BackOut;
      return this;
    }

    public Tween<T> SetEaseBackInOut () {
      this.ease = Ease.BackInOut;
      return this;
    }

    public Tween<T> SetEaseElasticIn () {
      this.ease = Ease.ElasticIn;
      return this;
    }

    public Tween<T> SetEaseElasticOut () {
      this.ease = Ease.ElasticOut;
      return this;
    }

    public Tween<T> SetEaseElasticInOut () {
      this.ease = Ease.ElasticInOut;
      return this;
    }

    public Tween<T> SetEaseBounceIn () {
      this.ease = Ease.BounceIn;
      return this;
    }

    public Tween<T> SetEaseBounceOut () {
      this.ease = Ease.BounceOut;
      return this;
    }

    public Tween<T> SetEaseBounceInOut () {
      this.ease = Ease.BounceInOut;
      return this;
    }
  }
}