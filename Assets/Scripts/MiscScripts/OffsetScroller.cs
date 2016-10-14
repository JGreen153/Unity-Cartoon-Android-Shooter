using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{
    //the speed of the scrolling effect on the background
    [SerializeField]
    private float scrollSpeed;

    //the textures offset at the start of the game
    private Vector2 savedOffset;
    //the renderer that displays the image/texture
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        //get the texture offset of the main texture
        savedOffset = r.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        //continuously loop time multiplied by scrollSpeed while ensuring it does not get larger than one 
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        //create a new vector with the offset applied on the x-axis and the default values on the y-axis
        Vector2 offset = new Vector2(x, savedOffset.y);
        //set the main textures offset to the Vector2
        r.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        r.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

}