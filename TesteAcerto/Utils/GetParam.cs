using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteAcerto.Utils
{
    public class GetParam
    {
        public GetParam(string _key, string _value)
        {
            this.Key = _key;
            this.Value = _value;
        }
        public GetParam() { }

        public string Key { get; set; }
        public string Value { get; set; }
        public string EncodedValue => HttpUtility.UrlEncode(this.Value);

        public string QueryString => $"{this.Key}={this.EncodedValue}";
    }
}