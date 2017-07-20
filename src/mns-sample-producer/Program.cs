﻿using System;

namespace Aliyun.MNS.Sample.Producer
{
    class Program
    {

        static void Main(string[] args)
        {
            string Host = Environment.GetEnvironmentVariable("ALIYUN_MNS_HOST");
            string AccessKey = Environment.GetEnvironmentVariable("ALIYUN_MNS_ACCESSKEY");
            string AccessSecret = Environment.GetEnvironmentVariable("ALIYUN_MNS_ACCESSSECRET");

            Console.WriteLine($"Host: {Host}");
            Console.WriteLine($"AccessKey: {AccessKey}");
            Console.WriteLine($"AccessSecret: {AccessSecret}");

            var Queue = MNS.Configure(Host, AccessKey, AccessSecret).Queue("aries-test");

            var result = Queue.SendMessage(args.Length >= 1 ? args[0] : "test").Result;

            Console.WriteLine("Press any key to continue..");
            Console.Read();
        }
    }
}