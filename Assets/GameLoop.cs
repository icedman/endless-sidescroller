using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameLoop : MonoBehaviour,
  IPointerDownHandler,
  IPointerUpHandler,
  IBeginDragHandler,
  IDragHandler,
  IEndDragHandler {
  Player player;

  // Start is called before the first frame update
  void Start() {
    player = GetComponentInChildren<Player> ();
  }

  // Update is called once per frame
  void FixedUpdate() {
  }

  public void OnPointerDown (PointerEventData eventData) {
    player.jump();
  }

  public void OnPointerUp (PointerEventData eventData) {
    // player.run();
  }

  public void OnBeginDrag (PointerEventData eventData) {}
  public void OnDrag (PointerEventData eventData) {}
  public void OnEndDrag (PointerEventData eventData) {}
}
