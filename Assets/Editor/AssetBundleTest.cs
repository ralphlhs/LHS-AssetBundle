using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections;


public class AssetBundleTest : MonoBehaviour
{
string path = "./Bundle";

    [MenuItem("AssetBundle/Build")]

    public void AssetBundleBuild() {
        //void Start() { 

        //StartCoroutine(LoadAsync(path));
        LoadAsync(path);

        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);
        //}
        //AssetBundleBuild.BuildAssetBunlde(path, BuildAssetBundleOption.None, BuildTarget.StandaloneWindows);
        //BuildPipeline.BuildAssetBunlde(path, BuildAssetBundleOption.None, BuildTarget.StandaloneWindows);
        //EditorUtility.DisplayDialog("에섯 번들 빌드 ", "완료 ", "완료 ");
    }
        void LoadAsync(string path)
        {
            AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
            //리퀘스트가 끝날 때까지 대기
            //yield return request;

            //리퀘스트를 통해 받아온 에셋 번들의 정보를 적용합니다.
            AssetBundle bundle = request.assetBundle;


            //전달받은 번들을 통해 에셋을 로드합니다.
            GameObject prefab = bundle.LoadAsset<GameObject>("MaleCharacterPBR");
            Instantiate(prefab);
        }
    
}
