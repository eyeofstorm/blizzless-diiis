﻿using DiIiS_NA.GameServer.MessageSystem.Message.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiIiS_NA.GameServer.MessageSystem.Message.Definitions.Base
{
    [Message(new[] {Opcodes.FloatingGBIDAmountMessage })]
    public class FloatingGBIDAmountMessage : GameMessage
    {
        public WorldPlace Field0;
        public int Field1;
        public int /* gbid */ Field2;

        public override void Parse(GameBitBuffer buffer)
        {
            if (Field0 == null)
                Field0 = new WorldPlace();
            Field0.Parse(buffer);
            Field1 = buffer.ReadInt(32);
            Field2 = buffer.ReadInt(32);
        }

        public override void Encode(GameBitBuffer buffer)
        {
            Field0.Encode(buffer);
            buffer.WriteInt(32, Field1);
            buffer.WriteInt(32, Field2);
        }

        public override void AsText(StringBuilder b, int pad)
        {
            b.Append(' ', pad);
            b.AppendLine("FloatingGBIDAmountMessage:");
            b.Append(' ', pad++);
            b.AppendLine("{");
            b.Append(' ', pad); b.AppendLine("Field1: 0x" + Field1.ToString("X8"));
            b.Append(' ', pad); b.AppendLine("Field2: 0x" + Field2.ToString("X8"));
            b.Append(' ', --pad);
            b.AppendLine("}");
        }


    }
}
