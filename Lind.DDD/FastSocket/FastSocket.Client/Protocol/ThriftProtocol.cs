﻿using System;

namespace Lind.DDD.FastSocket.Client.Protocol
{
    /// <summary>
    /// thrift protocol
    /// [message len,4][version,4][cmd len,4][cmd][seqID,4][data...,N]
    /// </summary>
    public sealed class ThriftProtocol : IProtocol<Response.ThriftResponse>
    {
        #region IProtocol Members
        /// <summary>
        /// find response
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="buffer"></param>
        /// <param name="readlength"></param>
        /// <returns></returns>
        /// <exception cref="BadProtocolException">bad thrift protocol</exception>
        public Response.ThriftResponse FindResponse(SocketBase.IConnection connection, ArraySegment<byte> buffer, out int readlength)
        {
            if (buffer.Count < 4) { readlength = 0; return null; }

            //获取message length
            var messageLength = SocketBase.Utils.NetworkBitConverter.ToInt32(buffer.Array, buffer.Offset);
            if (messageLength < 14) throw new BadProtocolException("bad thrift protocol");

            readlength = messageLength + 4;
            if (buffer.Count < readlength) { readlength = 0; return null; }

            var cmdLen = SocketBase.Utils.NetworkBitConverter.ToInt32(buffer.Array, buffer.Offset + 8);
            if (messageLength < cmdLen + 13) throw new BadProtocolException("bad thrift protocol");

            int seqID = SocketBase.Utils.NetworkBitConverter.ToInt32(buffer.Array, buffer.Offset + 12 + cmdLen);
            var data = new byte[messageLength];
            Buffer.BlockCopy(buffer.Array, buffer.Offset + 4, data, 0, messageLength);
            return new Response.ThriftResponse(seqID, data);
        }
        #endregion
    }
}