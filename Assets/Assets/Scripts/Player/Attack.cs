using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Transform origin;
    public LayerMask enemyLayer;
    float dir;
    [HideInInspector]
    public Animator animator;

    [Header("Sword")]

    public GameObject slashPrefab;
    public int swordDamage;
    public float range = 2;
    public float slashDuration = 2;
    RaycastHit2D hit2D;
    bool canSlash = true;

    [Header("Bow")]
    public GameObject arrowPrefab;
    public Image arrowCharge;
    public int maxRange;
    public float arrowForwardSpeed;
    public float arrowVertSpeed;
    float chargeTime;
    float forceMultiplier;
    public float maxChargeTime = 2;
    bool canShoot = true;
    public float rechargeTime;

    [Header("Staff")]
    public GameObject spellPrefab;
    public float spellSpeed;
    public float spellCooldown;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            dir = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetButtonDown("Fire1"))
        {

            BasicAttack(GameManager.Instance.currentSkul);
        }

#region Bow Charged Arrow
        if (Input.GetButton("Fire1") && GameManager.Instance.currentSkul == GameManager.Skulls.Bow && canShoot)
        {

            ChargeArrow();
        }
        if (Input.GetButtonUp("Fire1") && GameManager.Instance.currentSkul == GameManager.Skulls.Bow && canShoot)
        {

            BowBasic();

        }
#endregion
    }

    void BasicAttack(GameManager.Skulls current)
    {
        switch (current)
        {
            case GameManager.Skulls.Sword:
                SwordBasic();
                break;
            case GameManager.Skulls.Staff:
                StaffBasic();
                break;
            default:
                break;
        }
    }

    void SwordBasic()
    {
        if (canSlash)
        {
            RaycastHit2D hit2D;


            StartCoroutine(Slash());
            hit2D = Physics2D.Linecast(transform.position, transform.position + transform.right * range, enemyLayer);
            if (hit2D)
            {
                Debug.Log("ok");

                DealDamage(swordDamage, hit2D.collider.gameObject);
            }
        }

    }

    void BowBasic()
    {
        GameObject myArrow = Instantiate(arrowPrefab, origin.position, Quaternion.Euler(0, transform.rotation.y * 180, -90));
        forceMultiplier = 1 + (chargeTime * .5f);
        myArrow.GetComponent<Rigidbody2D>().AddForce(transform.right * arrowForwardSpeed * forceMultiplier, ForceMode2D.Impulse);
        myArrow.GetComponent<Rigidbody2D>().AddForce(Vector2.up * arrowVertSpeed * forceMultiplier, ForceMode2D.Impulse);
        chargeTime = 0;
        arrowCharge.fillAmount = chargeTime / maxChargeTime;
        canShoot = false;
        StartCoroutine(RechargeArrow());
    }

    void StaffBasic()
    {
        GameObject mySpell = Instantiate(spellPrefab,origin.position, Quaternion.Euler(0, transform.rotation.y * 180, 0));
        mySpell.GetComponent<Rigidbody2D>().AddForce(transform.right * spellSpeed , ForceMode2D.Impulse);
        
    }

    void PrimarySkill()
    {

    }

    void SecondarySkill()
    {

    }


    void DealDamage(int damage, GameObject enemyRef)
    {
        if (enemyRef.tag == "Enemy")
        {
            Debug.Log("uwu");
            enemyRef.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.right * range + transform.position);
    }

    IEnumerator Slash()
    {
        animator.SetBool("Slash", true);
        canSlash = false;
        GameObject slash = Instantiate(slashPrefab, origin.position, origin.rotation);
        yield return new WaitForSeconds(slashDuration);

        animator.SetBool("Slash", false);
        canSlash = true;
    }

    void ChargeArrow()
    {
        if (chargeTime < maxChargeTime)
        {
            chargeTime += Time.deltaTime;
            arrowCharge.fillAmount = chargeTime / maxChargeTime;
        }
        else
        {
            BowBasic();
        }
    }

    IEnumerator RechargeArrow()
    {
        yield return new WaitForSeconds(rechargeTime);
        canShoot = true;
    }
}
