using System.Net;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {
            
        }

        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>
            {
                Data = entity,
                Meta = Meta,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Added Successfully",
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = "UnAuthorized"
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Meta = Meta,
                Data = entity,
                Message = "Added successfully",
            };
        }
    }
}
