using System.Text;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helper;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[Controller]/[Action]")]
public class HomeController : ControllerBase
{
    private static readonly string @string =
        "原文：为中华之崛起而读书课文-小学语文课文　　新学年开始了，修身课上，奉天东关模范学校的魏校长向学生们提出了一个严肃的问题：“你们为什么而读书？”　　“为家父而读书。”　　“为明理而读书。”　　“为光耀门楣而读书。”有人干脆这样回答。　　有位同学一直默默地坐在那里，若有所思。魏校长注意到了，他打手势让大家安静下来，点名让那位同学回答。那位同学站了起来，清晰而坚定地回答道：　　“为中华之崛起而读书！”　　魏校长听了为之一振！他怎么也没想到，一个十二三岁的孩子，竟然有如此的抱负和胸怀！他睁大眼睛又追问了一句：“你再说一遍，为什么而读书？”　　“为中华之崛起而读书！”　　魏校长听了，连声赞叹：“好哇！为中华之崛起，有志者当效此生！”　　这位同学是谁呢？他就是周恩来，后来成为了中华人民共和国的第一任总理。　　周恩来出生于1898年。十二岁那年，他离开家乡江苏淮安，随回家探亲的伯父来到了东北。在奉天上学的时候，伯父告诉他，奉天有些地方被外国人占据了，不要随便去玩，有事也要绕着走，免得惹出麻烦没有地方说理。　　少年周恩来疑惑不解，问道：“被外国人占据？为什么呢？”　　“中华不振哪！”伯父叹了口气，没有再说什么。　　十二岁的周恩来当然不能完全明白伯父的话，但是“中华不振”四个字和伯父沉郁的表情却让他难以忘怀。　　一个星期天，周恩来背着伯父，约了一个同学来到了被外国人占据的地方。这一带果真和别处大不相同：街道上热闹非凡，往来的大多是外国人。　　周恩来和同学一路上左顾右盼，忽然发现巡警局门前围着一群人。他们凑了过去，只见人群中有个女人正在哭诉着什么。一问才知道，这个女人的亲人被外国人的汽车轧死了，她原本指望巡警局给她撑腰，惩处这个外国人，谁知中国巡警不但不惩处肇事的外国人，反而训斥她。围观的中国人都紧握着拳头，但这是在被外国人占据的地盘里，谁又敢怎么样呢？大家只能劝慰这个不幸的女人。　　此时的周恩来才真正体会到“中华不振”这四个字的沉重分量。怎么把祖国和人民从苦难和屈辱中拯救出来呢？这个问题像一团烈火一直燃烧在周恩来心中。所以，当修身课上魏校长提出为什么而读书这个问题时，就有了“为中华之崛起而读书”的响亮回答。　　";

    [HttpGet]
    public async Task GetStream()
    {
        await DownloadHelper.DownloadAsync(
            base.HttpContext,
            new Models.DownloadConfig
            {
                stream = StringToStream(@string),
                fileName = "filename.txt",
                speed = 3,
                bufferSize = 1024
            }
        );
    }

    /// <summary>
    /// 字符串转流
    /// </summary>
    /// <param name="string"></param>
    /// <returns></returns>
    private static Stream StringToStream(string @string)
    {
        byte[] data = Encoding.UTF8.GetBytes(@string);
        return new MemoryStream(data, 0, data.Length);
    }
}
