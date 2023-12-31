using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector3 startPt;
    private Vector3 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        if (Q2a)
            Question2a();
        if (Q2b)
            CalculateGameDimensions();
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            CalculateGameDimensions();
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        // Sets the overall dimension of the screen.
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(5, 0);
        endPt = new Vector2(2, 3);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);

    }

    void Question2b(int n)
    {
        //maxX = 5;
        //minX = -5;
        minX = -maxX;

        //maxY = 5;
        //minY = -5;
        minY = -maxY;


        for (int i = 0; i < n; i++)
        {
            startPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));
            endPt = new Vector2(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }

    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            DebugExtension.DebugArrow(
                new Vector3(0, 0, 0),
                new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-maxY, maxY)),
                Color.white,
                60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(new Vector3(a.x, a.y), b.ToUnityVector3(), Color.green, 60f);

        float magnitude_A = a.Magnitude();
        float magnitude_B = b.Magnitude();
        float magnitude_C = c.Magnitude();

        Debug.Log("Magnitude of a = " + magnitude_A.ToString("F2"));
        Debug.Log("Magnitude of a = " + magnitude_B.ToString("F2"));
        Debug.Log("Magnitude of a = " + magnitude_C.ToString("F2"));
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = a * 2;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(new Vector3(1,0), b.ToUnityVector3(), Color.green, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        HVector2D normalisedVec = a;
        normalisedVec.Normalize();
    
        DebugExtension.DebugArrow(new Vector3(1,0), normalisedVec.ToUnityVector3(), Color.green, 60f);

        float magnitude_NormA = normalisedVec.Magnitude();
        Debug.Log("Magnitude of a = " + magnitude_NormA.ToString("F2"));
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        HVector2D proj = c.Projection(v1);

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
