using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HitAndHeathEnemies : MonoBehaviour
{
    public Image blood;
    public float hit;
    private Animator animator;

    [SerializeField] private SimpleFlash flashEffect;
    [SerializeField] private Transform viTriPopUpDame;
    public GameObject PopUpDame;
    public TMP_Text popuptext;

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
            BeingAttacked( 0.25f );
        }
        if (collision.gameObject.CompareTag("axe"))
        {
            BeingAttacked( 0.2f );
        }
    }

    private void BeingAttacked(float dame)
    {
       //  Vector3 originPosotion = transform.position;
        float oneTouch = dame;

        blood.fillAmount = blood.fillAmount - oneTouch;
        blood.fillAmount = blood.fillAmount;

        
         flashEffect.Flash();
         popuptext.text=(oneTouch*100).ToString();
         Instantiate(PopUpDame, viTriPopUpDame.position, viTriPopUpDame.rotation);
        if(blood.fillAmount < 0.1f)
        {
            animator.SetBool("isDie", true);
            Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}
