using UnityEngine;

public class BackGroundScript : MonoBehaviour
{
    public float scroll_speed = 0.3f;

    private MeshRenderer mesh_renderer;
    public string mesh_material_name;

    // Start is called before the first frame update
    private void Start()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {

        Scroll();
        
    }

    public void Scroll()
    {
        Vector2 _offset = mesh_renderer.sharedMaterial.GetTextureOffset(mesh_material_name);
        _offset.y += scroll_speed * Time.deltaTime;
        mesh_renderer.sharedMaterial.SetTextureOffset(mesh_material_name, _offset);
    }
}