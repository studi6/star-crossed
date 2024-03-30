using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Dialogue/New Dialogue Container")]
public class DialogueText : ScriptableObject
{
    public string[] speakerNames;

    [TextArea(5,10)]
    public string[] paragraphs;

    public Sprite[] portraitImages;
    //todo: add portrait image
}
