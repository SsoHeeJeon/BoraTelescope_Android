using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using System.Threading;

public class OnEventClick : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Handle;
    [SerializeField]
    VideoPlayer videoplyer;

    float fulltime;
    private void Start()
    {
        fulltime = (float)videoplyer.frameCount / (float)videoplyer.frameRate;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(videoplyer.isPaused)
        {
            videoplyer.Play();
        }
        Handle.transform.position = new Vector3(eventData.pressPosition.x, Handle.transform.position.y, Handle.transform.position.z);
        Handle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Handle.GetComponent<RectTransform>().anchoredPosition.x + 478, Handle.GetComponent<RectTransform>().anchoredPosition.y);
        Handle.transform.parent.GetComponent<Image>().fillAmount = ((Handle.transform.localPosition.x) / 956);
        videoplyer.time = Handle.transform.parent.GetComponent<Image>().fillAmount * fulltime;

    }

    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    videoplyer.Stop();
    //}

    //public void OnDrag(PointerEventData eventData)
    //{
    //    Handle.transform.position = new Vector3(eventData.pressPosition.x, Handle.transform.position.y, Handle.transform.position.z);
    //    Handle.GetComponent<RectTransform>().anchoredPosition = new Vector2(Handle.GetComponent<RectTransform>().anchoredPosition.x + 50, Handle.GetComponent<RectTransform>().anchoredPosition.y);
    //    Handle.transform.parent.GetComponent<Image>().fillAmount = Handle.transform.localPosition.x / 100;
    //    videoplyer.time = Handle.transform.parent.GetComponent<Image>().fillAmount * fulltime;
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    videoplyer.Play();
    //}

}
