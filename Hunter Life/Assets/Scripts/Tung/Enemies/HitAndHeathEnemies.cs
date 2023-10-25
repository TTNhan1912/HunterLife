using UnityEngine;
using UnityEngine.UI;

public class HitAndHeathEnemies : MonoBehaviour
{
    public Image blood;
    public float hit;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var name = collision.gameObject.tag;

        //khi bị tấn công
        if (collision.gameObject.CompareTag("boom"))
        {
            BeingAttacked();
        }
    }

    private void BeingAttacked()
    {

        float oneTouch = 1f / hit;

        blood.fillAmount = blood.fillAmount - oneTouch;
        blood.fillAmount = blood.fillAmount;
        if(blood.fillAmount < 0.1f)
        {
           animator.SetBool("isDie", true);

            DestroyEnemiesWithTag(gameObject.tag);
            Debug.Log("Tag: " + gameObject.tag);
        }
    }

    private void DestroyEnemiesWithTag(string tag)
    {
        if (tag == "") { return; }

        switch (tag)
        {
            case "enemy1" :
                Destroy(gameObject, 1.5f);
                break;
            case "enemy3":
                Destroy(gameObject, 1.1f);
                break;
            case "enemy4":
                Destroy(gameObject, 1.5f);
                break;
            default:
                Debug.Log("không có tên quái này");
                break;
        }
    }
}
