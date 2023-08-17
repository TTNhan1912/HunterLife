using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class FLO : MonoBehaviour
{
    public Sprite newSprite, newSprite1, newSprite2, newSprite3, newSprite4, newSprite5, newSprite6; // Hình ảnh mới cần thay đổi

    private SpriteRenderer spriteRenderer;

    private bool isCollect;

    private Color originalColor;
    public Color highlightColor = Color.red;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        StartCoroutine(ChangeSpriteAfterDelay(3.0f));

        isCollect = false;
        originalColor = GetComponent<Renderer>().material.color; // Lấy màu gốc từ Renderer
    }

    private void Update()
    {
        if (isCollect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider != null && hit.collider.gameObject == gameObject) 
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    private IEnumerator ChangeSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite; 

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite1; 

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite2;

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite3; 

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite4; 

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite5; 

        yield return new WaitForSeconds(delay); 
        spriteRenderer.sprite = newSprite6; 

        isCollect = true;

    }
    private void OnMouseEnter()
    {
        if (isCollect)
        {
            GetComponent<Renderer>().material.color = highlightColor;
            
        }
        
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = originalColor; // Khôi phục màu khi chuột rời khỏi
    }

    
}
