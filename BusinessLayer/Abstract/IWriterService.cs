using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface IWriterService
    {
        Writer GetById(int id);
        List<Writer> GetList();
        int GetWriterId(string mail);
        void WriterAdd(Writer writer);
        void WriterRemove(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
