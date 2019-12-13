using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy1 : Player
{
  override
  public void Init() {
    base.Init();
    source = "characters/caveman";
    Run();
  }

  override
  public void Act() {
    float dt = Time.deltaTime;
  }
}