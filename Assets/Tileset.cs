using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tileset {

  static Tileset _instance = null;

  static public Tileset Instance() {
    if (_instance == null) {
      _instance = new Tileset();
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
    Texture2D tilesTexture = Resources.Load<Texture2D>("tiles/tiles_spritesheet");

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
                                           936 - itemRect[1] - itemRect[3] + gap,
                                           itemRect[2] - (gap<<1),
                                           itemRect[3] - (gap<<1)),
                                       Vector2.zero);

      tileSources[i] = Tile.CreateInstance<Tile> ();
      tileSources[i].sprite = spriteSources[i];
    }
  }


  public enum ObjType : int {
    unknown = 0,
    box,
    boxAlt,
    boxCoin,
    boxCoinAlt,
    boxCoinAlt_disabled,
    boxCoin_disabled,
    boxEmpty,
    boxExplosive,
    boxExplosiveAlt,
    boxExplosive_disabled,
    boxItem,
    boxItemAlt,
    boxItemAlt_disabled,
    boxItem_disabled,
    boxWarning,
    brickWall,
    bridge,
    bridgeLogs,
    castle,
    castleCenter,
    castleCenter_rounded,
    castleCliffLeft,
    castleCliffLeftAlt,
    castleCliffRight,
    castleCliffRightAlt,
    castleHalf,
    castleHalfLeft,
    castleHalfMid,
    castleHalfRight,
    castleHillLeft,
    castleHillLeft2,
    castleHillRight,
    castleHillRight2,
    castleLedgeLeft,
    castleLedgeRight,
    castleLeft,
    castleMid,
    castleRight,
    dirt,
    dirtCenter,
    dirtCenter_rounded,
    dirtCliffLeft,
    dirtCliffLeftAlt,
    dirtCliffRight,
    dirtCliffRightAlt,
    dirtHalf,
    dirtHalfLeft,
    dirtHalfMid,
    dirtHalfRight,
    dirtHillLeft,
    dirtHillLeft2,
    dirtHillRight,
    dirtHillRight2,
    dirtLedgeLeft,
    dirtLedgeRight,
    dirtLeft,
    dirtMid,
    dirtRight,
    door_closedMid,
    door_closedTop,
    door_openMid,
    door_openTop,
    fence,
    fenceBroken,
    grass,
    grassCenter,
    grassCenter_rounded,
    grassCliffLeft,
    grassCliffLeftAlt,
    grassCliffRight,
    grassCliffRightAlt,
    grassHalf,
    grassHalfLeft,
    grassHalfMid,
    grassHalfRight,
    grassHillLeft,
    grassHillLeft2,
    grassHillRight,
    grassHillRight2,
    grassLedgeLeft,
    grassLedgeRight,
    grassLeft,
    grassMid,
    grassRight,
    hill_large,
    hill_largeAlt,
    hill_small,
    hill_smallAlt,
    ladder_mid,
    ladder_top,
    liquidLava,
    liquidLavaTop,
    liquidLavaTop_mid,
    liquidWater,
    liquidWaterTop,
    liquidWaterTop_mid,
    lock_blue,
    lock_green,
    lock_red,
    lock_yellow,
    rockHillLeft,
    rockHillRight,
    ropeAttached,
    ropeHorizontal,
    ropeVertical,
    sand,
    sandCenter,
    sandCenter_rounded,
    sandCliffLeft,
    sandCliffLeftAlt,
    sandCliffRight,
    sandCliffRightAlt,
    sandHalf,
    sandHalfLeft,
    sandHalfMid,
    sandHalfRight,
    sandHillLeft,
    sandHillLeft2,
    sandHillRight,
    sandHillRight2,
    sandLedgeLeft,
    sandLedgeRight,
    sandLeft,
    sandMid,
    sandRight,
    sign,
    signExit,
    signLeft,
    signRight,
    snow,
    snowCenter,
    snowCenter_rounded,
    snowCliffLeft,
    snowCliffLeftAlt,
    snowCliffRight,
    snowCliffRightAlt,
    snowHalf,
    snowHalfLeft,
    snowHalfMid,
    snowHalfRight,
    snowHillLeft,
    snowHillLeft2,
    snowHillRight,
    snowHillRight2,
    snowLedgeLeft,
    snowLedgeRight,
    snowLeft,
    snowMid,
    snowRight,
    stone,
    stoneCenter,
    stoneCenter_rounded,
    stoneCliffLeft,
    stoneCliffLeftAlt,
    stoneCliffRight,
    stoneCliffRightAlt,
    stoneHalf,
    stoneHalfLeft,
    stoneHalfMid,
    stoneHalfRight,
    stoneHillLeft2,
    stoneHillRight2,
    stoneLedgeLeft,
    stoneLedgeRight,
    stoneLeft,
    stoneMid,
    stoneRight,
    stoneWall,
    tochLit,
    tochLit2,
    torch,
    window,
    last
  }

  int[][] getItemRects() {
    int[][] items = new int[(int)ObjType.last][];
    items[(int)ObjType.unknown] = new int [] {0, 0, 1, 1};
    items[(int)ObjType.box] = new int [] {0, 864, 70, 70};
    items[(int)ObjType.boxAlt] = new int [] {0, 792, 70, 70};
    items[(int)ObjType.boxCoin] = new int [] {0, 720, 70, 70};
    items[(int)ObjType.boxCoinAlt] = new int [] {0, 576, 70, 70};
    items[(int)ObjType.boxCoinAlt_disabled] = new int [] {0, 504, 70, 70};
    items[(int)ObjType.boxCoin_disabled] = new int [] {0, 648, 70, 70};
    items[(int)ObjType.boxEmpty] = new int [] {0, 432, 70, 70};
    items[(int)ObjType.boxExplosive] = new int [] {0, 360, 70, 70};
    items[(int)ObjType.boxExplosiveAlt] = new int [] {0, 216, 70, 70};
    items[(int)ObjType.boxExplosive_disabled] = new int [] {0, 288, 70, 70};
    items[(int)ObjType.boxItem] = new int [] {0, 144, 70, 70};
    items[(int)ObjType.boxItemAlt] = new int [] {0, 0, 70, 70};
    items[(int)ObjType.boxItemAlt_disabled] = new int [] {432, 432, 70, 70};
    items[(int)ObjType.boxItem_disabled] = new int [] {0, 72, 70, 70};
    items[(int)ObjType.boxWarning] = new int [] {72, 648, 70, 70};
    items[(int)ObjType.brickWall] = new int [] {216, 0, 70, 70};
    items[(int)ObjType.bridge] = new int [] {216, 72, 70, 70};
    items[(int)ObjType.bridgeLogs] = new int [] {288, 720, 70, 70};
    items[(int)ObjType.castle] = new int [] {288, 792, 70, 70};
    items[(int)ObjType.castleCenter] = new int [] {504, 288, 70, 70};
    items[(int)ObjType.castleCenter_rounded] = new int [] {504, 720, 70, 70};
    items[(int)ObjType.castleCliffLeft] = new int [] {504, 792, 70, 70};
    items[(int)ObjType.castleCliffLeftAlt] = new int [] {648, 720, 70, 70};
    items[(int)ObjType.castleCliffRight] = new int [] {648, 792, 70, 70};
    items[(int)ObjType.castleCliffRightAlt] = new int [] {792, 288, 70, 70};
    items[(int)ObjType.castleHalf] = new int [] {792, 360, 70, 70};
    items[(int)ObjType.castleHalfLeft] = new int [] {432, 720, 70, 70};
    items[(int)ObjType.castleHalfMid] = new int [] {648, 648, 70, 70};
    items[(int)ObjType.castleHalfRight] = new int [] {792, 648, 70, 70};
    items[(int)ObjType.castleHillLeft] = new int [] {648, 576, 70, 70};
    items[(int)ObjType.castleHillLeft2] = new int [] {792, 576, 70, 70};
    items[(int)ObjType.castleHillRight] = new int [] {792, 504, 70, 70};
    items[(int)ObjType.castleHillRight2] = new int [] {792, 432, 70, 70};
    items[(int)ObjType.castleLedgeLeft] = new int [] {856, 868, 5, 22};
    items[(int)ObjType.castleLedgeRight] = new int [] {842, 868, 5, 22};
    items[(int)ObjType.castleLeft] = new int [] {792, 216, 70, 70};
    items[(int)ObjType.castleMid] = new int [] {792, 144, 70, 70};
    items[(int)ObjType.castleRight] = new int [] {792, 72, 70, 70};
    items[(int)ObjType.dirt] = new int [] {792, 0, 70, 70};
    items[(int)ObjType.dirtCenter] = new int [] {720, 864, 70, 70};
    items[(int)ObjType.dirtCenter_rounded] = new int [] {720, 792, 70, 70};
    items[(int)ObjType.dirtCliffLeft] = new int [] {720, 720, 70, 70};
    items[(int)ObjType.dirtCliffLeftAlt] = new int [] {720, 648, 70, 70};
    items[(int)ObjType.dirtCliffRight] = new int [] {720, 576, 70, 70};
    items[(int)ObjType.dirtCliffRightAlt] = new int [] {720, 504, 70, 70};
    items[(int)ObjType.dirtHalf] = new int [] {720, 432, 70, 70};
    items[(int)ObjType.dirtHalfLeft] = new int [] {720, 360, 70, 70};
    items[(int)ObjType.dirtHalfMid] = new int [] {720, 288, 70, 70};
    items[(int)ObjType.dirtHalfRight] = new int [] {720, 216, 70, 70};
    items[(int)ObjType.dirtHillLeft] = new int [] {720, 144, 70, 70};
    items[(int)ObjType.dirtHillLeft2] = new int [] {720, 72, 70, 70};
    items[(int)ObjType.dirtHillRight] = new int [] {720, 0, 70, 70};
    items[(int)ObjType.dirtHillRight2] = new int [] {648, 864, 70, 70};
    items[(int)ObjType.dirtLedgeLeft] = new int [] {842, 892, 5, 18};
    items[(int)ObjType.dirtLedgeRight] = new int [] {842, 912, 5, 18};
    items[(int)ObjType.dirtLeft] = new int [] {504, 432, 70, 70};
    items[(int)ObjType.dirtMid] = new int [] {504, 360, 70, 70};
    items[(int)ObjType.dirtRight] = new int [] {648, 504, 70, 70};
    items[(int)ObjType.door_closedMid] = new int [] {648, 432, 70, 70};
    items[(int)ObjType.door_closedTop] = new int [] {648, 360, 70, 70};
    items[(int)ObjType.door_openMid] = new int [] {648, 288, 70, 70};
    items[(int)ObjType.door_openTop] = new int [] {648, 216, 70, 70};
    items[(int)ObjType.fence] = new int [] {648, 144, 70, 70};
    items[(int)ObjType.fenceBroken] = new int [] {648, 72, 70, 70};
    items[(int)ObjType.grass] = new int [] {648, 0, 70, 70};
    items[(int)ObjType.grassCenter] = new int [] {576, 864, 70, 70};
    items[(int)ObjType.grassCenter_rounded] = new int [] {576, 792, 70, 70};
    items[(int)ObjType.grassCliffLeft] = new int [] {576, 720, 70, 70};
    items[(int)ObjType.grassCliffLeftAlt] = new int [] {576, 648, 70, 70};
    items[(int)ObjType.grassCliffRight] = new int [] {576, 576, 70, 70};
    items[(int)ObjType.grassCliffRightAlt] = new int [] {576, 504, 70, 70};
    items[(int)ObjType.grassHalf] = new int [] {576, 432, 70, 70};
    items[(int)ObjType.grassHalfLeft] = new int [] {576, 360, 70, 70};
    items[(int)ObjType.grassHalfMid] = new int [] {576, 288, 70, 70};
    items[(int)ObjType.grassHalfRight] = new int [] {576, 216, 70, 70};
    items[(int)ObjType.grassHillLeft] = new int [] {576, 144, 70, 70};
    items[(int)ObjType.grassHillLeft2] = new int [] {576, 72, 70, 70};
    items[(int)ObjType.grassHillRight] = new int [] {576, 0, 70, 70};
    items[(int)ObjType.grassHillRight2] = new int [] {504, 864, 70, 70};
    items[(int)ObjType.grassLedgeLeft] = new int [] {849, 868, 5, 24};
    items[(int)ObjType.grassLedgeRight] = new int [] {849, 894, 5, 24};
    items[(int)ObjType.grassLeft] = new int [] {504, 648, 70, 70};
    items[(int)ObjType.grassMid] = new int [] {504, 576, 70, 70};
    items[(int)ObjType.grassRight] = new int [] {504, 504, 70, 70};
    items[(int)ObjType.hill_large] = new int [] {842, 720, 48, 146};
    items[(int)ObjType.hill_largeAlt] = new int [] {864, 0, 48, 146};
    items[(int)ObjType.hill_small] = new int [] {792, 828, 48, 106};
    items[(int)ObjType.hill_smallAlt] = new int [] {792, 720, 48, 106};
    items[(int)ObjType.ladder_mid] = new int [] {504, 144, 70, 70};
    items[(int)ObjType.ladder_top] = new int [] {504, 72, 70, 70};
    items[(int)ObjType.liquidLava] = new int [] {504, 0, 70, 70};
    items[(int)ObjType.liquidLavaTop] = new int [] {432, 864, 70, 70};
    items[(int)ObjType.liquidLavaTop_mid] = new int [] {432, 792, 70, 70};
    items[(int)ObjType.liquidWater] = new int [] {504, 216, 70, 70};
    items[(int)ObjType.liquidWaterTop] = new int [] {432, 648, 70, 70};
    items[(int)ObjType.liquidWaterTop_mid] = new int [] {432, 576, 70, 70};
    items[(int)ObjType.lock_blue] = new int [] {432, 504, 70, 70};
    items[(int)ObjType.lock_green] = new int [] {72, 576, 70, 70};
    items[(int)ObjType.lock_red] = new int [] {432, 360, 70, 70};
    items[(int)ObjType.lock_yellow] = new int [] {432, 288, 70, 70};
    items[(int)ObjType.rockHillLeft] = new int [] {432, 216, 70, 70};
    items[(int)ObjType.rockHillRight] = new int [] {432, 144, 70, 70};
    items[(int)ObjType.ropeAttached] = new int [] {432, 72, 70, 70};
    items[(int)ObjType.ropeHorizontal] = new int [] {432, 0, 70, 70};
    items[(int)ObjType.ropeVertical] = new int [] {360, 864, 70, 70};
    items[(int)ObjType.sand] = new int [] {360, 792, 70, 70};
    items[(int)ObjType.sandCenter] = new int [] {576, 864, 70, 70};
    items[(int)ObjType.sandCenter_rounded] = new int [] {576, 792, 70, 70};
    items[(int)ObjType.sandCliffLeft] = new int [] {360, 720, 70, 70};
    items[(int)ObjType.sandCliffLeftAlt] = new int [] {360, 648, 70, 70};
    items[(int)ObjType.sandCliffRight] = new int [] {360, 576, 70, 70};
    items[(int)ObjType.sandCliffRightAlt] = new int [] {360, 504, 70, 70};
    items[(int)ObjType.sandHalf] = new int [] {360, 432, 70, 70};
    items[(int)ObjType.sandHalfLeft] = new int [] {360, 360, 70, 70};
    items[(int)ObjType.sandHalfMid] = new int [] {360, 288, 70, 70};
    items[(int)ObjType.sandHalfRight] = new int [] {360, 216, 70, 70};
    items[(int)ObjType.sandHillLeft] = new int [] {360, 144, 70, 70};
    items[(int)ObjType.sandHillLeft2] = new int [] {360, 72, 70, 70};
    items[(int)ObjType.sandHillRight] = new int [] {360, 0, 70, 70};
    items[(int)ObjType.sandHillRight2] = new int [] {288, 864, 70, 70};
    items[(int)ObjType.sandLedgeLeft] = new int [] {856, 892, 5, 18};
    items[(int)ObjType.sandLedgeRight] = new int [] {856, 912, 5, 18};
    items[(int)ObjType.sandLeft] = new int [] {288, 648, 70, 70};
    items[(int)ObjType.sandMid] = new int [] {288, 576, 70, 70};
    items[(int)ObjType.sandRight] = new int [] {288, 504, 70, 70};
    items[(int)ObjType.sign] = new int [] {288, 432, 70, 70};
    items[(int)ObjType.signExit] = new int [] {288, 360, 70, 70};
    items[(int)ObjType.signLeft] = new int [] {288, 288, 70, 70};
    items[(int)ObjType.signRight] = new int [] {288, 216, 70, 70};
    items[(int)ObjType.snow] = new int [] {288, 144, 70, 70};
    items[(int)ObjType.snowCenter] = new int [] {720, 864, 70, 70};
    items[(int)ObjType.snowCenter_rounded] = new int [] {288, 72, 70, 70};
    items[(int)ObjType.snowCliffLeft] = new int [] {288, 0, 70, 70};
    items[(int)ObjType.snowCliffLeftAlt] = new int [] {216, 864, 70, 70};
    items[(int)ObjType.snowCliffRight] = new int [] {216, 792, 70, 70};
    items[(int)ObjType.snowCliffRightAlt] = new int [] {216, 720, 70, 70};
    items[(int)ObjType.snowHalf] = new int [] {216, 648, 70, 70};
    items[(int)ObjType.snowHalfLeft] = new int [] {216, 576, 70, 70};
    items[(int)ObjType.snowHalfMid] = new int [] {216, 504, 70, 70};
    items[(int)ObjType.snowHalfRight] = new int [] {216, 432, 70, 70};
    items[(int)ObjType.snowHillLeft] = new int [] {216, 360, 70, 70};
    items[(int)ObjType.snowHillLeft2] = new int [] {216, 288, 70, 70};
    items[(int)ObjType.snowHillRight] = new int [] {216, 216, 70, 70};
    items[(int)ObjType.snowHillRight2] = new int [] {216, 144, 70, 70};
    items[(int)ObjType.snowLedgeLeft] = new int [] {863, 868, 5, 18};
    items[(int)ObjType.snowLedgeRight] = new int [] {863, 888, 5, 18};
    items[(int)ObjType.snowLeft] = new int [] {144, 864, 70, 70};
    items[(int)ObjType.snowMid] = new int [] {144, 792, 70, 70};
    items[(int)ObjType.snowRight] = new int [] {144, 720, 70, 70};
    items[(int)ObjType.stone] = new int [] {144, 648, 70, 70};
    items[(int)ObjType.stoneCenter] = new int [] {144, 576, 70, 70};
    items[(int)ObjType.stoneCenter_rounded] = new int [] {144, 504, 70, 70};
    items[(int)ObjType.stoneCliffLeft] = new int [] {144, 432, 70, 70};
    items[(int)ObjType.stoneCliffLeftAlt] = new int [] {144, 360, 70, 70};
    items[(int)ObjType.stoneCliffRight] = new int [] {144, 288, 70, 70};
    items[(int)ObjType.stoneCliffRightAlt] = new int [] {144, 216, 70, 70};
    items[(int)ObjType.stoneHalf] = new int [] {144, 144, 70, 70};
    items[(int)ObjType.stoneHalfLeft] = new int [] {144, 72, 70, 70};
    items[(int)ObjType.stoneHalfMid] = new int [] {144, 0, 70, 70};
    items[(int)ObjType.stoneHalfRight] = new int [] {72, 864, 70, 70};
    items[(int)ObjType.stoneHillLeft2] = new int [] {72, 792, 70, 70};
    items[(int)ObjType.stoneHillRight2] = new int [] {72, 720, 70, 70};
    items[(int)ObjType.stoneLedgeLeft] = new int [] {863, 908, 5, 24};
    items[(int)ObjType.stoneLedgeRight] = new int [] {864, 148, 5, 24};
    items[(int)ObjType.stoneLeft] = new int [] {72, 504, 70, 70};
    items[(int)ObjType.stoneMid] = new int [] {72, 432, 70, 70};
    items[(int)ObjType.stoneRight] = new int [] {72, 360, 70, 70};
    items[(int)ObjType.stoneWall] = new int [] {72, 288, 70, 70};
    items[(int)ObjType.tochLit] = new int [] {72, 216, 70, 70};
    items[(int)ObjType.tochLit2] = new int [] {72, 144, 70, 70};
    items[(int)ObjType.torch] = new int [] {72, 72, 70, 70};
    items[(int)ObjType.window] = new int [] {72, 0, 70, 70};
    return items;
  }

}