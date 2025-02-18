using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

public class AddressablleTest : MonoBehaviour
{
    [SerializeField] Image image;
    AsyncOperationHandle Handle;

    public void _ClickLoad(AsyncOperationHandle op, Exception ex)
    {
        if (op.Status == AsyncOperationStatus.Failed)
        {
            Debug.LogError(ex.ToString());
            Addressables.Log($"Failed op : {op.DebugName}");
        }
        else
        {
            Addressables.Log(ex.ToString());
            Addressables.LoadAssetAsync<Sprite>("gameover").Completed +=
                (AsyncOperationHandle<Sprite> Obj) =>
                {
                    Handle = Obj;
                    image.sprite = Obj.Result;
                };
        }
    }

    public void _ClickUnload()
    {
        Addressables.Release(Handle);
        image.sprite = null;
    }
    
}
