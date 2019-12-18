using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform_prefab;
    public GameObject spike_platform_prefab;
    public GameObject[] speed_platform_prefabs;
    public GameObject breakable_platform_prefabs;

    public float min_X =-2f, max_X =2f;

    public float platform_spawn_timer = 1.5f;
    public float current_platform_timer;
    private int platform_spawn_counter = 0;

    public void Start()
    {
        current_platform_timer = platform_spawn_timer;
    }

    public void FixedUpdate()
    {
        SpawnPlatforms();
    }
    public void SpawnPlatforms()
    {
        current_platform_timer = current_platform_timer + Time.deltaTime;
        if(current_platform_timer>=platform_spawn_timer)
        {

            platform_spawn_counter++;

            Vector3 _temp = transform.position;
            _temp.x = Random.Range(min_X,max_X);

            GameObject new_platform = null;

            if(platform_spawn_counter<2)
            {
                new_platform = Instantiate(platform_prefab,_temp,Quaternion.identity);

            }
            else if(platform_spawn_counter==2)
            {
                if(Random.Range(0,2)>0)
                {
                    new_platform = Instantiate(platform_prefab,_temp,Quaternion.identity);
                }
                else
                {
                    new_platform = Instantiate(speed_platform_prefabs[Random.Range(0,2)],_temp,Quaternion.identity);
                }
            }
            else if (platform_spawn_counter == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    new_platform = Instantiate(platform_prefab, _temp, Quaternion.identity);
                }
                else
                {
                    new_platform = Instantiate(spike_platform_prefab, _temp, Quaternion.identity);
                }
            }
            else if (platform_spawn_counter == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    new_platform = Instantiate(platform_prefab, _temp, Quaternion.identity);
                }
                else
                {
                    new_platform = Instantiate(breakable_platform_prefabs, _temp, Quaternion.identity);
                }

                platform_spawn_counter = 0;
            }

            if(new_platform)
            {
                new_platform.transform.parent = transform;
            }
            


            current_platform_timer = 0f;

        }
        

    }


}
