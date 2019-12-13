using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{
  public Player player;
  bool chasing = false;

  override
  public void Init() {
    base.Init();
    if (source == "") {
      source = "characters/caveman";
    }
    Stand();
  }

  public void FacePlayer() {
    if (player) {
      if (player.transform.position.x < transform.position.x) {
        direction = -1;
      } else {
        direction = 1;
      } 
    }
  }

  public void ChasePlayer() {
    if (player && !chasing) {
       float d = Vector3.Distance(player.transform.position, transform.position);
       if (d < 3) {
          Walk();
       }
    }
  }

  public void Randomize() {
    string[] enemies = new string[] {
      "characters/caveman",
      "characters/robot",
      "characters/teddy",
      "characters/viking"
    };

    int sourceIndex = (int)((Random.Range(0.0f, 1.0f) * 100)) % (enemies.Length);
    source = enemies[sourceIndex];
    LoadResources();
  }

  override
  public void Act() {
    base.Act();

    if (player == null) {
      player = GameObject.Find("Character").GetComponent<Player> ();
    }
    
    if (player.isDead) {
      Stand();
      return;
    }

    FacePlayer();
    ChasePlayer();
  }
}