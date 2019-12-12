using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
  SpriteRenderer spr;
  Sprite[] spriteSources;

  public string source;
  public int index = 0;
  public int [] animation;
  public float animationSpeed;
  public bool animationLoop;

  public Rigidbody2D body;
  public Rigidbody2D feet;
  public float speedX = 1;

  float animIndex = 0;

  public virtual void init() {}
  public virtual void act() {}

  // Start is called before the first frame update
  void Start() {
    body = GetComponent<Rigidbody2D> ();
    feet = GetComponentInChildren<Rigidbody2D> ();

    init();

    spr = GetComponent<SpriteRenderer>();
    if (!spr) {
      spr = gameObject.AddComponent<SpriteRenderer>();
    }

    LoadResources();
  }

  public void LoadResources() {
    spriteSources = Resources.LoadAll<Sprite> (source);
  }

  public void SetAnimation(int [] anim, float speed, bool loop) {
    index = anim[0];
    animIndex = 0;
    animation = anim;
    animationSpeed = speed;
    animationLoop = loop;

    // spr.sprite = spriteSources[index];
  }

  void grounded() {
    Vector2 v = body.velocity;
    v.y = 0;
    body.velocity = v;
  }

  void OnTriggerEnter2D (Collider2D collider) {
    if (collider.tag == "floor") {
      grounded();
    }
  }

  void OnTriggerStay2D (Collider2D collider) {
    if (collider.tag == "floor") {
      grounded();
    }
  }

  // Update is called once per frame
  void FixedUpdate() {
    act();

    if (animation.Length > 0 && animationSpeed != 0) {
      float dt = Time.deltaTime;
      animIndex += dt * animationSpeed;
      while (animIndex >= animation.Length) {
        if (!animationLoop) {
          animationSpeed = 0;
          animIndex = animation.Length - 1;
          break;
        }
        animIndex -= animation.Length;
      }
      index = animation[(int)animIndex];
    }

    spr.sprite = spriteSources[index];

    // flip image to direction
    Vector2 s = transform.localScale;
    if (body.velocity.x < 0) {
      s.x = -1;
    } else {
      s.x = 1;
    }
    transform.localScale = s;
  }
}
