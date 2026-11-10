using UnityEngine;
using UnityEditor;

public class AddBoxColliders
{
    [MenuItem("Zoo/Add Box Colliders To Selected")]
    static void Add()
    {
        int count = 0;

        foreach (GameObject root in Selection.gameObjects)
        {
            foreach (MeshFilter mf in root.GetComponentsInChildren<MeshFilter>())
            {
                if (mf.sharedMesh == null) continue;
                if (mf.GetComponent<Collider>() != null) continue;

                BoxCollider bc = Undo.AddComponent<BoxCollider>(mf.gameObject);
                bc.center = mf.sharedMesh.bounds.center;
                bc.size = mf.sharedMesh.bounds.size;
                count++;
            }
        }

        Debug.Log("Added " + count + " box colliders");
    }
}