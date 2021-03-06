using UnityEditor;
public static class Extensions
{
    #if UNITY_EDITOR
    public static T[] GetAllInstances<T>() where T : UnityEngine.Object
    {
        string[] guids = AssetDatabase.FindAssets("t" + typeof(T).Name);
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }
        return a;
    }
    #endif
}