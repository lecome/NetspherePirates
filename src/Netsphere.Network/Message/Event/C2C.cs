using System;
using BlubLib.Serialization;
using BlubLib.Serialization.Serializers;
using ProudNet.Serializers;

namespace Netsphere.Network.Message.Event
{
    [BlubContract]
    public class ChatMessage : EventMessage
    {
        [BlubMember(0, typeof(StringSerializer))]
        public string Message { get; set; }
    }

    [BlubContract]
    public class EventMessageMessage : EventMessage
    {
        [BlubMember(0, typeof(EnumSerializer), typeof(uint))]
        public GameEventMessage Event { get; set; }

        [BlubMember(1)]
        public ulong AccountId { get; set; }

        [BlubMember(2)]
        public uint Unk { get; set; } // server/game time or something like that

        [BlubMember(3)]
        public ushort Value { get; set; }

        [BlubMember(4, typeof(StringSerializer))]
        public string String { get; set; }

        public EventMessageMessage()
        {
            String = "";
        }

        public EventMessageMessage(GameEventMessage @event, ulong accountId, uint unk, ushort value, string @string)
        {
            Event = @event;
            AccountId = accountId;
            Unk = unk;
            Value = value;
            String = @string;
        }
    }

    [BlubContract]
    public class ChangeTargetMessage : EventMessage
    {
        [BlubMember(0)]
        public short Unk1 { get; set; }

        [BlubMember(1)]
        public int Unk2 { get; set; }
    }

    [BlubContract]
    public class ArcadeSyncMessage : EventMessage
    {
        [BlubMember(0)]
        public byte Unk1 { get; set; }

        [BlubMember(1)]
        public int Unk2 { get; set; }

        [BlubMember(2, typeof(ArrayWithScalarSerializer))]
        public byte[] Unk3 { get; set; }

        public ArcadeSyncMessage()
        {
            Unk3 = Array.Empty<byte>();
        }
    }

    [BlubContract]
    public class ArcadeSyncReqMessage : EventMessage
    {
        [BlubMember(0)]
        public int Unk1 { get; set; }

        [BlubMember(1, typeof(ArrayWithScalarSerializer))]
        public byte[] Unk2 { get; set; }

        public ArcadeSyncReqMessage()
        {
            Unk2 = Array.Empty<byte>();
        }
    }

    [BlubContract]
    public class PacketMessage : EventMessage
    {
        [BlubMember(0)]
        public bool IsCompressed { get; set; }

        [BlubMember(1, typeof(ArrayWithScalarSerializer))]
        public byte[] Data { get; set; }

        public PacketMessage()
        {
            Data = Array.Empty<byte>();
        }

        public PacketMessage(bool isCompressed, byte[] data)
        {
            IsCompressed = isCompressed;
            Data = data;
        }
    }
}