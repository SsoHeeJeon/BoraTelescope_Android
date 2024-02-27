using Amazon.S3.Model;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using Amazon.S3;
using Amazon;
using System;
using System.Net.Http;

public class UploadImage : QRMaker
{
    public string IdentityPoolId = "";
    public static string CognitoIdentityRegion = RegionEndpoint.APNortheast2.SystemName;
    private RegionEndpoint _CognitoIdentityRegion
    {
        get { return RegionEndpoint.GetBySystemName(CognitoIdentityRegion); }
    }
    
    private IAmazonS3 _s3Client;
    public Text ResultText = null;
    private string fileName;

    public static bool awsputImage = false;

    private void Update()
    {
        if (QRCodeImage.transform.parent.gameObject.transform.GetChild(1).gameObject.activeSelf)
        {
            QRCodeImage.transform.parent.gameObject.transform.GetChild(1).transform.GetChild(0).gameObject.GetComponent<Image>().fillAmount += 0.8f * Time.deltaTime;
        }
    }

    private void makeS3Client()
    {
        string accesskey = null;
        string secretkey = null;

        _s3Client = new AmazonS3Client(accesskey, secretkey, _CognitoIdentityRegion);
    }

    public void GetListbucketObjects()
    {
        makeS3Client();

        var request = new ListObjectsRequest()
        {
            BucketName = "borabucket"
        };

        using (_s3Client) 
        {
            try
            {
                var listObjectsResponse = _s3Client.ListObjects(request);

                for (int index = 0; index < listObjectsResponse.S3Objects.Count; index++)
                {
                    if(listObjectsResponse.S3Objects[index].Key == fileName)
                    {
                        //armode.gamemanager.WriteLog(LogSendServer.NormalLogCode.AR_ImageListConfirm, "AR_ImageListConfirm", GetType().ToString());
                        MakeQRCode();
                    }
                }
            }
            catch(Exception e)
            {
                Debug.Log(e);
                //armode.gamemanager.WriteErrorLog(LogSendServer.ErrorLogCode.Fail_ImageListConfirm, "Fail_ImageListConfirm : " + e, GetType().ToString());
            }
        }
    }

    public void PutImageObject(string filepath, string filename)
    {
        HttpClient httpClient = new HttpClient();
        MultipartFormDataContent form = new MultipartFormDataContent();

        byte[] imagebytearraystring = ImageFileToByteArray(filepath); // 파일 경로 넣기
        form.Add(new ByteArrayContent(imagebytearraystring, 0, imagebytearraystring.Length), "boraphotofile", filename); // key 이름, 업로드 될 때 이름

        try
        {
            HttpResponseMessage response = httpClient.PostAsync("https://bora.web.awesomeserver.kr/info/BoraUploadForPhotoToS3", form).Result; // 요청할 페이지 주소 (반드시 http 나 https 로 시작해야함)
            httpClient.Dispose();
            url = response.Content.ReadAsStringAsync().Result; // 성공적으로 완료 될 시 서버 측에서의 답변 값
            Console.WriteLine(url);

            if (url == "Fail Upload")
            {
                return;
            }
            else if (url.Contains("error") || url.Contains("Error"))
            {
                Debug.Log("no");
                return;
            }
            MakeQRCode();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            gamemanager.ErrorMessage.SetActive(true);
        }
    }

    byte[] ImageFileToByteArray(string fullFilePath)
    {
        FileStream fs = File.OpenRead(fullFilePath);
        byte[] bytes = new byte[fs.Length];
        fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
        fs.Close();
        return bytes;
    }
}
