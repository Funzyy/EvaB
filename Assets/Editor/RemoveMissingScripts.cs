using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using System.Linq;

public class RemoveMissingScripts : MonoBehaviour
{
    [MenuItem("Tools/Remove Missing Scripts in Scene")]
    private static void RemoveMissingScriptsInScene()
    {
        int count = 0;

        // Holen der Root-GameObjects in der Szene
        foreach (GameObject rootObj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            count += RemoveMissingScriptsRecursively(rootObj);
        }

        // Speichern der Änderungen, um sicherzustellen, dass sie auch auf Prefabs angewendet werden
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());

        Debug.Log($"Entfernt {count} fehlende Skript-Komponenten aus der Szene.");
    }

    private static int RemoveMissingScriptsRecursively(GameObject obj)
    {
        int count = 0;

        // Entfernt fehlende Skripte und zählt sie
        count += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(obj);

        // Alle Kinder-Objekte durchsuchen, auch deaktivierte
        foreach (Transform child in obj.transform)
        {
            count += RemoveMissingScriptsRecursively(child.gameObject);
        }

        // Wenn das Objekt ein Prefab ist, dann die Änderungen im Prefab speichern
        if (PrefabUtility.IsPartOfPrefabAsset(obj))
        {
            PrefabUtility.RecordPrefabInstancePropertyModifications(obj);
        }

        return count;
    }
}
