using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public bool _isPlatformOnEnd = false;
    public float _PlatformDirection = 1f;
    public float _PlatformYOffset = 2f;
    public float _PlatformXOffset = 0f;

    Vector3 _PlatformInitPos;
    Vector3 _PlatformFinalPos;
    float _platformSpeed = 1f;


    // Start is called before the first frame update
    void Awake()
    {
        _PlatformInitPos = transform.position;
        _PlatformFinalPos = new Vector3(transform.position.x, transform.position.y + _PlatformYOffset, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= _PlatformInitPos.y)
        {
            Debug.Log("chegou no começo");
            //_isPlatformOnEnd = !_isPlatformOnEnd;
            //MoveToEnd();
            //transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y, transform.position.z);
            _PlatformDirection = _PlatformDirection * -1f;

        }
        else if (transform.position.y >= _PlatformFinalPos.y)
        {
            Debug.Log("chegou no final");

            //_isPlatformOnEnd = !_isPlatformOnEnd;
            //MoveToInit();
            _PlatformDirection = _PlatformDirection * -1f;

        }

        transform.position = new Vector3(transform.position.x , transform.position.y + (-_platformSpeed * _PlatformDirection * Time.deltaTime), transform.position.z);

    }

    void MoveToInit()
    {
        //if (transform.position != _PlatformInitPos)
            transform.position = Vector3.MoveTowards(transform.position, _PlatformInitPos, _platformSpeed * Time.deltaTime);
    }
    void MoveToEnd()
    {
        //if (transform.position != _PlatformFinalPos)
            transform.position = Vector3.MoveTowards(transform.position, _PlatformFinalPos, _platformSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

            Debug.Log("caiu na plataforma");
            collision.gameObject.transform.SetParent(this.gameObject.transform);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            Debug.Log("saiu da plataforma");

        collision.gameObject.transform.SetParent(null);

    }
}
