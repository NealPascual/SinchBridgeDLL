using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SinchBridgeDLL
{
    public class JsonDeserializer
    {
        public class ResultModel
        {
            public int rankedPercent1;
            public double potentialPayout1;
            public int rankedPercent2;
            public double potentialPayout2;
        }

        public class ResponseObject
        {
            public string Result;
            public string Status;
        }

        public static ResponseObject DeserializedObject(string outputString)
        {
            ResponseObject response = new ResponseObject();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            outputString = outputString.Substring(1, outputString.Length - 2).Replace(@"\", "");
            try
            {
                response = serializer.Deserialize<ResponseObject>(outputString);
                return response;
            }
            catch (Exception)
            {
                response = new ResponseObject()
                {
                    Result = null,
                    Status = "Failed to deserialize"
                };
                return response;
            }


        }
    }
}
