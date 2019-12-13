using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {
  int [] _stand = new int [] { 0 };
  int [] _walk = new int [] { 1,2,3,4,5,6,7,8 };
  int [] _jump = new int [] { 98, 99, 100, 101 };
  int [] _fall = new int [] { 103, 104, 105 };
  int [] _die = new int [] { 22, 23, 24, 11, 12, 25 };

  public bool isDead = false;
  bool jumping = false;
  float zeroY = 0;

  override
  public void Init() {
    base.Init();
    source = "characters/player";

    PhysicsMaterial2D mat = new PhysicsMaterial2D();
    mat.friction = 0.1f;
    mat.bounciness = 0.25f;
    body.sharedMaterial = mat;
    body.angularDrag = 0.0f;

    lockDirection = true;
    Reset();
  }

  public void Reset() {
    isDead = false;
    jumping = false;
    Stand();
  }

  public void Stand() {
    if (isDead) {
      return;
    }

    speedX = 0;
    SetAnimation(_stand, 0, false);
  }

  public void Walk() {
    if (isDead) {
      return;
    }

    speedX = 2.0f * direction;
    SetAnimation(_walk, 12, true);
  }

  public void Run() {
    if (isDead) {
      return;
    }

    speedX = 4.0f * direction;
    SetAnimation(_walk, 15, true);
  }

  public void Jump() {
    if (isDead) {
      return;
    }

    if (!jumping && body.velocity.y == 0) {
      zeroY = 0;
      jumping = true;
      body.AddForce (transform.up * 300);
      SetAnimation(_jump, 10, false);
    }
  }

  public void EndJump() {
    if (isDead) {
      return;
    }

    if (jumping) {
      Vector2 v = body.velocity;
      v.y = v.y * 0.6f;
      body.velocity = v;
    }
  }

  public void Die() {
    if (isDead) {
      return;
    }

    SoundEffects.Instance().PlayEffect(SoundEffects.Effects.die);

    isDead = true;
    speedX = 0;
    body.AddForce (transform.up * 20);
    SetAnimation(_die, 15, false);
  }

  override
  public void Act() {
    float dt = Time.deltaTime;

    if (isDead) {
      return;
    }

    // jumping
    if (body.velocity.y == 0 && jumping) {
      zeroY+=dt;
      if (zeroY > 0.15f) {
        jumping = false;
        Run();
      }
    } else {
      zeroY = 0;
    }

    // falling
    if (body.velocity.y < 0 && jumping) {
      SetAnimation(_fall, 10, false);
    }

    // move forward
    Vector2 v = body.velocity;
    if (v.y == 0) {
      v.x = speedX;
    }
    body.velocity = v;

    // remove any rotations
    body.rotation = 0;
  }
}