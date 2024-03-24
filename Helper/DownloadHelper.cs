using System.Text;
using System.Web;

using WebApplication1.Models;

namespace WebApplication1.Helper;

public static class DownloadHelper
{
    public static async Task DownloadAsync(HttpContext httpContext, DownloadConfig downloadConfig)
    {
        Stream? stream = downloadConfig.stream;
        try
        {
            if (stream is null)
            {
                if (downloadConfig.filePath is null)
                    throw new Exception("配置参数不能fileStream 和 filePath 都为null");

                stream = new FileStream(
                    downloadConfig.filePath,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite
                );
            }

            httpContext.Response.ContentType = downloadConfig.contentType;

            string encodedFileName = HttpUtility.UrlEncode(downloadConfig.fileName, Encoding.UTF8);
            httpContext.Response.Headers.Append(
                "Content-Disposition",
                "attachment;filename=" + encodedFileName
            );

            httpContext.Response.Headers.Append("Charset", "utf-8");
            httpContext.Response.Headers.Append(
                "Access-Control-Expose-Headers",
                "Content-Disposition"
            );
            httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);

            await using (StreamWriter writer = new StreamWriter(httpContext.Response.Body, Encoding.UTF8))
            {
                char[] buffer = new char[downloadConfig.bufferSize];
                int bytesRead;
                while ((bytesRead = await reader.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await writer.WriteAsync(buffer, 0, bytesRead);
                    await writer.FlushAsync();

                    if (httpContext.RequestAborted.IsCancellationRequested)
                    {
                        return;
                    }

                    await Task.Delay(downloadConfig.speed * 1000);
                }
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            stream?.Dispose();
        }
    }
}