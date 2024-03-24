namespace WebApplication1.Models;

/// <summary>
/// 不要传入 using 声明的 fileStream 
/// fileStream和filePath 其一即可
/// </summary>
/// <param name="fileStream">文件流</param>
/// <param name="filePath">文件地址</param>
/// <param name="fileName">文件名字</param>
/// <param name="contentType">响应头</param>
/// <param name="bufferSize">每次大小</param>
/// <param name="speed">熟读 单位秒</param>
public record DownloadConfig(Stream? stream = null, string? filePath = null,
                                           string fileName = "defualt.txt",
                                           string contentType = "application/octet-stream",
                                           int bufferSize = 1024,
                                           int speed = 0);
