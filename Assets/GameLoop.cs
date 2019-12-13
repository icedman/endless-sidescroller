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
  EndlessRooms endless;
  GameObject touchBackground;
  // Start is called before the first frame update
  void Start() {

    touchBackground = GameObject.Find("TouchBackground");
    Debug.Log(touchBackground);
    player = GetComponentInChildren<Player> ();
    endless = GetComponentInChildren<EndlessRooms> ();

    Tileset.Instance().LoadResources();
    RoomTemplates.Instance().LoadResources();

    StartGame();
  }

  // Update is called once per frame
  void FixedUpdate() {
    Vector3 v = touchBackground.transform.position;
    v.x = player.transform.position.x;
    v.y = player.transform.position.y;
    touchBackground.transform.position = v;
  }

  void StartGame() {
    endless.Init();

    // position the player
    Room room = endless.rooms[0];
    Vector3Int localPlace = (new Vector3Int(room.playerPosition.x, room.playerPosition.y+1, (int)room.tileMap.transform.position.y));
    Vector3 place = room.tileMap.CellToWorld(localPlace);
    player.transform.position = place + new Vector3(0,0.15f,0);
  }

  public void OnPointerDown (PointerEventData eventData) {
    if (player.speedX == 0) {
      player.Run();
      return;
    }
    player.Jump();
  }

  public void OnPointerUp (PointerEventData eventData) {
    player.EndJump();
  }

  public void OnBeginDrag (PointerEventData eventData) {}
  public void OnDrag (PointerEventData eventData) {}
  public void OnEndDrag (PointerEventData eventData) {}
}
