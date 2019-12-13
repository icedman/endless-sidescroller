using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoomTemplates {

  /*
    room templates are 24x12
  */
  public class Template {
    public List<string> lines;

    public Template() {
      lines = new List<string> ();
    }
  }

  static RoomTemplates _instance = null;

  public List<Template> templates;

  static public RoomTemplates Instance() {
    if (_instance == null) {
      _instance = new RoomTemplates();
    }
    return _instance;
  }

  RoomTemplates() {
    templates = new List<Template> ();
  }

  public void LoadResources () {
    TextAsset roomDefs = Resources.Load<TextAsset> ("rooms");

    string[] lines = roomDefs.text.Split ('\n');

    Template t = null;

    foreach(string l in lines) {
      if (l.Length > 0 && l[0] == ';') {
        if (l.Contains("room")) {
          t = new Template();
          templates.Add(t);
        } else {
          t = null;
        }
      }

      if (t == null) {
        continue;
      }

      t.lines.Add(l.PadRight(24));
    }

  }

  public Template GetRoom(int idx) {
    return templates[idx];
  }

}