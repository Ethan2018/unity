using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapView : MonoBehaviour {

    /// <summary>
    /// 计算位置
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public Vector2 CaculatePos(int index)
    {
        Vector2 result = Vector2.zero;
        Vector2 tmpRate = cameraView.GetRate(index);
        result.x = rectTransform.sizeDelta.x * tmpRate.x;
        result.y = rectTransform.sizeDelta.y * tmpRate.y;
        return result ;
    }
    RectTransform rectTransform;
    CameraView cameraView; 
	// Use this for initialization
	void Start () {
        cameraView = Camera.main.GetComponent<CameraView>();
        rectTransform = transform.GetComponent<RectTransform>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}




    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        //// Set transformation matrix for drawing to
        //// match our transform
        GL.MultMatrix(transform.localToWorldMatrix);

        //GL.LoadOrtho();
        // Draw lines
        GL.Begin(GL.LINES);

        GL.Color(Color.red);
        for (int i = 1; i < 5; i++)
        {
            Vector2 tmpFront = CaculatePos(i - 1);
            Vector2 tmpBack = CaculatePos(i);
            GL.Vertex3(tmpFront.x, tmpFront.y, 0);
            GL.Vertex3(tmpBack.x, tmpBack.y, 0);
        }
        //GL.Vertex(Vector3.zero);
        //GL.Vertex(new Vector3(100, 100, 0));

        GL.End();
        GL.PopMatrix();
    }
}
