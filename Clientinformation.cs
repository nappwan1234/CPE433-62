using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DNWS
{
  class Clientinformation : IPlugin
  {
    public Clientinformation()
    {
    }

    public void PreProcessing(HTTPRequest request)
    {
      throw new NotImplementedException();
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      String[] IPandPort = Regex.Split(request.getPropertyByKey("RemoteEndPoint"), ":");

      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><body>");
      sb.Append("Client IP: ");
      sb.Append(IPandPort[0]);
      sb.Append("<br><br>");
      sb.Append("Client Port: ");
      sb.Append(IPandPort[1]);
      sb.Append("<br><br>");
      sb.Append("Browser Information: ");
      sb.Append(request.getPropertyByKey("User-Agent"));
      sb.Append("<br><br>");
      sb.Append("Accept Language: ");
      sb.Append(request.getPropertyByKey("Accept-Language"));
      sb.Append("<br><br>");
      sb.Append("Accept Encoding: ");
      sb.Append(request.getPropertyByKey("Accept-Encoding"));
      sb.Append("<br><br>");
      sb.Append("</body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
}