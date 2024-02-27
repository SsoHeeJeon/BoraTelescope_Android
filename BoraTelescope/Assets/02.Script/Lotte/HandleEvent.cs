using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;

public class HandleEvent : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField]
    GameObject Handle;
    [SerializeField]
    VideoPlayer videoplyer;
    Touch touch;
    public float fulltime;

    private void Start()
    {
        fulltime = (float)videoplyer.frameCount / (float)videoplyer.frameRate;
    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        videoplyer.gameObject.GetComponent<VideoManager>().isDrag= true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        videoplyer.gameObject.GetComponent<VideoManager>().isDrag = false;
        videoplyer.Play();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Handle.GetComponent<RectTransform>().anchoredPosition.x>=2 && Handle.GetComponent<RectTransform>().anchoredPosition.x <= 940)
        {
            Handle.transform.position = new Vector3(eventData.position.x, Handle.transform.position.y, Handle.transform.position.z);
            Handle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Handle.GetComponent<RectTransform>().anchoredPosition.x, Handle.GetComponent<RectTransform>().anchoredPosition.y);
            Handle.transform.parent.GetComponent<Image>().fillAmount = Handle.transform.localPosition.x / 956 +0.5f;
            videoplyer.time = Handle.transform.parent.GetComponent<Image>().fillAmount * fulltime;
            videoplyer.Pause();
        }
    }

    public void OnclickBtn(GameObject btn)
    {
        Handle.transform.position = new Vector3(btn.transform.position.x, Handle.transform.position.y, Handle.transform.position.z);
        Handle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Handle.GetComponent<RectTransform>().anchoredPosition.x, Handle.GetComponent<RectTransform>().anchoredPosition.y);
        Handle.transform.parent.GetComponent<Image>().fillAmount = Handle.transform.localPosition.x / 956 + 0.5f;
        Debug.LogError(Handle.transform.parent.GetComponent<Image>().fillAmount * fulltime + " / " + videoplyer.time);
        videoplyer.time = Handle.transform.parent.GetComponent<Image>().fillAmount * fulltime;
    }

}
