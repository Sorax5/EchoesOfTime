using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeinitaliser : MonoBehaviour
{
    [SerializeField]
    private GameObject life;

    private List<GameObject> lifeList = new List<GameObject>();
    
    
    // Start is called before the first frame update
    void Start()
    {
        lifeList.Add(life);
    }
    
    public void removeLife()
    {
        if (lifeList.Count > 0)
        {
            GameObject lifeToRemove = lifeList[lifeList.Count - 1];
            lifeList.Remove(lifeToRemove);
            Destroy(lifeToRemove);
        }
    }
    
    public void generateLife(int lifes)
    {
        for (int i = 0; i < lifes; i++)
        {
            addLife();
        }
    }
    
    private void addLife()
    {
        // copy the life object
        GameObject newLife = Instantiate(life, life.transform.parent);
        // add it to the list
        lifeList.Add(newLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
