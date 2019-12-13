using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EndlessRooms : MonoBehaviour {
  public Room [] rooms;
  public Player player;

  public GameObject enemyPrefab;

  int idx = 0;

  void Start() {
    rooms = GetComponentsInChildren<Room>();
  }

  void Update() {
    foreach(Room room in rooms) {
      if (player.transform.position.x < room.transform.position.x) {
        continue;
      }
      // distance
      float d = Vector3.Distance(player.transform.position, room.transform.position);
      if (d > 30) {
        room.index = idx++;
        MoveRoomToBack(room, FindAdjacentRoom(room));
        room.Generate();
        return;
      }
    }
  }

  Room FindAdjacentRoom(Room r) {
    foreach(Room room in rooms) {
      if (room.index+1 == r.index) {
        return room;
      }
    }
    return rooms[0];
  }

  void MoveRoomToBack(Room r, Room end) {
    Vector3Int localPlace = (new Vector3Int(23, 0, (int)end.tileMap.transform.position.y));
    Vector3 place = end.tileMap.CellToWorld(localPlace);
    r.transform.position = place;
  }

  public void Init() {
    idx = 0;
    foreach(Room room in rooms) {
      room.index = idx++;

      // pass on prefabs
      room.enemyPrefab = enemyPrefab;
      room.transform.position = Vector3.zero;
      room.Generate();
    }

    for(int i=1; i<rooms.Length; i++) {
      Room r = rooms[i];
      Room prev = rooms[i-1];
      MoveRoomToBack(r, prev);
    }
  }
}