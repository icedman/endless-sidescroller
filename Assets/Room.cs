using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour {

  Tilemap tilemap;

  void Start() {
    tilemap = GetComponentInChildren<Tilemap> ();
  }

  public void GenerateRoom() {
    tilemap.ClearAllTiles ();
    UnityEngine.Tilemaps.Tile[] tileSources = Tileset.Instance().tileSources;

    int idx = 0;
    for (int x = 0; x < 10; x++) {
      for (int y = 0; y < 10; y++) {
        tilemap.SetTile(new Vector3Int(x,y,0), tileSources[idx++]);
      }
    }
  }

}