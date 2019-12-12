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
  public void init() {
    base.init();
    source = "characters/player";
    run();
  }

  public void stand() {
    SetAnimation(_stand, 0, false);
  }

  public void walk() {
    SetAnimation(_walk, 10, true);
  }

  public void run() {
    SetAnimation(_walk, 15, true);
  }

  public void jump() {
    if (!jumping && body.velocity.y == 0) {
      jumping = true;
      body.AddForce (transform.up * 300);
      SetAnimation(_jump, 5, false);
    }
  }

  override
  public void act() {
    float dt = Time.deltaTime;

    // jumping
    if (body.velocity.y == 0 && jumping) {
      zeroY++;
      if (zeroY > 4) {
        jumping = false;
        run();
      }
    } else {
      zeroY = 0;
    }

    // falling
    if (body.velocity.y < 0) {
      jumping = true;
      SetAnimation(_fall, 5, false);
    }

    // move forward
    Vector2 v = body.velocity;
    v.x = speedX;
    body.velocity = v;

    // remove any rotations
    body.rotation = 0;

    Debug.Log(index);
  }
}