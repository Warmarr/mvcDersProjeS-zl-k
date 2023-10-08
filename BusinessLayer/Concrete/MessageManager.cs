

using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x=>x.MessageID == id);
        }
        public List<Message> GetListSendbox(string sender)
        {
            return _messageDal.List(x=>x.SenderMail==sender);
        }

        public List<Message> GetListInbox(string receiver)
        {
            return _messageDal.List(x=>x.ReceiverMail == receiver);

        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageRemove(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public List<Message> GetUnReadMessage(string reciever)
        {
            return _messageDal.List(x=>x.ReceiverMail==reciever && x.IsRead==false);
        }

        public List<Message> GetMessages()
        {
            return _messageDal.List();
        }
    }
}
