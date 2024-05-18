using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

using Point = UnityEngine.Vector2;


public class LineSimplification : MonoBehaviour
{
    public Camera _mainCamera;
    private Point _FirstPoint;
    private Point _LastPoint;
    private List<Point> pointList = new List<Point>();
    // Using Vector2 for points
     private static double PerpendicularDistance(Point pt, Point lineStart, Point lineEnd)
    {
        double dx = lineEnd.x - lineStart.x;
        double dy = lineEnd.y - lineStart.y;

        // Normalize
        double mag = Math.Sqrt(dx * dx + dy * dy);
        if (mag > 0.0)
        {
            dx /= mag;
            dy /= mag;
        }

        double pvx = pt.x - lineStart.x;
        double pvy = pt.y - lineStart.y;

        // Get dot product (project pv onto normalized direction)
        double pvdot = dx * pvx + dy * pvy;

        // Scale line direction vector and subtract it from pv
        double ax = pvx - pvdot * dx;
        double ay = pvy - pvdot * dy;

        return Math.Sqrt(ax * ax + ay * ay);
    }

    private static void RamerDouglasPeucker(List<Point> pointList, double epsilon, List<Point> output)
    {
        if (pointList.Count < 2)
        {
            throw new ArgumentOutOfRangeException("Not enough points to simplify");
        }

        // Find the point with the maximum distance from line between the start and end
        double dmax = 0.0;
        int index = 0;
        int end = pointList.Count - 1;
        for (int i = 1; i < end; ++i)
        {
            double d = PerpendicularDistance(pointList[i], pointList[0], pointList[end]);
            if (d > dmax)
            {
                index = i;
                dmax = d;
            }
        }

        // If max distance is greater than epsilon, recursively simplify
        if (dmax > epsilon)
        {
            List<Point> recResults1 = new List<Point>();
            List<Point> recResults2 = new List<Point>();
            List<Point> firstLine = pointList.Take(index + 1).ToList();
            List<Point> lastLine = pointList.Skip(index).ToList();
            RamerDouglasPeucker(firstLine, epsilon, recResults1);
            RamerDouglasPeucker(lastLine, epsilon, recResults2);

            // build the result list
            output.AddRange(recResults1.Take(recResults1.Count - 1));
            output.AddRange(recResults2);
            if (output.Count < 2) throw new Exception("Problem assembling output");
        }
        else
        {
            // Just return start and end points
            output.Clear();
            output.Add(pointList[0]);
            output.Add(pointList[pointList.Count - 1]);
        }
    }
    private static void VerificationCarre(List<Point> PointList){
        if((Math.Abs(PointList[0].x - PointList[1].x) < 0.5) || (Math.Abs(PointList[0].y - PointList[1].y) < 0.5) && (Math.Abs(PointList[2].x - PointList[1].x) < 0.5) || (Math.Abs(PointList[2].y - PointList[1].y) < 0.5) 
            && (Math.Abs(PointList[2].x - PointList[3].x) < 0.5) || (Math.Abs(PointList[2].y - PointList[3].y) < 0.5) && (Math.Abs(PointList[3].x - PointList[0].x) < 0.5) || (Math.Abs(PointList[3].y - PointList[0].y) < 0.5)){
            Debug.Log("IS square");
        }
        else {
            Debug.Log("Not square");
        }
    }
    private void Start()
    {


    }

   

    void Update()
    {
        
        
        if (Input.GetMouseButton(1))
        
        {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         // Get mouse position in screen coordinates
        Vector2 screenPosition = Input.mousePosition;
        
        // Convert screen coordinates to world coordinates
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        
        // Output mouse positions to the console
        pointList.Add(worldPosition);
        Debug.Log($"World Position: {worldPosition}");   
        }
        
        else if(pointList.Count>1){
            foreach( var x in pointList) {
                Debug.Log( x.ToString());
                }
            List<Point> pointListOut = new List<Point>();
            RamerDouglasPeucker(pointList, 1.0f, pointListOut);

            Debug.Log("Points remaining after simplification:");

            foreach (var p in pointListOut)
            {
                Debug.Log(p);
            }
            Debug.Log("premer et dernier pts");
            _FirstPoint = pointListOut[0];
            _LastPoint = pointListOut[^1];
            if(Math.Abs(_FirstPoint.x-_LastPoint.x) < 0.5 && Math.Abs(_FirstPoint.y-_LastPoint.y) < 0.5){
            if(pointListOut.Count-1 == 4){
                pointListOut.RemoveAt(pointListOut.Count-1);
                VerificationCarre(pointListOut);
            }
            else if(pointListOut.Count-1 == 3){
                Debug.Log("Is triangle");
            }
            else{
                Debug.Log("WTF are u!!");
            }
            }
            if(pointListOut.Count == 2){
                Debug.Log("Is Line");
            }
            
            pointList.Clear();

        }
    
    }
}

