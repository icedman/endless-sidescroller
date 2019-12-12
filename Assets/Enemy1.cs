using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1 : Player
{
  override
  public void init() {
    base.init();
    source = "characters/caveman";
    run();
  }

  override
  public void act() {
    float dt = Time.deltaTime;
  }
}