using System;
using System.Net;

using System.Xml.Serialization;
using TSoft.TVServer.Constants;

namespace TSoft.TVServer.Entities
{
    /// <summary> A response object. </summary>
    /// <typeparam name="O"> Type of the o. </typeparam>
    /// <typeparam name="R"> Type of the r. </typeparam>
    /// <seealso cref="T:TSoft.TVServer.Entities.ResponseObject{O}"/>
    public class ResponseObject<O, R> : ResponseObject<O> where O:class where R:class
    {
        /// <summary> Gets or sets the request. </summary>
        /// <value> The request. </value>
        public R Request { get; set; }
    }

    /// <summary> A response object. </summary>
    /// <typeparam name="O"> Type of the o. </typeparam>
    public class ResponseObject<O> where O : class
    {
        #region [Constructors]

        /// <summary>
        /// Initializes a new instance of the
        /// MediaBrowser.Plugins.DVBLink.Models.ResponseObject&lt;O&gt; class. </summary>
        public ResponseObject()
        {

        }

        /// <summary>
        /// Initializes a new instance of the
        /// MediaBrowser.Plugins.DVBLink.Models.ResponseObject&lt;O&gt; class. </summary>
        /// <param name="resultObject"> The result object. </param>
        /// <param name="response"> The response. </param>
        public ResponseObject(O resultObject, Response response)
        {
            ResultObject = resultObject;
            Response = response;
            Status = response.Status;
            Exception = response.Exception;
        }

        /// <summary> Initializes a new instance of the <see cref="ResponseObject"/> class. </summary>
        /// <param name="resultObject"> . </param>
        /// <param name="status"> . </param>
        /// <param name="exception"> . </param>
        public ResponseObject(O resultObject, EnumStatusCode status, Exception exception)
        {
            Status = status;
            Exception = exception;
            ResultObject = resultObject;
        }

        #endregion

        #region [Public Properties]
        /// <summary> Gets the status. </summary>
        /// <value> The status. </value>
        public EnumStatusCode Status { get; set; }

        /// <summary> Gets the exception. </summary>
        /// <value> The exception. </value>
        public Exception Exception { get; set; }

        /// <summary> Gets or sets the response. </summary>
        /// <value> The response. </value>
        public Response Response { get; set; }

        /// <summary> Gets or sets the result object. </summary>
        /// <value> The result object. </value>
        public O ResultObject { get; set; }

        #endregion

    }
}
