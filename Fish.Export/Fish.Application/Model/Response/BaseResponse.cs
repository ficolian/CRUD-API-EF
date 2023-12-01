using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fish.Application.Model
{
    public class Response<T>
    {
        public IEnumerable<T> data { get; set; }
        public string message { get; set; }
        public Guid transactionId { get; set; }

        public Response<T> SetResponse(string messages, IEnumerable<T> datas,Guid transactionIds)
        {
            data = datas;
            transactionId = transactionIds;
            message = messages;

            return this;
        }
    }

    public class ResponseOne<T> where T : class
    {
        public T data { get; set; }
        public string message { get; set; }
        public Guid transactionId { get; set; }

        public ResponseOne<T> SetResponse(string messages, T datas, Guid transactionIds)
        {
            message = messages;
            data = datas;
            transactionId = transactionIds;

            return this;
        }
    }
}
