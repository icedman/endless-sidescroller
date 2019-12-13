using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour {

  public int index;
  public Tilemap tileMap;
  public Vector2Int playerPosition;

  void Start() {
    tileMap = GetComponentInChildren<Tilemap> ();
  }

  public void Generate() {
    RoomTemplates templates = RoomTemplates.Instance();

    int floorTileIndex = 3;

    int templateIndex = 0;
    if (index != 0) {
      templateIndex = 1 + (int)((Random.Range(0.0f, 1.0f) * 100)) % (templates.templates.Count - 1);
    }

    RoomTemplates.Template t = templates.GetRoom(templateIndex);

    tileMap.ClearAllTiles ();
    Tile[] tileSources = Tileset.Instance().tileSources;

    for (int y = 0; y < 12; y++) {
      string s = t.lines[11-y]; // inverted
      for (int x = 0; x < 24; x++) {
        char c = s[x];
        switch (c) {
        case '#': {
          tileMap.SetTile(new Vector3Int(x, y,0), tileSources[floorTileIndex]);
          break;
        }
        case 'P': {
          playerPosition = new Vector2Int(x, y);
          break;
        }
        }

      }
    }
  }

}