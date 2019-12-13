using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Itemset {

  static Itemset _instance = null;

  static public Itemset Instance() {
    if (_instance == null) {
      _instance = new Itemset();
    }
    return _instance;
  }

  public Sprite[] spriteSources;
  public Tile[] tileSources;

  public void LoadResources () {
    if (spriteSources != null) {
      return;
    }

    // load texture
    Texture2D tilesTexture = Resources.Load<Texture2D>("items/items_spritesheet");

    spriteSources = new Sprite[(int)ObjType.last];

    // build tile sources
    tileSources = new Tile[spriteSources.Length];
    int gap = 1;
    int[][] items = getItemRects();
    for (int i = 0; i < spriteSources.Length; i++) {
      int [] itemRect = items[i];

      if (itemRect == null) {
        continue;
      }

      spriteSources[i] = Sprite.Create(tilesTexture,
                                       new Rect(itemRect[0] + gap,
                                           576 - itemRect[1] - itemRect[3] + gap,
                                           itemRect[2] - (gap<<1),
                                           itemRect[3] - (gap<<1)),
                                       Vector2.zero);

      tileSources[i] = Tile.CreateInstance<Tile> ();
      tileSources[i].sprite = spriteSources[i];
    }
  }


  public enum ObjType : int {
    unknown = 0,
    bomb,
    bombFlash,
    bush,
    buttonBlue,
    buttonBlue_pressed,
    buttonGreen,
    buttonGreen_pressed,
    buttonRed,
    buttonRed_pressed,
    buttonYellow,
    buttonYellow_pressed,
    cactus,
    chain,
    cloud1,
    cloud2,
    cloud3,
    coinBronze,
    coinGold,
    coinSilver,
    fireball,
    flagBlue,
    flagBlue2,
    flagBlueHanging,
    flagGreen,
    flagGreen2,
    flagGreenHanging,
    flagRed,
    flagRed2,
    flagRedHanging,
    flagYellow,
    flagYellow2,
    flagYellowHanging,
    gemBlue,
    gemGreen,
    gemRed,
    gemYellow,
    keyBlue,
    keyGreen,
    keyRed,
    keyYellow,
    mushroomBrown,
    mushroomRed,
    particleBrick1a,
    particleBrick1b,
    particleBrick2a,
    particleBrick2b,
    plant,
    plantPurple,
    rock,
    snowhill,
    spikes,
    springboardDown,
    springboardUp,
    star,
    switchLeft,
    switchMid,
    switchRight,
    weight,
    weightChained,
    last
  }

  int[][] getItemRects() {
    int[][] items = new int[(int)ObjType.last][];
    items[(int)ObjType.bomb] = new int [] {432, 432, 70, 70};
    items[(int)ObjType.bombFlash] = new int [] {432, 360, 70, 70};
    items[(int)ObjType.bush] = new int [] {346, 144, 70, 70};
    items[(int)ObjType.buttonBlue] = new int [] {288, 504, 70, 70};
    items[(int)ObjType.buttonBlue_pressed] = new int [] {419, 72, 70, 70};
    items[(int)ObjType.buttonGreen] = new int [] {419, 0, 70, 70};
    items[(int)ObjType.buttonGreen_pressed] = new int [] {418, 144, 70, 70};
    items[(int)ObjType.buttonRed] = new int [] {360, 504, 70, 70};
    items[(int)ObjType.buttonRed_pressed] = new int [] {360, 432, 70, 70};
    items[(int)ObjType.buttonYellow] = new int [] {360, 360, 70, 70};
    items[(int)ObjType.buttonYellow_pressed] = new int [] {360, 288, 70, 70};
    items[(int)ObjType.cactus] = new int [] {360, 216, 70, 70};
    items[(int)ObjType.chain] = new int [] {347, 72, 70, 70};
    items[(int)ObjType.cloud1] = new int [] {0, 146, 128, 71};
    items[(int)ObjType.cloud2] = new int [] {0, 73, 129, 71};
    items[(int)ObjType.cloud3] = new int [] {0, 0, 129, 71};
    items[(int)ObjType.coinBronze] = new int [] {288, 432, 70, 70};
    items[(int)ObjType.coinGold] = new int [] {288, 360, 70, 70};
    items[(int)ObjType.coinSilver] = new int [] {288, 288, 70, 70};
    items[(int)ObjType.fireball] = new int [] {0, 435, 70, 70};
    items[(int)ObjType.flagBlue] = new int [] {275, 72, 70, 70};
    items[(int)ObjType.flagBlue2] = new int [] {275, 0, 70, 70};
    items[(int)ObjType.flagBlueHanging] = new int [] {216, 504, 70, 70};
    items[(int)ObjType.flagGreen] = new int [] {216, 432, 70, 70};
    items[(int)ObjType.flagGreen2] = new int [] {216, 360, 70, 70};
    items[(int)ObjType.flagGreenHanging] = new int [] {216, 288, 70, 70};
    items[(int)ObjType.flagRed] = new int [] {274, 144, 70, 70};
    items[(int)ObjType.flagRed2] = new int [] {216, 216, 70, 70};
    items[(int)ObjType.flagRedHanging] = new int [] {203, 72, 70, 70};
    items[(int)ObjType.flagYellow] = new int [] {203, 0, 70, 70};
    items[(int)ObjType.flagYellow2] = new int [] {202, 144, 70, 70};
    items[(int)ObjType.flagYellowHanging] = new int [] {144, 434, 70, 70};
    items[(int)ObjType.gemBlue] = new int [] {144, 362, 70, 70};
    items[(int)ObjType.gemGreen] = new int [] {144, 290, 70, 70};
    items[(int)ObjType.gemRed] = new int [] {144, 218, 70, 70};
    items[(int)ObjType.gemYellow] = new int [] {131, 72, 70, 70};
    items[(int)ObjType.keyBlue] = new int [] {131, 0, 70, 70};
    items[(int)ObjType.keyGreen] = new int [] {130, 146, 70, 70};
    items[(int)ObjType.keyRed] = new int [] {72, 435, 70, 70};
    items[(int)ObjType.keyYellow] = new int [] {72, 363, 70, 70};
    items[(int)ObjType.mushroomBrown] = new int [] {72, 291, 70, 70};
    items[(int)ObjType.mushroomRed] = new int [] {72, 219, 70, 70};
    items[(int)ObjType.particleBrick1a] = new int [] {0, 553, 19, 14};
    items[(int)ObjType.particleBrick1b] = new int [] {0, 530, 21, 21};
    items[(int)ObjType.particleBrick2a] = new int [] {21, 553, 19, 14};
    items[(int)ObjType.particleBrick2b] = new int [] {0, 507, 21, 21};
    items[(int)ObjType.plant] = new int [] {0, 363, 70, 70};
    items[(int)ObjType.plantPurple] = new int [] {0, 291, 70, 70};
    items[(int)ObjType.rock] = new int [] {0, 219, 70, 70};
    items[(int)ObjType.snowhill] = new int [] {288, 216, 70, 70};
    items[(int)ObjType.spikes] = new int [] {347, 0, 70, 70};
    items[(int)ObjType.springboardDown] = new int [] {432, 288, 70, 70};
    items[(int)ObjType.springboardUp] = new int [] {432, 216, 70, 70};
    items[(int)ObjType.star] = new int [] {504, 288, 70, 70};
    items[(int)ObjType.switchLeft] = new int [] {504, 216, 70, 70};
    items[(int)ObjType.switchMid] = new int [] {491, 72, 70, 70};
    items[(int)ObjType.switchRight] = new int [] {491, 0, 70, 70};
    items[(int)ObjType.weight] = new int [] {490, 144, 70, 70};
    items[(int)ObjType.weightChained] = new int [] {432, 504, 70, 70};
    return items;
  }

}