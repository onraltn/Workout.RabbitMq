﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Producer
{
    public class DirectExchangePublisher
    {
        public static void Publish(IModel channel)
        {
            var ttl = new Dictionary<string, object>()
            {
                {"x-message-ttl", 3000 }
            };
            channel.ExchangeDeclare("demo-direct-exchange",
              type: ExchangeType.Direct,
              arguments: ttl
            );
            var count = 0;
            while (true)
            {
                var message = new { Name = "Producer", Message = $"Helo! Count: {count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                channel.BasicPublish("demo-direct-exchange", "account.init", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}
