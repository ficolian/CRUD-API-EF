using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Fish.Application.Model
{
    public class Response<T>
    {
        public IEnumerable<T> data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
        public int status { get; set; }
        public string message { get; set; }
        public Guid transactionId { get; set; }

        public Response<T> ReponseSuccess(string messages, IEnumerable<T> datas,Guid transactionIds)
        {
            data = datas;
            transactionId = transactionIds;
            message = messages;
            status = 1;

            return this;
        }

        public Response<T> ResponseFail(string messages, IEnumerable<T> datas, Guid transactionIds)
        {
            data = datas;
            transactionId = transactionIds;
            message = messages;
            status = 0;

            return this;
        }

        public Response<T> ResponseSucess(string messages, IEnumerable<T> datas, int page, int pageSize, int total, Guid transactionIds)
        {
            data = datas;
            this.page = page;
            this.pageSize = pageSize;
            this.pageSize = pageSize;
            this.total = total;
            this.status = 1;
            transactionId = transactionIds;
            message = messages;

            return this;
        }
    }

    public class ResponseOne<T> where T : class
    {
        public T data { get; set; }
        public string message { get; set; }
        public int status { get; set; }
        public Guid transactionId { get; set; }

        public ResponseOne<T> ResponseSuccess(string messages, T datas, Guid transactionIds)
        {
            message = messages;
            data = datas;
            transactionId = transactionIds;
            status = 1;

            return this;
        }

        public ResponseOne<T> ResponseFail(string messages, T datas, Guid transactionIds)
        {
            message = messages;
            data = datas;
            transactionId = transactionIds;
            status = 0;

            return this;
        }
    }
}
