﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string reciever);
        List<Message> GetListSendbox(string sender);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageRemove(Message message);
        void MessageUpdate(Message message);
        List<Message> GetUnReadMessage(string reciever);
        List<Message> GetMessages();
    }
}
