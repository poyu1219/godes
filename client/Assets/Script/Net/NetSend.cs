///////////////////////////////////////////////////////////////////////////
///////// This file is generated by proto/gen_proto.py from ///////////////
///////// proto.txt and proto_data.txt, do not edit!!!		///////////////
///////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using MsgPack.Serialization;

public class NetSend
{
    private static NetSend instance_ = null;

    private MessagePackSerializer<List<object>> serializer_ = MessagePackSerializer.Get<List<object>>();
    private List<object> targetObject_ = new List<object>();
    private MemoryStream stream_ = new MemoryStream();

    public static NetSend Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = new NetSend();
            return instance_;
        }
    }

    private void PackSend()
    {
        serializer_.Pack(stream_, targetObject_);

        NetClient.Instance.Send(stream_.ToArray());
        stream_.Flush();
        stream_.Position = 0;
        stream_.SetLength(0);
    }

	public void SendRegisterAsk(string Name, string Passwd)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.REGISTERASK);
		targetObject_.Add(Name);
		targetObject_.Add(Passwd);
		PackSend();
	}

	public void SendLoginAsk(string Name, string Passwd)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.LOGINASK);
		targetObject_.Add(Name);
		targetObject_.Add(Passwd);
		PackSend();
	}

	public void SendFriendAsk()
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.FRIENDASK);
		PackSend();
	}

	public void SendRUOKAsk(bool Ok)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.RUOKASK);
		targetObject_.Add(Ok);
		PackSend();
	}

	public void SendUserMoveAsk(int X, int Y)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.USERMOVEASK);
		targetObject_.Add(X);
		targetObject_.Add(Y);
		PackSend();
	}

	public void SendAttackAsk(int Entityid)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.ATTACKASK);
		targetObject_.Add(Entityid);
		PackSend();
	}

	public void SendPutBombAsk(int X, int Y)
	{
		targetObject_.Clear();

		targetObject_.Add(PROTO_ID.PUTBOMBASK);
		targetObject_.Add(X);
		targetObject_.Add(Y);
		PackSend();
	}

}