using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ButtonTapScript : MonoBehaviour
{

    public GameObject parent;
    public GameObject points;
    public GameObject bee;
    public int _petalNumber;
    private int _prevPetalNumber;
    private bool _isMouseOnButton;
    public bool _isTriggerEntered;
    private int _hp = 3;
    private int _points = 0; 
    public GameObject prefabSpawner;
    
    void Start()
    {
        _petalNumber = 1;
        _prevPetalNumber = 0;
        PaintPetal();
    }

    private void OnMouseEnter()
    {
        _isMouseOnButton = true;
    }

    private void OnMouseExit()
    {
        _isMouseOnButton = false;
    }

    private void OnMouseDown()
    {
        if (_isMouseOnButton && _isTriggerEntered)
        {
            _prevPetalNumber = _petalNumber;
            while (_petalNumber == _prevPetalNumber)
            {
                _petalNumber = Random.Range(0, 11);
            }
            PaintPetal();
            _isTriggerEntered = false;
            bee.GetComponent<BeeScript>().speed *= 1.05f;
            _points++;
        }
        else if (_isMouseOnButton && !_isTriggerEntered && _hp > 0)
        {
            var heart = points.gameObject.transform;
            Destroy(heart.GetChild(_hp - 1).gameObject);
            _hp--;
            if (_hp == 0)
            {
                Instantiate(points, new Vector3(-1.2f,-3.5f,-0.045f), Quaternion.identity);
                _hp = 3;
                SceneManager.LoadScene("RestartMenu");
            }
        }
    }


    // ReSharper disable Unity.PerformanceAnalysis
    void PaintPetal()
    {
        var petal = parent.gameObject.transform.GetChild(_petalNumber);
        var prevPetal = parent.gameObject.transform.GetChild(_prevPetalNumber);
        petal.GetComponent<SpriteRenderer>().color = Color.gray;
        petal.GetComponent<CapsuleCollider2D>().isTrigger = true;
        prevPetal.GetComponent<SpriteRenderer>().color = Color.white;
        prevPetal.GetComponent<CapsuleCollider2D>().isTrigger = false;
    }
}
