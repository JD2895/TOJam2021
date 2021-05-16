using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTrackSpriteController : MonoBehaviour
{
    public List<SpriteRenderer> beatRenderers = new List<SpriteRenderer>();

    public Sprite[] jumpPadBeatSprites;
    public Sprite[] playerInputBeatSprites;
    public Sprite[] cannonBeatSprites;

    public void SetBeatSprites(BeatEvent[] allBeats)
    {
        for (int i = 0; i < allBeats.Length; i++)
        {
            switch (allBeats[i])
            {
                case BeatEvent.None:
                    break;
                case BeatEvent.JumpPad:
                    SetSprite(i, jumpPadBeatSprites);
                    break;
                case BeatEvent.PlayerInput:
                    SetSprite(i, playerInputBeatSprites);
                    break;
                case BeatEvent.FireCannon:
                    SetSprite(i, cannonBeatSprites);
                    break;
            }
        }
    }

    private void SetSprite(int i, Sprite[] spriteArray)
    {
        if (i % 4 == 0)
            beatRenderers[i].sprite = spriteArray[1];
        else
            beatRenderers[i].sprite = spriteArray[0];
    }
}
