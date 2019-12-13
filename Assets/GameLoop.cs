using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameLoop : MonoBehaviour,
  IPointerDownHandler,
  IPointerUpHandler,
  IBeginDragHandler,
  IDragHandler,
  IEndDragHandler {

  float score = 0;
  float highScore = 0;

  Text scoreText;
  Text hiScoreText;
  GameObject tryAgain;

  Player player;
  EndlessRooms endless;
  GameObject touchBackground;

  // Start is called before the first frame update
  void Start() {
    tryAgain = GameObject.Find("TryAgain");
    scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    hiScoreText = GameObject.Find("HiScoreText").GetComponent<Text>();

    scoreText.text = "";
    hiScoreText.text = "";
    
    touchBackground = GameObject.Find("TouchBackground");
    player = GetComponentInChildren<Player> ();
    endless = GetComponentInChildren<EndlessRooms> ();

    Tileset.Instance().LoadResources();
    RoomTemplates.Instance().LoadResources();

    StartGame();
  }

  // Update is called once per frame
  void Update() {
    float dt = Time.deltaTime;

    Vector3 v = touchBackground.transform.position;
    v.x = player.transform.position.x;
    v.y = player.transform.position.y;
    touchBackground.transform.position = v;

    // if (player.speedX != 0) {
      score += (dt * 10);
      scoreText.text = "Score:" + (int)score;
    // }

    if (player.isDead) {
      if (score > highScore) {
        highScore = score;
        hiScoreText.text = "High:" + (int)highScore;
      }
      tryAgain.SetActive(true);
    }
  }

  public void StartGame() {
    endless.Init();

    score = 0;
    tryAgain.SetActive(false);

    // position the player
    Room room = endless.rooms[0];
    player.Reset();
    player.transform.position = room.GetTileWorldPosition(room.playerPosition.x, room.playerPosition.y) + new Vector3(0,0.15f,0);

    // reposition camera
    GameObject.Find("Main Camera").GetComponent<FollowCamera>().FollowTarget(false);
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
