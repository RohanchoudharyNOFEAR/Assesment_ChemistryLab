using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flask : MonoBehaviour
{
    public Animator ParentAnim;
    public Animator FlaskAChildAnim;
    public Animator FlaskBChildAnim;
    public Animator PlayerAnimator;

    [SerializeField]
    private bool FlaskAtoBeTitrated = false;
    [SerializeField]
    private bool FlaskBtoBeTitrated = false;

    // Start is called before the first frame update
    void Start()
    {
        ParentAnim.enabled = false;
        FlaskAChildAnim.enabled = false;
        FlaskBChildAnim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "TestTube")
        {
            Debug.Log("collision");
            if (Input.GetMouseButtonUp(0))
            {
                if (this.gameObject.CompareTag("FlaskA"))
                {
                    if (FlaskAtoBeTitrated == false)
                    {
                        ParentAnim.enabled = true;
                        FlaskAChildAnim.enabled = true;

                        //play animation
                        ParentAnim.Play("PouringInA");
                        FlaskAChildAnim.Play("FillingA");
                        PlayerAnimator.Play("ExcitedAnim");
                        Invoke("DisableAnimator", 3f);
                        FlaskAtoBeTitrated = true;
                    }
                }
                else if(this.gameObject.CompareTag("FlaskB"))
                {
                    if (FlaskBtoBeTitrated == false)
                    {
                        ParentAnim.enabled = true;
                        FlaskBChildAnim.enabled = true;

                        //play animation
                        ParentAnim.Play("PouringInB");
                        FlaskBChildAnim.Play("FillingB");
                        PlayerAnimator.Play("ExcitedAnim");
                        Invoke("DisableAnimator", 4f);
                        FlaskBtoBeTitrated = true;
                    }
                }
                            
            }
        }
    }

    void DisableAnimator()
    {
        ParentAnim.enabled = false;
        FlaskAChildAnim.enabled = false ;
        FlaskBChildAnim.enabled = false;
    }

   

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (this.gameObject.CompareTag("FlaskA"))
            {
                if (FlaskAtoBeTitrated == true)
                {
                    ParentAnim.enabled = true;
                    FlaskAChildAnim.enabled = true;
                    //play shaking Animation
                    FlaskAChildAnim.Play("ShakingFlaskA");
                    PlayerAnimator.Play("ExcitedAnim");
                    Invoke("DisableAnimator", 3f);
                }
            }
            else if(this.gameObject.CompareTag("FlaskB"))
            {
                if (FlaskBtoBeTitrated == true)
                {
                    ParentAnim.enabled = true;
                    FlaskBChildAnim.enabled = true;
                    //play shaking Animation
                    FlaskBChildAnim.Play("ShakingB");
                    PlayerAnimator.Play("IrritatedAnim");
                    Invoke("DisableAnimator", 10f);
                }
            }
        }
    }


}
