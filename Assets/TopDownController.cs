using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour {
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;

    // sprite lists for different directions 
    // we reuse lists by flipping them to get 8 total directions
    // n, ne, e, se, s, sw, w, nw
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    public float walkSpeed;
    public float frameRate;

    float idleTime;
    Vector2 direction;
    Sprite idleSprite = null;
    // Start is called before the first frame update
    void Start() {
        // nothing to do here yet...
    }

    // Update is called once per frame
    void Update() {
        // get direction based on input
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        // set walk based on direction
        body.velocity = direction * walkSpeed;
        handleSpriteFlip();  // mirror current sprite (along y axis) if needed
        
        List<Sprite> directionSprites = getSpriteDirection();   // returns lists of all sprites facing curr direction
        if (directionSprites != null) {
            float playTime = Time.time - idleTime;              // time since we started walking (in seconds)
            int totalFrames = (int)(playTime * frameRate);      // total frames since we started
            int frame =  totalFrames % directionSprites.Count;  // current frame
            spriteRenderer.sprite = directionSprites[frame];    // set current sprite based on current frame to animate
            idleSprite = directionSprites[1];                   // record the idle sprite for this direction
                                                                // we don't want animation to stop while the sprite is walking
        } else {
            idleTime = Time.time;
            if (idleSprite != null) spriteRenderer.sprite = idleSprite;
        }
    }

    // Purpose: mirror sprite, this allows us to reuse sprite lists
    // for eg. all sprites for moving right can be used for moving left by 
    //         mirroring them along the y-axis
    void handleSpriteFlip() {
        if (!spriteRenderer.flipX && direction.x < 0) {
            spriteRenderer.flipX = true;
        } else if (spriteRenderer.flipX && direction.x > 0) {
            spriteRenderer.flipX = false;
        }
    }

    // Purpose: return list of all sprite frames for the current direction
    List<Sprite> getSpriteDirection() {
        List<Sprite> selectedSprites = null;
        if (direction.y > 0) { // moving north
            if (Mathf.Abs(direction.x) > 0) {
                selectedSprites = neSprites;
            } else {
                selectedSprites = nSprites;
            }
        } else if (direction.y < 0) { // moving south
            if (Mathf.Abs(direction.x) > 0) {
                selectedSprites = seSprites;
            } else {
                selectedSprites = sSprites;
            }
        } else {  // east/west
            if (Mathf.Abs(direction.x) > 0) {
                selectedSprites = eSprites;
            }
        }

        return selectedSprites;
    }
}
