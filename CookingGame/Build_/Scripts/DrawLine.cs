using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public LineRenderer lineRender;
    public EdgeCollider2D edgeCollider;

    List<Vector2> points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawLines(Vector2 point)
    {
        if (points == null)
        {
            points = new List<Vector2>();
      //      SetPoint();

        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);
     //   lineRender.numsPositions = points.Count;
        lineRender.SetPosition(points.Count - 1, point);
        edgeCollider.points = points.ToArray();
    }
}
