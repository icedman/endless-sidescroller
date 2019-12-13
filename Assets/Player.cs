using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Character {
  int [] _stand = new int [] { 0 };
  int [] _walk = new int [] { 1,2,3,4,5,6,7,8 };
  int [] _jump = new int [] { 100, 101 };
  int [] _fall = new int [] { 103, 104, 105 };

  bool jumping = false;
  int zeroY = 0;

  override
  public void Init() {
    base.Init();
    source = "characters/player";
    Stand();

    PhysicsMaterial2D mat = new PhysicsMaterial2D();
    mat.friction = 0.1f;
    mat.bounciness = 0.25f;
    body.sharedMaterial = mat;
    body.angularDrag = 0.0f;

    lockDirection = true;
  }

  public void Stand() {
    SetAnimation(_stand, 0, false);
  }

  public void Walk() {
    SetAnimation(_walk, 10, true);
  }

  public void Run() {
    speedX = 4.0f;
    SetAnimation(_walk, 15, true);
  }

  public void Jump() {
    if (!jumping && body.velocity.y == 0) {
      zeroY = 0;
      jumping = true;
      body.AddForce (transform.up * 300);
      SetAnimation(_jump, 5, false);
    }
  }

  public void EndJump() {
    if (jumping) {
      Vector2 v = body.velocity;
      v.y = v.y * 0.6f;
      body.velocity = v;
    }
  }

  override
  public void Act() {
    float dt = Time.deltaTime;

    // jumping
    if (body.velocity.y == 0 && jumping) {
      zeroY++;
      if (zeroY > 4) {
        jumping = false;
        Run();
      }
    } else {
      zeroY = 0;
    }

    // falling
    if (body.velocity.y < 0 && jumping) {
      SetAnimation(_fall, 5, false);
    }

    // move forward
    Vector2 v = body.velocity;
    if (v.y == 0)
    v.x = speedX;
    body.velocity = v;

    // remove any rotations
    body.rotation = 0;
  }
}