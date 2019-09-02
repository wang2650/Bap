﻿using WXQ.Caching.Abstractions;
using MessagePack;
using MessagePack.Resolvers;
using System;

namespace WXQ.Caching.Codec.MessagePack
{
    public class DefaultMessagePackSerializer : ICachingSerializer
    {
        public DefaultMessagePackSerializer()
        {
            MessagePackSerializer.SetDefaultResolver(ContractlessStandardResolver.Instance);
        }

        public T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }

        public object Deserialize(byte[] bytes, Type type)
        {
            return MessagePackSerializer.NonGeneric.Deserialize(type, bytes);
        }

        public byte[] Serialize<T>(T value)
        {
            return MessagePackSerializer.Serialize(value);
        }
    }
}
