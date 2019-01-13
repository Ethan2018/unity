using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        allPoints = new List<Vector3>();
        //图片在内存实例化
        //TestPainter();
        //transform.GetComponent<Renderer>().material.mainTexture = paintText;
	}

    Texture2D paintText;
    //public void TestPainter()
    //{
    //    paintText = new Texture2D(300, 400);
    //    for (int i = 0; i < 20; i++)
    //    {
    //        for (int j = 0; j < 20; j++)
    //        {
    //            paintText.SetPixel(i, j, Color.red);
    //        }
    //    }
    //    paintText.Apply();
    //}
    List<Vector3> allPoints;



    public void GenerateTexture()
    {
        paintText = new Texture2D(300, 400);
        float frontX, frontY, backX, backY;
        Vector3 tmpFront, tmpBack;
        int tmpXX, tmpYY, tmpCount = 50;
        for (int i = 1; i < allPoints.Count; i++)
        {
            tmpFront = allPoints[i - 1];
            tmpBack = allPoints[i];
            frontX = paintText.width * tmpFront.x;
            frontY = paintText.height * tmpFront.y;
            backX = paintText.width * tmpBack.x;
            backY = paintText.height * tmpBack.y;
            for (int j = 0; j < tmpCount; j++)
            {
                tmpXX = (int)Mathf.Lerp(frontX, backX, j / (float)tmpCount); //a*t + b(1-t)
                tmpYY = (int)Mathf.Lerp(frontY, backY, j / (float)tmpCount);
                paintText.SetPixel(tmpXX, tmpYY, Color.red);
            }
        }
        paintText.Apply();
        transform.GetComponent<Renderer>().material.mainTexture = paintText;
    }



	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Vector3 tmpView = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            allPoints.Add(tmpView);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GenerateTexture();
            allPoints.Clear();
        }
	}


    public int lineCount = 100;
    public float radius = 3.0f;

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

        //GL.PushMatrix();
        //// Set transformation matrix for drawing to
        //// match our transform
        //GL.MultMatrix(transform.localToWorldMatrix);

        GL.LoadOrtho();
        // Draw lines
        GL.Begin(GL.LINES);

        GL.Color(Color.red);

        for (int i = 0; i < allPoints.Count; i++)
        {
            Vector3 tmpFront = allPoints[i - 1];
            Vector3 tmpBack = allPoints[i];
            GL.Vertex3(tmpFront.x, tmpFront.y, tmpFront.z);
            GL.Vertex3(tmpBack.x, tmpBack.y, tmpBack.z);
        }

        GL.Vertex3(0.1f, 0.1f, 0);
        GL.Vertex3(0.5f, 0.5f, 0);

        GL.End();
        //GL.PopMatrix();
    }
}
