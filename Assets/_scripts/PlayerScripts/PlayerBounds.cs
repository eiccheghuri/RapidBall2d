using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [SerializeField]
    private float min_X = -2.6f, max_x = 2.6f,min_Y=-5.6f;

    [SerializeField]
    private bool is_out_of_bounds=false;

    public void Update()
    {
        CheckBounds();
    }

    public void CheckBounds()
    {
        Vector2 _temp = transform.position;

        if(_temp.x>max_x)
        {
            _temp.x = max_x;
        }
        else if(_temp.x<min_X)
        {
            _temp.x = min_X;
        }

        transform.position = _temp;

        if(_temp.y>=min_Y)
        {
            if(!is_out_of_bounds)
            {
                is_out_of_bounds = true;
            }

        }

    }//check bounds

    private void OnTriggerEnter2D(Collider2D _target)
    {
        if(_target.gameObject.CompareTag("TopSpikes"))
        {
            transform.position = new Vector2(1000f,1000f);
        }
    }


}
