using UnityEngine;
using System.Collections;

public class OffsetScroller : MonoBehaviour
{

    [SerializeField]
    private float scrollSpeed;

    private Vector2 savedOffset;
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        savedOffset = r.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(x, savedOffset.y);
        r.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }

    void OnDisable()
    {
        r.sharedMaterial.SetTextureOffset("_MainTex", savedOffset);
    }

}