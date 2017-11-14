using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using MiniJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace IBM.Watson.DeveloperCloud.Connection
{
    public class TestUnityWebRequestConnector : MonoBehaviour
    {
        private string _discoveryUrl = "https://gateway.watsonplatform.net/discovery/api/v1/environments";
        private string _discoveryUsername = "d1c62431-617d-40a9-b729-5113d2cb34fa";
        private string _discoveryPassword = "0lcYAxBHkpIL";
        private string _discoveryVersionDate = "2017-09-01";

        private string _toneAnalyzerUrl = "https://gateway.watsonplatform.net/tone-analyzer/api/v3/tone";
        private string _toneAnalyzerUsername = "24766a29-abb6-4273-be74-eb137616b52a";
        private string _toneAnalyzerPassword = "i0TuJECGdJFQ";
        private string _toneAnalyzerVersionDate = "2017-09-21";
        private string _stringToTestTone = "This service enables people to discover and understand, and revise the impact of tone in their content. It uses linguistic analysis to detect and interpret emotional, social, and language cues found in text.";

        private string _visualRecognitionUrl = "https://gateway-a.watsonplatform.net/visual-recognition/api/v3/classifiers";
        private string _visualRecognitionApiKey = "visualrecognitionapikeytotestquerieswith";
        private string _visualRecogntionVersionDate = "2016-05-20";

        Credentials _discoveryCredentials;
        Credentials _toneAnalyzerCredentials;

        void Start()
        {
            LogSystem.InstallDefaultReactors();
            _discoveryCredentials = new Credentials(_discoveryUsername, _discoveryPassword, _discoveryUrl);
            _toneAnalyzerCredentials = new Credentials(_toneAnalyzerUsername, _toneAnalyzerPassword, _toneAnalyzerUrl);
            //Runnable.Run(GetCall());
            //Runnable.Run(PostCallBody());
            Runnable.Run(PostCallFormData());
        }

        private IEnumerator GetCall()
        {
            UnityWebRequest wr = UnityWebRequest.Get(_discoveryUrl + "?version=" + _discoveryVersionDate);
            wr.SetRequestHeader("Authorization", _discoveryCredentials.CreateAuthorization());

            yield return wr.SendWebRequest();

            if (string.IsNullOrEmpty(wr.error))
            {
                Log.Debug("TestUnityWebRequestConnector.GetCall()", "Success: {0}", wr.downloadHandler?.text);
            }
            else
            {
                Log.Error("TestUnityWebRequestConnector.GetCall()", "Error: {0}", wr.error);
            }
        }

        private IEnumerator PostCallBody()
        {
            Dictionary<string, string> upload = new Dictionary<string, string>();
            upload["text"] = _stringToTestTone;
            string json = Json.Serialize(upload);
            byte[] jsonData = Encoding.UTF8.GetBytes(json);

            UnityWebRequest wr = new UnityWebRequest(_toneAnalyzerUrl + "?version=" + _toneAnalyzerVersionDate);
            wr.method = UnityWebRequest.kHttpVerbPOST;
            wr.uploadHandler = new UploadHandlerRaw(jsonData);
            wr.uploadHandler.contentType = "application/json";
            wr.downloadHandler = new DownloadHandlerBuffer();
            wr.SetRequestHeader("Authorization", _toneAnalyzerCredentials.CreateAuthorization());

            yield return wr.SendWebRequest();

            if (wr.isNetworkError || wr.isHttpError)
            {
                Log.Error("TestUnityWebRequestConnector.PostCallBody()", "Error: {0}: {1} | {2}", wr.responseCode, wr.error, wr.downloadHandler?.text);
            }
            else
            {
                Log.Debug("TestUnityWebRequestConnector.PostCallBody()", "Success: {0}", wr.downloadHandler?.text);
            }
        }

        private IEnumerator PostCallFormData()
        {
            string positiveExamplesPath = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/visual-recognition-classifiers/turtle_positive_examples.zip";
            string negativeExamplesPath = Application.dataPath + "/Watson/Examples/ServiceExamples/TestData/visual-recognition-classifiers/negative_examples.zip";
            byte[] positiveExamplesData = File.ReadAllBytes(positiveExamplesPath);
            byte[] negativeExamplesData = File.ReadAllBytes(negativeExamplesPath);

            //Dictionary<string, byte[]> positiveExamplesData = new Dictionary<string, byte[]>();
            //byte[] positiveExamplesData = null;
            //byte[] negativeExamplesData = null;


            //WWWForm form = new WWWForm();
            //form.AddBinaryData("giraffe_positive_examples", positiveExamplesData, "giraffe_positive_examples.zip", "application/zip");
            //form.AddBinaryData("negative_examples", negativeExamplesData, "negative_examples.zip", "application/zip");

            List<IMultipartFormSection> multipartForm = new List<IMultipartFormSection>();
            multipartForm.Add(new MultipartFormDataSection("giraffe_positive_examples", positiveExamplesData, "application/zip"));
            multipartForm.Add(new MultipartFormDataSection("negative_examples", negativeExamplesData, "application/zip"));
            //multipartForm.Add(new MultipartFormFileSection("turtle_positive_examples", positiveExamplesData, "turtle_positive_examples.zip", "application/zip"));
            //multipartForm.Add(new MultipartFormFileSection("negative_examples", negativeExamplesData, "negative_examples.zip", "application/zip"));
            multipartForm.Add(new MultipartFormDataSection("name", "test-unity-web-request-classifier"));

            //UnityWebRequest wr = UnityWebRequest.Post(_visualRecognitionUrl + "?version=" + _visualRecogntionVersionDate + "&api_key=" + _visualRecognitionApiKey, multipartForm);

            UnityWebRequest wr = new UnityWebRequest(_visualRecognitionUrl + "?version=" + _visualRecogntionVersionDate + "&api_key=" + _visualRecognitionApiKey);
            byte[] serializedForm = UnityWebRequest.SerializeFormSections(multipartForm, UnityWebRequest.GenerateBoundary());
            wr.uploadHandler = new UploadHandlerRaw(serializedForm);
            wr.uploadHandler.contentType = "multipart/form-data";
            wr.method = UnityWebRequest.kHttpVerbPOST;

            wr.downloadHandler = new DownloadHandlerBuffer();
            //wr.SetRequestHeader("Content-Type", "multipart/form-data");

            yield return wr.SendWebRequest();

            if (wr.isNetworkError || wr.isHttpError)
            {
                Log.Error("TestUnityWebRequestConnector.PostCallFormData()", "Error: {0}: {1} | {2}", wr.responseCode, wr.error, wr.downloadHandler?.text);
            }
            else
            {
                Log.Debug("TestUnityWebRequestConnector.PostCallFormData()", "Success: {0}", wr.downloadHandler?.text);
            }
        }
    }
}
