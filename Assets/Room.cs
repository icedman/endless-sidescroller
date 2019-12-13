using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room : MonoBehaviour {

  public int index;
  public Tilemap tileMap = null;
  public Vector2Int playerPosition;

  public GameObject enemyPrefab;

  void Start() {
    tileMap = GetComponentInChildren<Tilemap> ();
  }

  public Vector3 GetTileWorldPosition(int x, int y) {
    Vector3Int localPlace = (new Vector3Int(x, y + 2, (int)tileMap.transform.position.y));
    return tileMap.CellToWorld(localPlace);
  }

  void CleanupUp() {
    tileMap.ClearAllTiles ();

    foreach (Transform child in transform) {
      if (child.gameObject.tag == "Enemy") {
        GameObject.Destroy(child.gameObject);
      }
    }
  }

  public void Generate() {
    Tileset tileSet = Tileset.Instance();
    RoomTemplates templates = RoomTemplates.Instance();

    CleanupUp();

    // int floorTileIndex = (int)Tileset.ObjType.castleCenter_rounded;
    int floorTileIndex = (int)Tileset.ObjType.box;

    int templateIndex = 0;
    if (index != 0) {
      templateIndex = 1 + (int)((Random.Range(0.0f, 1.0f) * 100)) % (templates.templates.Count - 1);
    }

    RoomTemplates.Template t = templates.GetRoom(templateIndex);

    Tile[] tileSources = tileSet.tileSources;

    for (int y = 0; y < 12; y++) {
      string s = t.lines[11-y]; // inverted
      for (int x = 0; x < 24; x++) {
        char c = s[x];
        switch (c) {
        case '#': {
          tileMap.SetTile(new Vector3Int(x, y,0), tileSources[floorTileIndex]);
          break;
        }
        case 'E': {
          GameObject nme = Instantiate(enemyPrefab, GetTileWorldPosition(x, y) + new Vector3(0,0.15f,0), Quaternion.identity);
          nme.transform.SetParent(transform);
          nme.GetComponent<Enemy>().Randomize();
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