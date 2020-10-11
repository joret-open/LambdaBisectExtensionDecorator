using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambdaBisectExtension.Models
{
    public class MyData
    {
        public string Id { get; set; }
        public string Content { get; set; }

        public MyData()
        {

        }

        public MyData(string id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}
