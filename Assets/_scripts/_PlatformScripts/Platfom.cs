using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platfom : MonoBehaviour
{
    public float platform_moving_speed = 1f;
    public float bounday_y = 6;

    public bool is_platform, is_breakable_platfom, is_spike_platform, is_speed_left_platform, is_speed_right_platform;
    private Animator _anim=null;

    public void Awake()
    {
        if(is_breakable_platfom)
        {
            _anim = GetComponent<Animator>();
        }
    }

    public void FixedUpdate()
    {
        PlatformMove();
    }

    public void PlatformMove()
    {
        Vector2 temp = transform.position;
        temp.y += platform_moving_speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bounday_y)
        {
            gameObject.SetActive(false);
        }
    }//platform move

    public void breakableDeactivate()
    {
        
        Invoke("deactivateGameobject",0.01f);
       // Debug.Log("before invoke");
    }

    public void deactivateGameobject()
    {
       
        gameObject.SetActive(false);
       // Debug.Log("after invoke");
    }

    private void OnTriggerEnter2D(Collider2D _target)
    {
        if(_target.gameObject.CompareTag("Player"))
        {
            if(is_spike_platform)
            {
                _target.transform.position = new Vector2(1000f,1000f);
            }
        }
    }//on trigger Enter

    private void OnCollisionEnter2D(Collision2D _target)
    {
        if(_target.gameObject.CompareTag("Player"))
        {
            if(is_breakable_platfom)
            {
                _anim.Play("break");
            }

            if(is_platform)
            {
                //soundManager.instance.LandSound();
            }
        }

    }// on collision enter


    private void OnCollisionStay2D(Collision2D _target)
    {
        if(_target.gameObject.CompareTag("Player"))
        {
            if(is_speed_left_platform)
            {
                _target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            }
            if (is_speed_right_platform)
            {
                _target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
            }
        }
    }//on collision stay


}//class