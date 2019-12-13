using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
  SpriteRenderer spr;
  Sprite[] spriteSources;

  public string source;
  public int index = 0;
  public int [] animationFrames;
  public float animationSpeed;
  public bool animationLoop;

  public Rigidbody2D body;
  public Rigidbody2D feet;
  public float speedX = 1;
  public bool lockDirection = false;
  public int direction = 1;

  float animIndex = 0;

  public virtual void Init() {}
  public virtual void Act() {}

  // Start is called before the first frame update
  void Start() {
    body = GetComponent<Rigidbody2D> ();
    feet = GetComponentInChildren<Rigidbody2D> ();

    Init();

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
    animationFrames = anim;
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
    if (collider.tag == "Ground") {
      grounded();
    }
  }

  void OnTriggerStay2D (Collider2D collider) {
    if (collider.tag == "Ground") {
      grounded();
    }
  }

  // Update is called once per frame
  void Update() {
    Act();

    if (animationFrames.Length > 0 && animationSpeed != 0) {
      float dt = Time.deltaTime;
      animIndex += dt * animationSpeed;
      while (animIndex >= animationFrames.Length) {
        if (!animationLoop) {
          animationSpeed = 0;
          animIndex = animationFrames.Length - 1;
          break;
        }
        animIndex -= animationFrames.Length;
      }  
    }

    index = animationFrames[(int)animIndex];
    spr.sprite = spriteSources[index];

    // flip image to direction
    if (!lockDirection && body.velocity.x < 0) {
      direction = -1;
    } else if (body.velocity.x > 0) {
      direction = 1;
    }
    Vector2 s = transform.localScale;
    s.x = direction;
    transform.localScale = s;
  }
}
