using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LightingManager : MonoBehaviour
{

    [SerializeField] private float lightingTime =5f;
    [SerializeField] private SpriteRenderer[] ghostRenderers;
    [SerializeField] private Color darkColour;
    private GameObject[] ghosts;
    private Color[] orginalColours;
    private int index=0;
    void Start()
    {
        Invoke("foudre", lightingTime);
    }

    void foudre()
    {
        ghosts = new GameObject[GameObject.FindGameObjectsWithTag("Ghost").Length];
        ghostRenderers = new SpriteRenderer[GameObject.FindGameObjectsWithTag("Ghost").Length];
        orginalColours = new Color[GameObject.FindGameObjectsWithTag("Ghost").Length];

        index = 0;

        ghosts = GameObject.FindGameObjectsWithTag("Ghost");

        foreach(GameObject ghost in ghosts)
        {
            ghostRenderers[index] = ghost.GetComponent<SpriteRenderer>();
            orginalColours[index] = ghostRenderers[index].color;
            index++;
        }

        StartCoroutine(colourChange());

        Invoke("foudre", lightingTime);
    }

    IEnumerator colourChange()
    {
        index = 0;

        foreach(SpriteRenderer ghostRender in ghostRenderers)
        {
            if(ghostRender != null)
            {
                ghostRender.color = new Color(darkColour.r, darkColour.g, darkColour.b, darkColour.a);
            }
        }
        yield return new WaitForSeconds(lightingTime/2);

        foreach(SpriteRenderer ghostRender in ghostRenderers)
        {
            if(ghostRender != null)
            {
                ghostRender.color = new Color(orginalColours[index].r, orginalColours[index].g, orginalColours[index].b, 1);
            }
            index++;
            
        }
    }
}
