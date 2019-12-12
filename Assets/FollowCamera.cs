using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FollowCamera : MonoBehaviour {

  public float dampTime = 1.5f;
  private Vector3 velocity = Vector3.zero;
  public Transform target = null;

  Player player = null;
  Camera camera = null;

  void Start () {
  }

  void FixedUpdate () {
    FollowTarget (true);
  }

  public void FollowTarget (bool dampen) {
    if (!target)
      return;

    if (!player) {
      player = (target.gameObject.GetComponent<Player> ());
    }
    if (!camera) {
      camera = GetComponent<Camera> ();
    }

    float dt = dampTime;
    if (!dampen) {
      dt = 0;
    }

    Vector3 point = camera.WorldToViewportPoint (player.transform.position);
    Vector3 delta = player.transform.position - camera.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
    Vector3 destination = transform.position + delta;

    destination.z = -24;
    transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dt);
  }
}