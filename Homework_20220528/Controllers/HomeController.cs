using Homework_20220528.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Homework_20220528.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly List<Exercise> _exercise = new List<Exercise>
        {
           new Exercise(){id=1,Medal="金牌",Name="郭婞淳",Sport="舉重",PrizeMoney=20000000},
           new Exercise(){id=2,Medal="金牌",Name="李洋、王齊麟",Sport="羽球",PrizeMoney=20000000},
           new Exercise(){id=3,Medal="銀牌",Name="楊勇緯",Sport="柔道",PrizeMoney=7000000},
           new Exercise(){id=4,Medal="銀牌",Name="鄧宇成、湯智鈞、魏均珩",Sport="射箭",PrizeMoney=7000000},
           new Exercise(){id=5,Medal="銀牌",Name="李智凱",Sport="體操",PrizeMoney=7000000},
           new Exercise(){id=6,Medal="銀牌",Name="戴資穎",Sport="羽球",PrizeMoney=7000000},
           new Exercise(){id=7,Medal="銅牌",Name="羅嘉翎",Sport="跆拳道",PrizeMoney=5000000},
           new Exercise(){id=8,Medal="銅牌",Name="林昀儒、鄭怡靜",Sport="桌球",PrizeMoney=5000000},
           new Exercise(){id=9,Medal="銅牌",Name="陳玟卉",Sport="舉重",PrizeMoney=5000000},
           new Exercise(){id=10,Medal="銅牌",Name="潘政琮",Sport="高爾夫",PrizeMoney=5000000},
           new Exercise(){id=11,Medal="銅牌",Name="黃筱雯",Sport="拳擊",PrizeMoney=5000000},
           new Exercise(){id=12,Medal="銅牌",Name="文姿云",Sport="空手道",PrizeMoney=5000000}
        };
        private static readonly List<People> _people = new List<People>
        {
           new People(){id=1 ,Name="郭婞淳",Sport="舉重"},
           new People(){id=2 ,Name="李洋、王齊麟",Sport="羽球"},
           new People(){id=3 ,Name="楊勇緯",Sport="柔道"},
           new People(){id=4 ,Name="鄧宇成、湯智鈞、魏均珩",Sport="射箭"},
           new People(){id=5 ,Name="李智凱",Sport="體操"},
           new People(){id=6 ,Name="戴資穎",Sport="羽球"},
           new People(){id=7 ,Name="羅嘉翎",Sport="跆拳道"},
           new People(){id=8 ,Name="林昀儒、鄭怡靜",Sport="桌球"},
           new People(){id=9 ,Name="陳玟卉",Sport="舉重"},
           new People(){id=10,Name="潘政琮",Sport="高爾夫"},
           new People(){id=11,Name="黃筱雯",Sport="拳擊"},
           new People(){id=12,Name="文姿云",Sport="空手道"}
        };
        private static readonly List<Medal> _medal = new List<Medal>
        {
           new Medal(){id=1,MedalName="金牌",PrizeMoney=20000000},
           new Medal(){id=2,MedalName="金牌",PrizeMoney=20000000},
           new Medal(){id=3,MedalName="銀牌",PrizeMoney=7000000},
           new Medal(){id=4,MedalName="銀牌",PrizeMoney=7000000},
           new Medal(){id=5,MedalName="銀牌",PrizeMoney=7000000},
           new Medal(){id=6,MedalName="銀牌",PrizeMoney=7000000},
           new Medal(){id=7,MedalName="銅牌",PrizeMoney=5000000},
           new Medal(){id=8,MedalName="銅牌",PrizeMoney=5000000},
           new Medal(){id=9,MedalName="銅牌",PrizeMoney=5000000},
           new Medal(){id=10,MedalName="銅牌",PrizeMoney=5000000},
           new Medal(){id=11,MedalName="銅牌",PrizeMoney=5000000},
           new Medal(){id=12,MedalName="銅牌",PrizeMoney=5000000}
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var exercise = _exercise;
            //取得所有金牌選手
            var Gold = exercise.Where(x => x.Medal == "金牌").ToList();
            //取得所有羽球的奪牌紀錄
            var Badminton = exercise.Where(x => x.Sport == "羽球").ToList();
            //獎金高低排序
            var PrizeMoneyHighToLow = exercise.OrderByDescending(x => x.PrizeMoney).ToList();
            //最高獎金
            var PrizeMoneyMax = exercise.Max(x => x.PrizeMoney);
            //獎金總和
            var PrizeMoneySum = exercise.Sum(x => x.PrizeMoney);
            //挑戰題目1
            //羽球的獎金總和
            var BadmintonBonusTotal = exercise.Where(x => x.Sport == "羽球").Sum(x => x.PrizeMoney);
            //銀牌獎金總和
            var SilverBonus = exercise.Where(x => x.Medal == "銀牌").Sum(x => x.PrizeMoney);
            //挑戰題目2
            var detail = (from peo in _people
                          join med in _medal
                          on peo.id equals med.id
                          select new Exercise()
                          {
                              id = peo.id,
                              Name = peo.Name,
                              Medal = med.MedalName,
                              Sport = peo.Sport,
                              PrizeMoney = med.PrizeMoney
                          });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}