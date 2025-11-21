using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour
{

    public Bounds[] bounds;
    public GameObject Player;
    [Header("LineRenderer")]
    public LineRenderer line;
    public Material mat;
    public int nodeCount;
    public float width;
    public List<Vector2> nodePositions = new List<Vector2>();
    public float xPlus;

    [Header("Physics")]
    [SerializeField] private float maxForce;
    public float[] force;
   [SerializeField] private int[] dir;
    [SerializeField] private int[] tochedTime;
    [SerializeField] private int maxTochedTime;

    [Header("Meshes")]
    [SerializeField] private GameObject[] meshobjects;
    [SerializeField] private Mesh[] meshes;
    public GameObject watermesh;
    public int WaterMeshRange;
    [SerializeField] private float MeshHigh;
    void Start()
    {
        Player = GameObject.Find("Player");
        
      
        line = GetComponent<LineRenderer>();
        line.material = mat;
        line.material.renderQueue = 1000;
        line.positionCount = nodeCount;

        line.SetPosition(0, transform.position);
        nodePositions[0] = transform.position;
        for (int x = 1; x <= nodeCount; x++)
        {
            force[x] = 0.5f;
           // Debug.Log(nodePositions[x - 1].x);
            nodePositions[x] = new Vector2(nodePositions[x - 1].x + 0.5f, nodePositions[x - 1].y);


            line.SetPosition(x, nodePositions[x]);
            bounds[x].center = line.GetPosition(x);
            bounds[x].extents = new Vector2(0.1f, 0.1f);

            
        }


        //line.endWidth = width;
    }

    // Update is called once per frame
    void Update()
    {

       


        for (int i = 0; i <= nodeCount; i++)
        {
            
           


            

          if(Vector2.Distance(bounds[i].center, Player.transform.position) <= 0.3f && dir[i] == 0 && dir[i] == 0 && tochedTime[i] <= 0)
            {
                dir[i] = 1;
               

                if(tag == "Kislota")
                {
                    Player.GetComponent<Stats>().kislota = true;
                }
                
            }
            


            //Вибір напрямку
            if(line.GetPosition(i).y == bounds[i].min.y)
            {
               
                dir[i] = 2;
                force[i] /= 1.5f;

                if (dir[i + 1] == 0)
                {
                    dir[i + 1] = 1;
                    force[i + 1] /= 1.1f;
                }

                if (dir[i - 1] == 0)
                {
                    dir[i - 1] = 1;
                    force[i - 1] /= 1.1f;
                }
                //dir[i - 1] = 2;

                
               
                //force[i - 1] /= 1.1f;

            }

            else if(line.GetPosition(i).y == bounds[i].max.y)
            {
                dir[i] = 1;
                force[i] /= 1.5f;

                if (dir[i+1] == 0)
                {
                    dir[i + 1] = 2;
                    force[i + 1] /= 1.1f;
                }

                if (dir[i - 1] == 0)
                {
                    dir[i - 1] = 2;
                    force[i - 1] /= 1.1f;
                }

                //dir[i - 1] = 1;


                
               
                //force[i - 1] /= 1.1f;
            }
         
            //Рух
            switch (dir[i])
            {
                case 0:

                    if(Vector2.Distance(bounds[i].center, Player.transform.position) > 0.3f)
                    {
                        tochedTime[i] = 0;
                    }
                   

                    break;

                case 1:

                   

                    line.SetPosition(i, Vector2.MoveTowards(line.GetPosition(i), new Vector2(line.GetPosition(i).x, bounds[i].min.y), force[i] * Time.deltaTime));
                    tochedTime[i] ++;
                    // line.SetPosition(i + 1, Vector2.MoveTowards(line.GetPosition(i + 1), new Vector2(line.GetPosition(i + 1).x, bounds[i + 1].min.y), force[i + 1] / 1.01f * Time.deltaTime));
                    //  line.SetPosition(i + 1, Vector2.MoveTowards(line.GetPosition(i + 1), new Vector2(line.GetPosition(i + 1).x, bounds[i + 1].min.y), force[i -1]  / 1.01f * Time.deltaTime));


                    break;

                case 2:

                   

                    line.SetPosition(i, Vector2.MoveTowards(line.GetPosition(i), new Vector2(line.GetPosition(i).x, bounds[i].max.y), force[i] * Time.deltaTime));
                    tochedTime[i]++;
                    //  line.SetPosition(i - 1, Vector2.MoveTowards(line.GetPosition(i - 1), new Vector2(line.GetPosition(i - 1).x, bounds[i - 1].max.y), force[i-1] / 1.01f * Time.deltaTime));
                    //  line.SetPosition(i - 1, Vector2.MoveTowards(line.GetPosition(i - 1), new Vector2(line.GetPosition(i - 1).x, bounds[i - 1].max.y), force[i - 1] / 1.01f * Time.deltaTime));

                    break;
            }
            
               

                if(force[i] <= 0.1 && Vector2.Distance(line.GetPosition(i), bounds[i].center) <= 0.01f)
            {
                Debug.LogError("Fuck");
                line.SetPosition(i, nodePositions[i]);
                dir[i] = 0;
                force[i] = maxForce;
                
               
            }

           
                if(tochedTime[i] >= maxTochedTime)
            {
                tochedTime[i] = 0;
            }

            /*   if(line.GetPosition(i + 1 ).y > bounds[i + 1].min.y)
               {
                   Debug.Log("Equal");
                   line.SetPosition(i + 1, Vector2.MoveTowards(line.GetPosition(i + 1), new Vector2(line.GetPosition(i + 1 ).x, bounds[i + 1].min.y), force / 2f * Time.deltaTime));
               }

               if (line.GetPosition(i - 1).y > bounds[i-1].min.y)
               {
                   Debug.Log("Equal");
                   line.SetPosition(i - 1, Vector2.MoveTowards(line.GetPosition(i - 1), new Vector2(line.GetPosition(i - 1).x, bounds[i - 1].min.y), force / 2f * Time.deltaTime));
               }*/
            // MeshRenderer(i);

        }



        for (int i = 0; i < nodeCount; i++)
        {
            MeshRenderer(i);

        }

    }

   private void MeshRenderer(int i)
    {
        meshes[i] = new Mesh();
       
        Vector3[] Vertices = new Vector3[nodePositions.Count];
        Vertices[0] = new Vector2(line.GetPosition(i).x, line.GetPosition(i).y);
        Vertices[1] = new Vector2(line.GetPosition(i + 1).x, line.GetPosition(i+1).y);
        Vertices[2] = new Vector2(line.GetPosition(i).x , line.GetPosition(i).y - MeshHigh);
        Vertices[3] = new Vector2(line.GetPosition(i + 1).x , line.GetPosition(i + 1).y - MeshHigh);


       



        // Debug.Log(new Vector2(line.GetPosition(i).x - MeshHigh, line.GetPosition(i).y - MeshHigh));

        Vector2[] UVs = new Vector2[4];
        UVs[0] = new Vector2(0, 1);
        UVs[1] = new Vector2(1, 1);
        UVs[2] = new Vector2(0, 0);
        UVs[3] = new Vector2(1, 0);

        int[] tris = new int[6] { 0, 1, 3, 3, 2, 0 };
     

        meshes[i].vertices = Vertices;
        meshes[i].uv = UVs;
        meshes[i].triangles = tris;
       

        if (WaterMeshRange < nodeCount - 1)
        {
            
            meshobjects[i] = Instantiate(watermesh, Vector3.zero, Quaternion.identity) as GameObject;

         
           // Debug.Log(WaterMeshRange);

            meshobjects[i].transform.parent = transform;
            WaterMeshRange += 1;
        }

        for (int x = 0; x < 4; x++)
        {
           
           
        }

        meshobjects[i].GetComponent<MeshFilter>().mesh = meshes[i];
       

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i <= nodeCount; i++)
        {

        }

    }
}
