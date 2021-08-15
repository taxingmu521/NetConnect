using System;
using System.Collections.Generic;
using TeamDev.Redis;

namespace Redis.redis
{
    /// <summary>
    /// redis获取所有指定多个键的值
    /// </summary>
    public class RedisTask
    {
        public string host = "127.0.0.1";
        public string topic = "__keyspace@0__:*";
        public int port = 6379;
        public string passowrd = "task123";
        private RedisDataAccessProvider redis;
        List<string> GetVs;
        public void Connect()
        {
            GetVs = new List<string>();
            redis = new RedisDataAccessProvider();
            redis.Configuration.Host = host;
            redis.Configuration.Port = port;
            var key = "ss";
            redis.Connect();
            redis.SendCommand(RedisCommand.KEYS, "*");
            var keys = redis.ReadMultiString();

            //打印所有的key
            foreach (var item in keys) {
                Console.WriteLine(item);
                GetVs.Add(item);
            }
            redis.SendCommand(RedisCommand.MGET, GetVs.ToArray());
            var kessy = redis.ReadMultiString();
        }
    }
}
