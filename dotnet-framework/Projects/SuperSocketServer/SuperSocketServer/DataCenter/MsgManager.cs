using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketServer.DataCenter
{
    public class MsgManager
    {
        private static Dictionary<string, List<ChatModel>> msgCache = new Dictionary<string, List<ChatModel>>();

        public static void Add(string userId, ChatModel chatModel)
        {
            if (msgCache.ContainsKey(userId))
                 msgCache[userId].Add(chatModel);
            else
                msgCache[userId]=new List<ChatModel> { chatModel};
        }

        public static void Remove(string userId, string modelId)
        {
            if (msgCache.ContainsKey(userId))
                msgCache[userId] = msgCache[userId].Where(c => c.Id != modelId).ToList();
        }

        public static void UpdateMsgState(string userId,string modelId)
        {
            if (msgCache.ContainsKey(userId))
            {
                ChatModel newChatModel = msgCache[userId].Find(c => c.Id == modelId);
                newChatModel.State = MsgState.Sended;
                msgCache[userId] = msgCache[userId].Where(c => c.Id != modelId).ToList();
                msgCache[userId].Add(newChatModel);
            }
        }
        public static void SendOffLineMsg(string userId,Action<ChatModel> action)
        {
            if (msgCache.ContainsKey(userId))
            {
                foreach (var chatModel in msgCache[userId])
                {
                    if (chatModel.State==MsgState.UnSend)
                    {
                        action?.Invoke(chatModel);
                        chatModel.State = MsgState.Sending;
                    }
                }
            }
        }
    }
}
