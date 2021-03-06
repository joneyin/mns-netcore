﻿using Aliyun.MNS.Model;
using Aliyun.MNS.Utility;
using System;
using System.Net.Http;

namespace Aliyun.MNS
{
    public class BatchDeleteMessageApiRequest : ApiRequestBase<BatchDeleteMessageApiParameter, ApiResult>
    {
        private MnsConfig config;
        private string queueName;

        protected override string Path => $"/queues/{this.queueName}/messages";
        protected override HttpMethod Method => HttpMethod.Delete;

        public BatchDeleteMessageApiRequest(MnsConfig config, string queueName, BatchDeleteMessageApiParameter parameter) : base(config, parameter)
        {
            if (parameter == null || parameter.ReceiptHandles == null || parameter.ReceiptHandles.Count <= 0)
            {
                throw new ArgumentException("parameter");
            }

            this.config = config;
            this.queueName = queueName;
        }

        protected override string Body
        {
            get
            {
                var xml = XmlSerdeUtility.Serialize(this.Parameter);
                Console.WriteLine(xml);
                return xml;
            }
        }
    }
}