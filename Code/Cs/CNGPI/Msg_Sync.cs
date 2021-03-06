﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CNGPI
{
    /// <summary>
    /// 同步
    /// </summary>
    public class Msg_Sync_Event : Message
    {
        public override int PID => 0x0102;

        public int State { get; set; }

        protected override void ReadData(MsgDataStream stream)
        {
            base.ReadData(stream);
            State = stream.ReadInt16();
        }

        protected override void WriteData(MsgDataStream stream)
        {
            base.WriteData(stream);
            stream.WriteInt16(State);
        }

        public override string ToString()
        {
            return $"状态同步:状态:{State}";
        }
    }

    /// <summary>
    /// 回应
    /// </summary>
    public class Msg_Sync_Back : Message, IBackMsg
    {
        public override int PID => 0x0182;

        public byte State { get; set; }

        public int RemainCoin { get; set; }

        public int RemainSec { get; set; }

        public int ErrCode { get; set; }

        protected override void ReadData(MsgDataStream stream)
        {
            base.ReadData(stream);
            State = stream.ReadByte();
            RemainCoin = stream.ReadInt16();
            RemainSec = stream.ReadInt16();
            ErrCode = stream.ReadInt16();
        }

        protected override void WriteData(MsgDataStream stream)
        {
            base.WriteData(stream);
            stream.WriteByte(State);
            stream.WriteInt16(RemainCoin);
            stream.WriteInt16(RemainSec);
            stream.WriteInt16(ErrCode);
        }
        public override string ToString()
        {
            return $"回应状态同步:状态:{State},余币{RemainCoin},剩余时间:{RemainSec}";
        }
    }
}
