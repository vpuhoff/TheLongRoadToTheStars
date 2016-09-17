using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCell : MonoBehaviour {
    public SpriteRenderer  Render;
    public List<Sprite> Sprites = new List<Sprite>();
    // Use this for initialization
    void Start () {
        Random rnd = new Random();
        Render.sprite  = Sprites[Random.Range(0, Sprites.Count)];
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
