//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.InteropServices;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;
//using SFB;

//[RequireComponent(typeof(Button))]
//public class CanvasSampleOpenFileImage : MonoBehaviour, IPointerDownHandler {
//    public RawImage output;

//#if UNITY_WEBGL && !UNITY_EDITOR
//    //
//    // WebGL
//    //
//    [DllImport("__Internal")]
//    private static extern void UploadFile(string gameObjectName, string methodName, string filter, bool multiple);

//    public void OnPointerDown(PointerEventData eventData) {
//        UploadFile(gameObject.name, "OnFileUpload", ".png, .jpg", false);
//    }

//    // Called from browser
//    public void OnFileUpload(string url) {
//        StartCoroutine(OutputRoutine(url));
//    }
//#else
//    //
//    // Standalone platforms & editor
//    //
//    public void OnPointerDown(PointerEventData eventData) { }

//    void Start() {
//        var button = GetComponent<Button>();
//        button.onClick.AddListener(OnClick);
//    }

//    private void OnClick() {
//        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", ".png", false);
//        if (paths.Length > 0) {
//            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
//        }
//    }
//#endif

//    private IEnumerator OutputRoutine(string url) {
//        var loader = new WWW(url);
//        yield return loader;
//        output.texture = loader.texture;
//    }
//}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using SFB; // Пространство имен StandaloneFileBrowser
using UnityEngine.EventSystems;

public class CanvasSampleOpenFileImage : MonoBehaviour, IPointerDownHandler
{
    public RawImage output;

    //
    // Standalone platforms & editor
    //
    public void OnPointerDown(PointerEventData eventData) { }

    void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Title", "", "png", false);
        if (paths.Length > 0)
        {
            StartCoroutine(OutputRoutine(new System.Uri(paths[0]).AbsoluteUri));
        }
    }

    private IEnumerator OutputRoutine(string url)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Ошибка загрузки: " + request.error);
            }
            else
            {
                output.texture = DownloadHandlerTexture.GetContent(request);
            }
        }
    }
}
