﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPEngineReduxLibrary.Readers
{
    public class ReaderBase
    {
        // JSON Array reader.
        public JArray ReadJsonArray(string JsonData)
        {
            JArray JsonArray = JArray.Parse(JsonData);
            return JsonArray;
        }

        // Read an individual JObject.
        public JObject ReadJsonObject(string JsonData)
        {
            JObject JsonObject = JObject.Parse(JsonData);
            return JsonObject;
        }
    }
}
