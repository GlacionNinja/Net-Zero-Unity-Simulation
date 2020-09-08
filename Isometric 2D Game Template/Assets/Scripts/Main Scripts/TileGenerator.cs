using UnityEngine;
using System.Collections;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject Tile;
    [SerializeField]
    private GameObject TileParent;
    [SerializeField]
    private GameObject SpaceTile1;
    [SerializeField]
    private GameObject SpaceTile2;

    private float a;
    private float b;

    void Start()
    {
        /* for (int z = 0; z < 15; z++)
        {
            for (int x = 0; x < 15; x++)
            {
                if ((x + z) % 2 == 0)
                {
                    GameObject TileClone = (GameObject)Instantiate(Tile, new Vector3(Tile.GetComponent<Transform>().position.x - x, -1, Tile.GetComponent<Transform>().position.z - z), Quaternion.identity);
                    GameObject Clone = (GameObject)Instantiate(SpaceTile1, new Vector3(Tile.GetComponent<Transform>().position.x - x, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z), Quaternion.identity);
                    Clone.GetComponent<RectTransform>().Rotate(90, 45, 0);
                    TileClone.transform.parent = TileParent.transform;
                    Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                    Clone.transform.localScale = Scale;
                    Clone.transform.parent = TileParent.transform;
                }

                if ((x + z) % 2 == 1)
                {
                    GameObject TileClone = (GameObject)Instantiate(Tile, new Vector3(Tile.GetComponent<Transform>().position.x - x, -1, Tile.GetComponent<Transform>().position.z - z), Quaternion.identity);
                    GameObject Clone = (GameObject)Instantiate(SpaceTile2, new Vector3(Tile.GetComponent<Transform>().position.x - x, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z), Quaternion.identity);
                    Clone.GetComponent<RectTransform>().Rotate(90, 45, 0);
                    TileClone.transform.parent = TileParent.transform;
                    Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                    Clone.transform.localScale = Scale;
                }
            }
        }

        for (int z = 17; z < 33; z++)
        {
            for (int x = 0; x < 54; x++)
            {
                GameObject Clone2 = (GameObject)Instantiate(BlueTile, new Vector3(Tile.GetComponent<Transform>().position.x - x + 19, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z + 1), Quaternion.identity);
                Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                Clone2.transform.localScale = Scale;
            }
        }
        */
        for (int z = 0; z < 4; z++)
        {
            for (int x = 0; x < 4; x++)
            {
                a++;
                if (a == 9)
                {
                    a = 1;
                    b++;
                }
                {
                    GameObject Clone2 = (GameObject)Instantiate(SpaceTile1, new Vector3(-11.98f + 2.5f * (b-1), -0.6899f, -12.03f + 2.5f * (a-1)), Quaternion.identity);
                    Clone2.GetComponent<Transform>().Rotate(90, 45, 0);
                    Clone2.GetComponent<Transform>().localScale = new Vector3(4.7f, 4.7f, 1f);
                }
               
            }
        }

        
        /* for (int z = 0; z < 15; z++)
         {
             for (int x = 0; x < 15; x++)
             {
                 b++;
                 if (b >= 15)
                 {
                     b = 0;
                     a++;
                 }

                 if ((a + b) % 2 == 0)
                 {
                     GameObject Clone2 = (GameObject)Instantiate(SpaceTile1, new Vector3(-11.43f + 0.99f * b, -0.6899f, -11.43f + 0.99f * a), Quaternion.identity);
                     Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                 }

                 else
                 {

                     GameObject Clone2 = (GameObject)Instantiate(SpaceTile2, new Vector3(-11.43f + 0.99f * b, -0.6899f, -11.43f + 0.99f * a), Quaternion.identity);
                     Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                 }

             }
         }*/
        /*

        for (int z = -2; z > -17; z--)
        {
            for (int x = 0; x < 54; x++)
            {
                GameObject Clone2 = (GameObject)Instantiate(BlueTile, new Vector3(Tile.GetComponent<Transform>().position.x - x + 19, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z), Quaternion.identity);
                Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                Clone2.transform.localScale = Scale;
            }
        }

        for (int x = 17; x < 36; x++)
        {
            for (int z = 0; z < 18; z++)
            {
                GameObject Clone2 = (GameObject)Instantiate(BlueTile, new Vector3(Tile.GetComponent<Transform>().position.x - x + 1, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z + 1), Quaternion.identity);
                Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                Clone2.transform.localScale = Scale;
            }
        }

        for (int x = -1; x > -19; x--)
        {
            for (int z = 0; z < 18; z++)
            {
                GameObject Clone2 = (GameObject)Instantiate(BlueTile, new Vector3(Tile.GetComponent<Transform>().position.x - x + 1, Tile.GetComponent<Transform>().position.y + Tile.GetComponent<Renderer>().bounds.size.y / 2 + 0.1f, Tile.GetComponent<Transform>().position.z - z + 1), Quaternion.identity);
                Clone2.GetComponent<RectTransform>().Rotate(90, 45, 0);
                Vector3 Scale = new Vector3(2.435f, 2.435f, 1);
                Clone2.transform.localScale = Scale;
                Clone2.transform.parent = TileParent.transform;
            }
        } */
    }
}