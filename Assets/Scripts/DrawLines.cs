using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{  
    public Material lineMatA, lineMatB;
    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius, radius2;
    List<Vector3> coordinates = new List<Vector3>();
    List<Vector3> coordinates2 = new List<Vector3>();

    void Start()
    {
        CalcCircle(7.5f, 2.5f);
        OnPostRender();
    }

    private void OnPostRender()
    {
        for (int i = 1; i < vertexCount + 1; i++)
        {
            GL.Begin(GL.LINES);
            lineMatA.SetPass(0);
            GL.Color(new Color(lineMatA.color.r, lineMatA.color.g, lineMatA.color.b, lineMatA.color.a));
            GL.Vertex(coordinates[i]);
            GL.Vertex(coordinates[i-1]);
            GL.End();

            GL.Begin(GL.LINES);
            lineMatB.SetPass(0);
            GL.Color(new Color(lineMatB.color.r, lineMatB.color.g, lineMatB.color.b, lineMatB.color.a));
            GL.Vertex(coordinates2[i]);
            GL.Vertex(coordinates2[i - 1]);
            GL.End();
        }

    }

    void CalcCircle(float radius, float radius2)
    {
        float theta = 0f;
        float deltaTheta = (2f * Mathf.PI) / 40f;
        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), 0f, radius * Mathf.Sin(theta));
            Vector3 pos2 = new Vector3(radius2 * Mathf.Cos(theta), 0f, radius2 * Mathf.Sin(theta));

            coordinates.Add(pos);
            coordinates2.Add(pos2);
            theta += deltaTheta;
        }
    }
}
